using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Company;

namespace RealEstate.Api.Validators.LegalTenant;

public partial class LegalTenantUpdateValidator : BaseValidator<UpdateLegalTenantDto>
{
    public LegalTenantUpdateValidator()
    {
        RuleFor(tenant => tenant.Company)
            .SetInheritanceValidator(validator => validator.Add(new CompanyUpdateValidator()))
            .When(tenant => tenant.Company != null);

        RuleFor(tenant => tenant.RepresentantId)
            .NotEmpty()
            .WithMessage("Representant Id should be a number.")
            .When(tenant => tenant.Company != null);

        RuleFor(tenant => tenant.Address)
            .NotEmpty()
            .WithMessage("Tenant address shouldn't be null.")
            .SetInheritanceValidator(validator => validator.Add(new AddressUpdateValidator()))
            .When(tenant => tenant.Company != null);
    }
}
