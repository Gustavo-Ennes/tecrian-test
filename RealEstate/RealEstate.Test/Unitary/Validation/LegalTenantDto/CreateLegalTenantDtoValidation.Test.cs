using FluentValidation.TestHelper;
using RealEstate.Api.Validators.LegalTenant;
using RealEstate.Shared.Dtos;
using RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

namespace RealEstate.Test.Unitary.Validation.LegalTenantDto;

public class CreateLegalTenantDtoTest
{
    public static readonly LegalTenantCreationValidator validator = new();

    [Theory]
    [CreateLegalTenantDtoDataAttribute_Valid]
    public static void ShouldValidateLegalTenantDto(CreateLegalTenantDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    // legal tenant only has a Company inside it
    // and Tenant base has all default values when creating (except address, already has a validator)
}
