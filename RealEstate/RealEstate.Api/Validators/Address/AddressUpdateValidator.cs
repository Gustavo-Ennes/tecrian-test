using FluentValidation;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.Address;

public class AddressUpdateValidator : UpdateBaseValidator<UpdateAddressDto>
{
    public AddressUpdateValidator()
        : base()
    {
        RuleFor(address => address.Street)
            .NotEmpty()
            .WithMessage("Address: Street shouldn't be null.")
            .When(address => address.Street != null);

        RuleFor(address => address.Number)
            .NotEmpty()
            .WithMessage("Address: Number shouldn't be null.")
            .Must(ValidatorFunctions.HasOnlyDigits)
            .WithMessage("Address: a number was expected.")
            .When(address => address.Number != null);

        RuleFor(address => address.Neighborhood)
            .NotEmpty()
            .WithMessage("Address: Neighborhood shouldn't be null.")
            .When(address => address.Neighborhood != null);

        RuleFor(address => address.City)
            .NotEmpty()
            .WithMessage("Address: City shouldn't be null.")
            .When(address => address.City != null);

        RuleFor(address => address.State)
            .NotEmpty()
            .WithMessage("Address: City shouldn't be null.")
            .When(address => address.State != null);

        RuleFor(address => address.PostalCode)
            .NotEmpty()
            .WithMessage("Address: PostalCode shouldn't be null.")
            .Must(ValidatorFunctions.BeAValidCep)
            .WithMessage("Address: postal code should have 8 digits.")
            .When(address => address.PostalCode != null);

        RuleFor(address => address.Country)
            .NotEmpty()
            .WithMessage("Address: Country shouldn't be null.")
            .When(address => address.Country != null);
    }
}
