using FluentValidation;

namespace Application.UseCases.Urls.Queries;

public class GetUrlValidator : AbstractValidator<GetUrl>
{
    public GetUrlValidator()
    {
        RuleFor(x => x.ShortUrl).NotEmpty();
        RuleFor(x => x.ShortUrl).NotNull();

        RuleFor(x => x.ShortUrl)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.ShortUrl))
            .WithMessage("Please enter a valid url");
    }
}