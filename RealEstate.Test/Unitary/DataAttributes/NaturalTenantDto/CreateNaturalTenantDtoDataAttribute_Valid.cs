using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

public class CreateNaturalTenantDtoTestDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CreateNaturalTenantBaseDto() };
    }

    public static CreateNaturalTenantDto CreateNaturalTenantBaseDto() =>
        new() { Person = CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement() };
}
