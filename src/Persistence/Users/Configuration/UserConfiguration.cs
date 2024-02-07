using Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Users.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasIndex(e => e.Id).IsUnique();
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).IsRequired();

        entity.Ignore(e => e.UserEmail);
        entity.Ignore(e => e.Name);
    }
}