using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Company;

namespace RealEstate.Api.Validators.LegalTenant;

public partial class LegalTenantCreationValidator : BaseValidator<CreateLegalTenantDto>
{
    public LegalTenantCreationValidator()
    {
        RuleFor(tenant => tenant.Company)
            .NotNull()
            .WithMessage("The company shouldn't be null to a legal tenant.")
            .SetInheritanceValidator(validator => validator.Add(new CompanyCreationValidator()));

        RuleFor(tenant => tenant.RepresentantId)
            .NotNull()
            .WithMessage("Representant Id should be a number.");

        RuleFor(tenant => tenant.Address)
            .NotNull()
            .SetInheritanceValidator(validator => validator.Add(new AddressCreationValidator()));
    }
}
