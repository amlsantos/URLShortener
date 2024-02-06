using System.Text.Json;
using Application.Exceptions;
using Application.Interfaces;
using Presentation.Common;

namespace Presentation.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, IConsoleLogger consoleLogger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            consoleLogger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var response = Envelope.Error(exception.Message, GetErrors(exception));

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = response.StatusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
    {
        if (exception is ValidationException validationException)
            return validationException.ErrorsDictionary;
        
        return new Dictionary<string, string[]>();
    }
}