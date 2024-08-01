using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Company;

namespace RealEstate.Api.Validators.LegalTenant;

public class LegalTenantUpdateValidator : TenantBaseUpdateValidator<UpdateLegalTenantDto>
{
    public LegalTenantUpdateValidator()
        : base()
    {
        RuleFor(tenant => tenant.Company)
            .SetInheritanceValidator(validator => validator.Add(new CompanyUpdateValidator()))
            .When(tenant => tenant.Company != null);
    }
}
