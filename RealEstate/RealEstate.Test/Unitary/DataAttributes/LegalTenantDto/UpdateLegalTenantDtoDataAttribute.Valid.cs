using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

public class UpdateLegalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullLegalTenant() };
    }

    public static UpdateLegalTenantDto FullLegalTenant() => new() { Id = 1, CompanyId = 2, };
}
