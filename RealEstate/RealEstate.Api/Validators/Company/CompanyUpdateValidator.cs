using FluentValidation;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Functions;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.Company;

public class CompanyUpdateValidator : UpdateBaseValidator<UpdateCompanyDto>
{
    public CompanyUpdateValidator()
        : base()
    {
        RuleFor(company => company.Name)
            .NotEmpty()
            .WithMessage("Company name shouldn't be null or empty")
            .Must(ValidatorFunctions.HaveLengthEnought_Company)
            .WithMessage("company name should have at least 3 characters.")
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
            .NotEmpty()
            .WithMessage("Company Cnpj shouldn't be null or empty")
            .Must(ValidatorFunctions.HaveCnpjLength)
            .WithMessage("Cnpj must have only digits and have length of 14.")
            .When(company => company.Cnpj != null);

        RuleFor(company => company.RepresentantId)
            .NotEmpty()
            .WithMessage("Company representantId shouldn't be null or empty")
            .When(company => company.RepresentantId != null);
        ;

        RuleFor(company => company.AddressId)
            .NotEmpty()
            .WithMessage("Company addressId shouldn't be null or empty")
            .When(company => company.AddressId != null);
        ;
    }
}
