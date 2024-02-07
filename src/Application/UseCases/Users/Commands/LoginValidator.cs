using FluentValidation;

namespace Application.UseCases.Users.Commands;

public class LoginValidator : AbstractValidator<Login>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Email).NotNull();
        RuleFor(x => x.Email).EmailAddress()
            .WithMessage("Please enter a valid email address");
    }
}