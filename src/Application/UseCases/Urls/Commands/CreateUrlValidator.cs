using FluentValidation;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlValidator : AbstractValidator<CreateUrl>
{
    public CreateUrlValidator()
    {
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.Url).NotNull();

        RuleFor(x => x.Url)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.Url))
            .WithMessage("Please enter a valid url");
    }
}