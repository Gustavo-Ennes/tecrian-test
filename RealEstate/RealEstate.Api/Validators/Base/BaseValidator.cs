using FluentValidation;
using RealEstate.Shared.Dtos.Base;

namespace RealEstate.Api.Validators.Base;

public class CreateBaseValidator<T> : AbstractValidator<T>, IValidator<T>
    where T : class
{
    public CreateBaseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}

public class UpdateBaseValidator<T> : CreateBaseValidator<T>
    where T : UpdateBaseDto
{
    public UpdateBaseValidator()
        : base()
    {
        RuleFor(updateDto => updateDto.Id).NotEmpty().WithMessage("ID shouldn't be null.");
    }
}
