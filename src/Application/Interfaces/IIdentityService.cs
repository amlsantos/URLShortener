using CSharpFunctionalExtensions;
using Domain.Users;

namespace Application.Interfaces;

public interface IIdentityService
{
    Task<Maybe<User>> GetUserByEmailAsync(UserEmail email);
    Task<Result> Add(User user);
}