using FluentValidation;
using Tecrian.Shared.Dtos;

namespace Tecrian.Api.Validators.User;

public class CreateLoginValidator : AbstractValidator<LoginDto>, IValidator<LoginDto>
{
  public CreateLoginValidator()
  {
    RuleFor(user => user.Email)
        .NotNull()
        .WithMessage("Email shouldn't be null.")
        .NotEmpty()
        .WithMessage("Email shouldn't be empty.");

    RuleFor(user => user.Password)
        .NotNull()
        .WithMessage("Password shouldn't be null.")
        .NotEmpty()
        .WithMessage("Password shouldn't be empty.");

  }
}