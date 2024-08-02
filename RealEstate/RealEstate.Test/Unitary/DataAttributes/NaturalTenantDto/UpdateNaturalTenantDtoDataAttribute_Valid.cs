using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

public class UpdateNaturalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullNaturalTenant() };
    }

    public static UpdateNaturalTenantDto FullNaturalTenant() => new() { Id = 1, PersonId = 2, };
}
