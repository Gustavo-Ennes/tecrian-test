using FluentValidation.TestHelper;
using RealEstate.Api.Validators.Person;
using RealEstate.Shared.Dtos;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;

namespace RealEstate.Test.Unitary.Validation.PersonDto;

public class CreatePersonDtoTest
{
    public static readonly PersonCreationValidator validator = new();

    [Theory]
    [CreatePersonDtoDataAttribute_Valid]
    public static void ShouldValidatePersonDto(CreatePersonDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [CreatePersonDtoDataAttribute_Invalid]
    public static void ShouldInvalidatePersonDto(CreatePersonDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
