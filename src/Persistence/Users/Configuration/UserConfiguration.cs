using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Users.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasIndex(e => e.Id).IsUnique();
        entity.HasKey(e => e.Id);
        
        var name = entity.OwnsOne(e => e.Name);
        name.Property(e => e.Value).HasColumnName("UserName_Value");
        name.Property(e => e.NormalizedValue).HasColumnName("UserName_NormalizedValue");
        
        var email = entity.OwnsOne(e => e.UserEmail);
        email.Property(e => e.Value).HasColumnName("Email_Value");
        email.Property(e => e.NormalizedValue).HasColumnName("Email_NormalizedValue");
        
        // ignore primitive obsession properties
        entity.Ignore(e => e.PhoneNumber);
        entity.Ignore(e => e.PasswordHash);
        entity.Ignore(e => e.SecurityStamp);
        entity.Ignore(e => e.LockoutEnd);
        entity.Ignore(e => e.EmailConfirmed);
        entity.Ignore(e => e.LockoutEnabled);
        entity.Ignore(e => e.AccessFailedCount);
        entity.Ignore(e => e.PhoneNumberConfirmed);
        entity.Ignore(e => e.TwoFactorEnabled);
    }
}