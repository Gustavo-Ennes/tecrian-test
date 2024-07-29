using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;
using RealEstate.Api.Validators.Person;

namespace RealEstate.Api.Validators.Company;

public class CompanyUpdateValidator : BaseValidator<UpdateCompanyDto>
{
    public CompanyUpdateValidator()
    {
        RuleFor(company => company.Name)
            .NotEmpty()
            .WithMessage("Company name shouldn't be null or empty")
            .Must(ValidatorFunctions.HaveLengthEnought)
            .WithMessage(
                "company name should have at least 8 characters length and two words minimum."
            )
            .When(company => company.Name != null);

        RuleFor(company => company.Email)
            .Must(ValidatorFunctions.BeAValidEmail)
            .WithMessage("Company email should be a valid e-mail address")
            .When(company => company.Email != null);

        RuleFor(company => company.Phone)
            .NotEmpty()
            .WithMessage("Company phone shouldn't be null or empty")
            .Must(ValidatorFunctions.BeAValidPhone)
            .WithMessage("Company phone must have only numebers and have 10-11 length")
            .When(company => company.Phone != null);

        RuleFor(company => company.Cnpj)
            .Must(ValidatorFunctions.HaveCnpjLength)
            .WithMessage("Cnpj must have only digits and have length of 14.")
            .When(company => company.Cnpj != null);

        RuleFor(company => company.Representant)
            .SetInheritanceValidator(validator => validator.Add(new PersonUpdateValidator()))
            .When(company => company.Representant != null);
        ;

        RuleFor(company => company.Address)
            .SetInheritanceValidator(validator => validator.Add(new AddressUpdateValidator()))
            .When(company => company.Address != null);
        ;
    }
}
