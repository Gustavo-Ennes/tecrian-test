using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;

namespace RealEstate.Api.Validators.Person;

public partial class PersonUpdateValidator : BaseValidator<UpdatePersonDto>
{
    public PersonUpdateValidator()
    {
        RuleFor(person => person.Name)
            .NotEmpty()
            .WithMessage("Person name shouldn't be null or empty")
            .Must(ValidatorFunctions.HaveLengthEnought)
            .WithMessage(
                "person name should have at least 8 characters length and two words minimum."
            )
            .When(person => person.Name != null);

        RuleFor(person => person.Email)
            .Must(ValidatorFunctions.BeAValidEmail)
            .WithMessage("person email should be a valid e-mail address")
            .When(person => person.Email != null);

        RuleFor(person => person.Phone)
            .NotEmpty()
            .WithMessage("person phone shouldn't be null or empty")
            .Must(ValidatorFunctions.BeAValidPhone)
            .WithMessage("person phone must have only numebers and have 10-11 length")
            .When(person => person.Phone != null);
    }
}
