namespace Infrastructure.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException(string title, string message) : base(message)
    {
        Title = title;
        Message = message;
    }
    
    public AuthenticationException(string title, string message, Exception inner) : base(message, inner)
    {
        Title = title;
        Message = message;
    }
    
    public string Title { get; }
    public string Message { get; }
}