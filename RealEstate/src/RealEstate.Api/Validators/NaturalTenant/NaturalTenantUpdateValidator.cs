using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Person;

namespace RealEstate.Api.Validators.NaturalTenant;

public class NaturalTenantUpdateValidator : TenantBaseUpdateValidator<UpdateNaturalTenantDto>
{
    public NaturalTenantUpdateValidator()
        : base()
    {
        RuleFor(tenant => tenant.Person)
            .SetInheritanceValidator(validator => validator.Add(new PersonUpdateValidator()))
            .When(tenant => tenant.Person != null);
        ;
    }
}
