using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Company;

namespace RealEstate.Api.Validators.LegalTenant;

public class LegalTenantCreationValidator : CreateBaseValidator<CreateLegalTenantDto>
{
    public LegalTenantCreationValidator()
    {
        RuleFor(tenant => tenant.Company)
            .NotNull()
            .WithMessage("The company shouldn't be null to a legal tenant.")
            .SetInheritanceValidator(validator => validator.Add(new CompanyCreationValidator()));
    }
}
