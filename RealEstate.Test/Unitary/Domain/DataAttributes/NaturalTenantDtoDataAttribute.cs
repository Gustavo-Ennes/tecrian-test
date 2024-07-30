using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.Domain.DataAttributes;

public class NaturalTenantDtoTestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateNaturalTenantBaseDto() };
    }

    public static CreateNaturalTenantDto CreateNaturalTenantBaseDto() =>
        new() { Person = PersonDtoTestDataAttribute.PersonDtoWithAddressComplement() };
}
