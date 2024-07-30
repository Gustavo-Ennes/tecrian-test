using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.Domain.DataAttributes;

public class LegalTenantDtoTestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateLegalTenantBaseDto() };
    }

    public static CreateLegalTenantDto CreateLegalTenantBaseDto() =>
        new() { Company = CompanyDtoTestDataAttribute.CompanyDtoWithAddressComplement() };
}
