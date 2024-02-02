using FluentValidation;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlShortenerValidator : AbstractValidator<CreateUrlShortener>
{
    public CreateUrlShortenerValidator()
    {
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.Url).NotNull();

        RuleFor(x => x.Url)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.Url))
            .WithMessage("Please enter a valid url");
    }
}