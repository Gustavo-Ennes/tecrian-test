using FluentValidation;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Api.Validators.Base;
using RealEstate.Api.Validators.Person;

namespace RealEstate.Api.Validators.NaturalTenant;

public partial class NaturalTenantCreationValidator : BaseValidator<CreateNaturalTenantDto>
{
    public NaturalTenantCreationValidator()
    {
        RuleFor(tenant => tenant.Person)
            .NotNull()
            .WithMessage("The person shouldn't be null to a natural tenant.")
            .SetInheritanceValidator(validator => validator.Add(new PersonCreationValidator()));

        RuleFor(tenant => tenant.Address)
            .NotNull()
            .WithMessage("The Address shouldn't be null to a natural tenant.")
            .SetInheritanceValidator(validator => validator.Add(new AddressCreationValidator()));
    }
}
