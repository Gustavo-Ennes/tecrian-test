using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

public class CreateNaturalTenantDtoTestDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateNaturalTenantBaseDto() };
    }

    public static CreateNaturalTenantDto CreateNaturalTenantBaseDto() => new() { PersonId = 1 };
}
