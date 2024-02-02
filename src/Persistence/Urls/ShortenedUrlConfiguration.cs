using Domain.Urls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Urls;

public class ShortenedUrlConfiguration : IEntityTypeConfiguration<ShortenedUrl>
{
    public void Configure(EntityTypeBuilder<ShortenedUrl> entity)
    {
        entity.ToTable("ShortenedUrls", "dbo");
        
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).IsRequired();

        var longUrl = entity.Property(x => x.LongUrl);
        longUrl.IsRequired();
        longUrl.HasConversion(x => x.AsString(), x => new Url(x));
        
        var shortUrl = entity.Property(x => x.ShortUrl);
        shortUrl.IsRequired();
        shortUrl.HasConversion(x => x.AsString(), x => new Url(x));

        var code = entity.Property(x => x.Code);
        code.IsRequired();
        code.HasConversion(x => x.AsString(), x => new Code(x));

        var date = entity.Property(x => x.CreatedOn);
        date.IsRequired();
    }
}