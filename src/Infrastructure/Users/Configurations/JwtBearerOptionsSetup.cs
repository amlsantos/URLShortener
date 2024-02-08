using System.Text;
using System.Text.Json;
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
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.ScretKey))
        };

        options.Events = new JwtBearerEvents
        {
            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                return context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    error = "Forbidden",
                    error_description = "You dont have permissions to access this resource x)"
                }));
            },

            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                // Ensure we always have an error and error description.
                if (string.IsNullOrEmpty(context.Error))
                    context.Error = "invalid_token";
                if (string.IsNullOrEmpty(context.ErrorDescription))
                    context.ErrorDescription = "This request requires a valid JWT access token to be provided";

                // Add some extra context for expired tokens.
                if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() ==
                    typeof(SecurityTokenExpiredException))
                {
                    var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                    context.Response.Headers.Add("x-token-expired",
                        authenticationException.Expires.ToString("o"));
                    context.ErrorDescription =
                        $"The token expired on {authenticationException.Expires.ToString("o")}";
                }

                return context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    error = context.Error,
                    error_description = context.ErrorDescription
                }));
            }
        };
    }

    public void Configure(string? name, JwtBearerOptions options) => Configure(options);
}