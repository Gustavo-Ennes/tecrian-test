using FluentValidation;
using RealEstate.Api.Dtos.Base;
using RealEstate.Api.Validators.Address;

namespace RealEstate.Api.Validators.Base;

public class TenantBaseUpdateValidator<T> : UpdateBaseValidator<T>
    where T : UpdateTenantDto
{
    public TenantBaseUpdateValidator()
        : base()
    {
        RuleFor(tenant => tenant.EndDate)
            .NotEmpty()
            .WithMessage("Tenant endDate shouldn't be empty if provided.")
            .When(tenant => tenant.EndDate != null);

        RuleFor(tenant => tenant.IsActive)
            .NotEmpty()
            .WithMessage("Tenant endDate should not be empty when provided.")
            .When(tenant => tenant.IsActive != null);

        RuleFor(tenant => tenant.Address)
            .SetInheritanceValidator(validator => validator.Add(new AddressUpdateValidator()));
    }
}
