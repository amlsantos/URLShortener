using Bogus;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Common;

public class DataGenerator : IDataGenerator
{
    public void GenerateData()
    {
        Users = GenerateUsers();
    }

    private List<User> GenerateUsers()
    {
        var user = new User("username", "username@email.com");
        var hasher = new PasswordHasher<User>();

        var userFaker = new Faker<User>()
            .CustomInstantiator(f => new User(f.Person.UserName, f.Person.Email))
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.UserName, f => f.Person.UserName)
            .RuleFor(t => t.NormalizedUserName, f => f.Person.UserName.ToUpper())
            .RuleFor(t => t.Email, f => f.Person.Email)
            .RuleFor(t => t.NormalizedEmail, f => f.Person.Email.ToLower())
            .RuleFor(t => t.PasswordHash, f => hasher.HashPassword(user, "password"))
            .RuleFor(t => t.EmailConfirmed, f => f.Random.Bool())
            .RuleFor(t => t.PhoneNumber, f => f.Person.Phone)
            .RuleFor(t => t.PhoneNumberConfirmed, f => f.Random.Bool())
            .RuleFor(t => t.TwoFactorEnabled, f => f.Random.Bool());

        return userFaker.GenerateBetween(30, 50);
    }

    public IReadOnlyList<User> Users { get; private set; }
}

public interface IDataGenerator
{
    public void GenerateData();
    
    IReadOnlyList<User> Users { get; }
}