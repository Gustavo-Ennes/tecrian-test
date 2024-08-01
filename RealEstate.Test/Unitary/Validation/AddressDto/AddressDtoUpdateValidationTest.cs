using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Address;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;

namespace RealEstate.Test.Unitary.Validation.AddressDto;

public class AddressUpdateValidationTest
{
    public static readonly AddressUpdateValidator validator = new();

    [Theory]
    [UpdateAddressDtoDataAttribute_Valid]
    public static void ShouldValidateAddressDto(UpdateAddressDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [UpdateAddressDtoDataAttribute_Invalid]
    public static void ShouldInvalidateAddressDto(UpdateAddressDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
