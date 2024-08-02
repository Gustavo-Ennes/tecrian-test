using FluentValidation;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;
using RealEstate.Api.Validators.Person;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.Company;

public class CompanyCreationValidator : CreateBaseValidator<CreateCompanyDto>
{
    public CompanyCreationValidator()
    {
        RuleFor(company => company.Name)
            .NotNull()
            .WithMessage("Company name shouldn't be null or empty")
            .NotEmpty()
            .WithMessage("Company name shouldn't be null or empty")
            .Must(ValidatorFunctions.HaveLengthEnought_Person)
            .WithMessage(
                "company name should have at least 8 characters length and two words minimum."
            );

        RuleFor(company => company.Email)
            .NotNull()
            .WithMessage("Company email shouldn't be null or empty")
            .Must(ValidatorFunctions.BeAValidEmail)
            .WithMessage("Company email should be a valid e-mail address");

        RuleFor(company => company.Phone)
            .NotNull()
            .WithMessage("Company phone shouldn't be null or empty")
            .NotEmpty()
            .WithMessage("Company phone shouldn't be null or empty")
            .Must(ValidatorFunctions.BeAValidPhone)
            .WithMessage("Company phone must have only numebers and have 10-11 length");

        RuleFor(company => company.Cnpj)
            .NotNull()
            .Must(ValidatorFunctions.HaveCnpjLength)
            .WithMessage("Cnpj must have only digits and have length of 14.");

        RuleFor(company => company.RepresentantId)
            .NotNull()
            .WithMessage("Company representantId shouldn't be null or empty");

        RuleFor(company => company.AddressId)
            .NotNull()
            .WithMessage("Company address shouldn't be null or empty");
    }
}
