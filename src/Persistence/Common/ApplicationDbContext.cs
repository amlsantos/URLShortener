using System.Reflection;
using Domain.Urls;
using Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Common.Configurations;

namespace Persistence.Common;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly IDataGenerator _initializer;
    private readonly ConnectionStringsOptions _options;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions, IDataGenerator initializer, IOptions<ConnectionStringsOptions> options) : base(contextOptions)
    {
        _initializer = initializer;
        _options = options.Value;
    }

    public DbSet<ShortenedUrl> ShortenedUrls { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (builder.IsConfigured)
            return;

        builder.UseSqlServer(_options.DefaultConnection);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        _initializer.GenerateData();
        builder.Entity<User>().HasData(_initializer.Users);
    }
}