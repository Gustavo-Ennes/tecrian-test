using FluentValidation;

namespace RealEstate.Api.Validators.Base;

public class BaseValidator<T> : AbstractValidator<T>
    where T : class
{
    public BaseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
