using Bogus;
using Domain.Users;

namespace Persistence.Common;

public static class DataGenerator
{
    private const string Username = "username";
    private const string Email = "username@email.com";
    
    public static void SeedDatabase(ApplicationDbContext context)
    {
        SeedUsers(context);
    }

    private static void SeedUsers(ApplicationDbContext context)
    {
        if (context.Users.Any())
            return;
        
        var userFaker = new Faker<User>()
            .CustomInstantiator(f =>
                new User(UserName.Create(f.Person.UserName).Value, UserEmail.Create(f.Person.Email).Value))
            .RuleFor(t => t.Id, f => Guid.NewGuid());
        
        var users = userFaker.GenerateBetween(30, 50);
        users.Add(new User(UserName.Create(Username).Value, UserEmail.Create(Email).Value));
            
        context.AddRange(users);
        context.SaveChanges();
    }
}