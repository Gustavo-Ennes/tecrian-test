using FluentValidation;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.Address;

public class AddressCreationValidator : CreateBaseValidator<CreateAddressDto>
{
    public AddressCreationValidator()
    {
        RuleFor(address => address.Street)
            .NotNull()
            .WithMessage("Address: Street shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: Street shouldn't be null.");

        RuleFor(address => address.Number)
            .NotNull()
            .WithMessage("Address: Number shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: Number shouldn't be null.")
            .Must(ValidatorFunctions.HasOnlyDigits)
            .WithMessage("Address: a number was expected.");

        RuleFor(address => address.Neighborhood)
            .NotNull()
            .WithMessage("Address: Neighborhood shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: Neighborhood shouldn't be null.");

        RuleFor(address => address.City)
            .NotNull()
            .WithMessage("Address: City shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: City shouldn't be null.");

        RuleFor(address => address.State)
            .NotNull()
            .WithMessage("Address: City shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: City shouldn't be null.");

        RuleFor(address => address.PostalCode)
            .NotNull()
            .WithMessage("Address: PostalCode shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: PostalCode shouldn't be null.")
            .Must(ValidatorFunctions.BeAValidCep)
            .WithMessage("Address: postal code should have 8 digits.");

        RuleFor(address => address.Country)
            .NotNull()
            .WithMessage("Address: Country shouldn't be empty.")
            .NotEmpty()
            .WithMessage("Address: Country shouldn't be null.");
    }
}
