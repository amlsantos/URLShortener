using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Users;
using Infrastructure.Users.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Users;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly JwtSecurityTokenHandler _handler;

    public JwtProvider(JwtSecurityTokenHandler handler, IOptions<JwtOptions> options)
    {
        _handler = handler;
        _options = options.Value;
    }

    public Result<Token> Generate(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
        };
        
        var secret = Encoding.UTF8.GetBytes(_options.ScretKey);
        var key = new SymmetricSecurityKey(secret);
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var securityToken = new JwtSecurityToken(_options.Issuer, _options.Audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(_options.AccessTokenExpiration), credentials);
        var tokenValue = _handler.WriteToken(securityToken);
        
        var tokenOrError = Token.Create(tokenValue);
        if (tokenOrError.IsFailure)
            return Result.Failure<Token>(tokenOrError.Error);

        return Result.Success(tokenOrError.Value);
    }
}