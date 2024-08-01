#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

public class CreateLegalTenantDtoTestDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { LegalTenantWithoutCompany() };
        yield return new object[] { LegalTenantCompanyMissingData() };
    }

    public static CreateLegalTenantDto LegalTenantWithoutCompany()
    {
        CreateLegalTenantDto dto = CreateLegalTenantDtoDataAttribute_Valid.CreateLegalTenantBaseDto();
        dto.Company = null;
        return dto;
    }

    public static CreateLegalTenantDto LegalTenantCompanyMissingData()
    {
        CreateLegalTenantDto dto = CreateLegalTenantDtoDataAttribute_Valid.CreateLegalTenantBaseDto();
        dto.Company.Address = null;
        return dto;
    }
}
