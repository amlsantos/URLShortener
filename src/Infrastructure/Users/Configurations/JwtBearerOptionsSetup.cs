using System.Text;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Users.Configurations;

public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> options) => _jwtOptions = options.Value;

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

    private static Task HandleForbidden(ForbiddenContext context)
    {
        throw new AuthenticationException("Forbidden", "You dont have permissions to access this resource");
    }

    private static Task HandleChallenge(JwtBearerChallengeContext context)
    {
        context.HandleResponse();

        if (string.IsNullOrEmpty(context.Error))
            context.Error = "Invalid token";
        if (string.IsNullOrEmpty(context.ErrorDescription))
            context.ErrorDescription = "This request requires a valid JWT access token to be provided";

        if (context.AuthenticateFailure is not null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
        {
            var inner = context.AuthenticateFailure as SecurityTokenExpiredException;
            context.ErrorDescription = $"The token expired on {inner?.Expires:o}";
            
            throw new AuthenticationException(context.Error, $"Invalid token: {context.ErrorDescription}", inner);
        }

        throw new AuthenticationException(context.Error, $"Invalid token: {context.ErrorDescription}");
    }

    private Task HandleAuthenticationFailed(AuthenticationFailedContext context)
    {
        throw new AuthenticationException("Invalid token", $"Invalid token: {context.Exception.Message}");
    }

    public void Configure(string? name, JwtBearerOptions options) => Configure(options);
}