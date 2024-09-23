using FluentValidation;
using Tecrian.Shared.Dtos;

namespace Tecrian.Api.Validators.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>, IValidator<UpdateUserDto>
{
    public UpdateUserValidator()
        : base()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("Name shouldn't be empty.")
            .When(user => user.Name != null);

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email shouldn't be empty.")
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Should be a valid email.")
            .When(user => user.Email != null);

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password shouldn't be empty.")
            .MinimumLength(8)
            .WithMessage("Password should container at least 8 characters.")
            .Matches(@"[A-Z]")
            .WithMessage("Password should container at least 1 capital letter.")
            .Matches(@"[a-z]")
            .WithMessage("Password should container at least 1 non-capital letter.")
            .Matches(@"\d")
            .WithMessage("Password should container at least 1 digit.")
            .Matches(@"[\!\?\*\.]")
            .WithMessage("Password should container at least 1 special character (!, ?, *, .).")
            .When(user => user.Password != null);

    }
}
