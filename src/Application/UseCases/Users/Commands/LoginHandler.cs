using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Users;
using MediatR;

namespace Application.UseCases.Users.Commands;

public class LoginHandler : IRequestHandler<Login, Result<Token>>
{
    private readonly IIdentityService _identityService;
    private readonly IJwtProvider _jwtProvider;

    public LoginHandler(IIdentityService identityService, IJwtProvider jwtProvider)
    {
        _identityService = identityService;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<Token>> Handle(Login request, CancellationToken cancellationToken)
    {
        var emailOrError = UserEmail.Create(request.Email);
        if (emailOrError.IsFailure)
            return await Task.FromResult(Result.Failure<Token>(emailOrError.Error));

        var userOrNothing = await _identityService.GetUserByEmailAsync(emailOrError.Value);
        if (userOrNothing.HasNoValue)
            return Result.Failure<Token>($"there is no user for the given email");

        var tokenOrError = _jwtProvider.Generate(userOrNothing.Value);
        if (tokenOrError.IsFailure)
            return Result.Failure<Token>(tokenOrError.Error);

        return Result.Success(tokenOrError.Value);
    }
}