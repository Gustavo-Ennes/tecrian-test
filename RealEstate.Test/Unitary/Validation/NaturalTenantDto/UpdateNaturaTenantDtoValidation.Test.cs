using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.NaturalTenant;
using RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

namespace RealEstate.Test.Unitary.Validation.LegalTenantDto;

public class UpdateNaturalTenantDtoTest
{
    public static readonly NaturalTenantUpdateValidator validator = new();

    [Theory]
    [UpdateNaturalTenantDtoDataAttribute_Valid]
    public static void ShouldValidateLegalTenantDto(UpdateNaturalTenantDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
