using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.CompanyDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

public class CreateLegalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateLegalTenantBaseDto() };
    }

    public static CreateLegalTenantDto CreateLegalTenantBaseDto() =>
        new() { Company = CreateCompanyDtoDataAttribute_Valid.CompanyDtoWithAddressComplement() };
}
