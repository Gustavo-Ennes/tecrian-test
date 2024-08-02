using FluentValidation.TestHelper;
using RealEstate.Api.Validators.LegalTenant;
using RealEstate.Shared.Dtos;
using RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

namespace RealEstate.Test.Unitary.Validation.LegalTenantDto;

public class UpdateLegalTenantDtoTest
{
    public static readonly LegalTenantUpdateValidator validator = new();

    [Theory]
    [UpdateLegalTenantDtoDataAttribute_Valid]
    public static void ShouldValidateLegalTenantDto(UpdateLegalTenantDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
