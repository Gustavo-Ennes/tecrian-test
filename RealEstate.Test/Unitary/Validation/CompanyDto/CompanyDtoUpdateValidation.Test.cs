using FluentValidation.TestHelper;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.Company;
using RealEstate.Test.Unitary.DataAttributes.CompanyDto;

namespace RealEstate.Test.Unitary.Validation.CompanyDto;

public class CompanyUpdateDtoTest
{
    public static readonly CompanyUpdateValidator validator = new();

    [Theory]
    [UpdateCompanyDtoDataAttribute_Valid]
    public static void ShouldValidateCompanyDto(UpdateCompanyDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [UpdateCompanyDtoDataAttribute_Invalid]
    public static void ShouldInvalidateCompanyDto(UpdateCompanyDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
