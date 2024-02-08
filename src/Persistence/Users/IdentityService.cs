using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Users;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;

    public IdentityService(UserManager<User> userManager) => _userManager = userManager;

    public async Task<Maybe<User>> GetUserByEmailAsync(UserEmail email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserEmail.Value == email.Value);
        return Maybe<User>.From(user);
    }
}