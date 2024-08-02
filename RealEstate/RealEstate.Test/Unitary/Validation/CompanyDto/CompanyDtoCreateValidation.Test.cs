using FluentValidation.TestHelper;
using RealEstate.Api.Validators.Company;
using RealEstate.Shared.Dtos;
using RealEstate.Test.Unitary.DataAttributes.CompanyDto;

namespace RealEstate.Test.Unitary.Validation.CompanyDto;

public class CompanyCreateDtoTest
{
    public static readonly CompanyCreationValidator validator = new();

    [Theory]
    [CreateCompanyDtoDataAttribute_Valid]
    public static void ShouldValidateCompanyDto(CreateCompanyDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [CreateCompanyDtoDataAttribute_Invalid]
    public static void ShouldInvalidateCompanyDto(CreateCompanyDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
