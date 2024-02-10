using System.Text;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Users.Configurations;

public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;
    private const string Error = "Invalid token";

    public JwtBearerOptionsSetup(IOptions<JwtOptions> options) => _jwtOptions = options.Value;

    public void Configure(string? name, JwtBearerOptions options) => Configure(options);

    public void Configure(JwtBearerOptions options)
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.ScretKey))
        };

        options.Events = new JwtBearerEvents
        {
            OnForbidden = context => HandleForbidden(context),
            OnChallenge = context => HandleChallenge(context),
            OnAuthenticationFailed = context => HandleAuthenticationFailed(context)
        };
    }

    private Task HandleForbidden(ForbiddenContext context)
    {
        throw new AuthenticationException(Error, "You dont have permissions to access this resource");
    }

    private Task HandleChallenge(JwtBearerChallengeContext context)
    {
        context.HandleResponse();

        if (IsAuthenticateFailure(context))
        {
            var expiredException = context.AuthenticateFailure as SecurityTokenExpiredException;
            if (expiredException is not null)
                throw new AuthenticationException(Error, $"The token expired on {expiredException.Expires:o}", expiredException);
        }

        throw new AuthenticationException(Error, "This request requires a valid JWT token to be provided");
    }

    private bool IsAuthenticateFailure(JwtBearerChallengeContext context)
    {
        return context.AuthenticateFailure is not null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException);
    }

    private Task HandleAuthenticationFailed(AuthenticationFailedContext context)
    {
        throw new AuthenticationException(Error, $"{context.Exception.Message}");
    }
}