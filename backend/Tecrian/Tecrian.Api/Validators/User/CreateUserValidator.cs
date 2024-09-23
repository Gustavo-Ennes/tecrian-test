using FluentValidation;
using Tecrian.Shared.Dtos;

namespace Tecrian.Api.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserDto>, IValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Name)
            .NotNull()
            .WithMessage("Name shouldn't be null.")
            .NotEmpty()
            .WithMessage("Name shouldn't be empty.");
        RuleFor(user => user.Password)
            .NotNull()
            .WithMessage("Password shouldn't be null.")
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
            .WithMessage("Password should container at least 1 special character (!, ?, *, .).");
        RuleFor(user => user.Email)
            .NotNull()
            .WithMessage("Email shouldn't be null.")
            .NotEmpty()
            .WithMessage("Email shouldn't be empty.")
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Should be a valid email."); 

    }
}
