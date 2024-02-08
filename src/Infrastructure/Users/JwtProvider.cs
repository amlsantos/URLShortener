using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Users;

public class JwtProvider : IJwtProvider
{
    private readonly JwtSecurityTokenHandler _handler;
    public JwtProvider(JwtSecurityTokenHandler handler) => _handler = handler;

    public Result<Token> Generate(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
        };
        
        var secret = Encoding.UTF8.GetBytes("d5sd5s5ds5d5s5ds5d5s5ds5d5s5d5s5ds5d5sad");
        var key = new SymmetricSecurityKey(secret);
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var securityToken = new JwtSecurityToken("issuer", "audience", claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(1), credentials);
        var tokenValue = _handler.WriteToken(securityToken);
        
        var tokenOrError = Token.Create(tokenValue);
        if (tokenOrError.IsFailure)
            return Result.Failure<Token>(tokenOrError.Error);

        return Result.Success(tokenOrError.Value);
    }
}