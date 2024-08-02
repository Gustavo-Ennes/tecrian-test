using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

public class CreateLegalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateLegalTenantBaseDto() };
    }

    public static CreateLegalTenantDto CreateLegalTenantBaseDto() => new() { CompanyId = 1 };
}
