using FluentValidation;
using RealEstate.Api.Validators.Base;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Validators.NaturalTenant;

public class NaturalTenantUpdateValidator : TenantBaseUpdateValidator<UpdateNaturalTenantDto>
{
    public NaturalTenantUpdateValidator()
        : base()
    {
        RuleFor(tenant => tenant.PersonId)
            .NotNull()
            .WithMessage("The personId shouldn't be null to a natural tenant.")
            .When(tenant => tenant.PersonId != null);
        ;
    }
}
