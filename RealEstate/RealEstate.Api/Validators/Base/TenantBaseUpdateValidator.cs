using FluentValidation;
using RealEstate.Shared.Dtos.Base;

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
    }
}
