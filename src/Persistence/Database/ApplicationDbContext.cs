using System.Reflection;
using Domain.Urls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence.Database;

public class ApplicationDbContext : DbContext
{
    private readonly ConnectionStringsOptions _options;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions, IOptions<ConnectionStringsOptions> options) 
        : base(contextOptions) => _options = options.Value;

    public DbSet<ShortenedUrl> ShortenedUrls { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlServer(_options.DefaultConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}