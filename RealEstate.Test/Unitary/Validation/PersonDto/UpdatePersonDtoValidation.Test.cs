using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Person;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;

namespace RealEstate.Test.Unitary.Validation.PersonDto;

public class PersonUpdateValidationTest
{
    public static readonly PersonUpdateValidator validator = new();

    [Theory]
    [UpdatePersonDtoDataAttribute_Valid]
    public static void ShouldValidatePersonDto(UpdatePersonDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [UpdatePersonDtoDataAttribute_Invalid]
    public static void ShouldInvalidatePersonDto(UpdatePersonDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
