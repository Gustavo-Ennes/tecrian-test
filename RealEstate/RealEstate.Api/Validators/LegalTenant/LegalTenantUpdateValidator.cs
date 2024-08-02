using FluentValidation;
using RealEstate.Api.Validators.Base;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.LegalTenant;

public class LegalTenantUpdateValidator : TenantBaseUpdateValidator<UpdateLegalTenantDto>
{
    public LegalTenantUpdateValidator()
        : base()
    {
        RuleFor(tenant => tenant.CompanyId)
            .NotNull()
            .WithMessage("The companyId shouldn't be null to a legal tenant.")
            .When(tenant => tenant.CompanyId != null);
    }
}
