using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;

namespace RealEstate.Test.Unitary.Validation.AddressDto;

public class AddressCreateValidationTest
{
    public static readonly AddressCreationValidator validator = new();

    [Theory]
    [CreateAddressDtoDataAttribute_Valid]
    public static void ShouldValidateAddressDto(CreateAddressDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [CreateAddressDtoDataAttribute_Invalid]
    public static void ShouldInvalidateAddressDto(CreateAddressDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
