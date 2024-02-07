using CSharpFunctionalExtensions;
using Domain.Users;

namespace Application.Interfaces;

public interface IJwtProvider
{
    Result<Token> Generate(User user);
}