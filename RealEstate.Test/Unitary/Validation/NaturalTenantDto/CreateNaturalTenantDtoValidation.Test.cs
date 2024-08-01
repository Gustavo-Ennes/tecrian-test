using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.NaturalTenant;
using RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

namespace RealEstate.Test.Unitary.Validation.NaturalTenantDto;

public class CreateNaturalTenantDtoTest
{
    public static readonly NaturalTenantCreationValidator validator = new();

    [Theory]
    [CreateNaturalTenantDtoTestDataAttribute_Valid]
    public static void ShouldValidateNaturalTenantDto(CreateNaturalTenantDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }    
    
    // natural tenant only has a Person inside it
    // and Tenant base has all default values when creating (except address, already has a validator)
}
