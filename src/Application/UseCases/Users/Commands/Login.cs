using CSharpFunctionalExtensions;
using Domain.Users;
using MediatR;

namespace Application.UseCases.Users.Commands;

public record Login : IRequest<Result<Token>>
{
    public string Email { get; init; }
}