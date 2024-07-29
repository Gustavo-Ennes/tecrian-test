using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Person;

namespace RealEstate.Api.Validators.NaturalTenant;

public partial class NaturalTenantUpdateValidator : BaseValidator<UpdateNaturalTenantDto>
{
    public NaturalTenantUpdateValidator()
    {
        RuleFor(tenant => tenant.Person)
            .SetInheritanceValidator(validator => validator.Add(new PersonUpdateValidator()))
            .When(tenant => tenant.Person != null);

        RuleFor(tenant => tenant.Address)
            .SetInheritanceValidator(validator => validator.Add(new AddressUpdateValidator()))
            .When(tenant => tenant.Address != null);
        ;
    }
}
