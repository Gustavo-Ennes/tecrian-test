#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

public class CreateNaturalTenantDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { NaturalTenantWithoutPerson() };
        yield return new object[] { NaturalTenantPersonMissingData() };
    }

    public static CreateNaturalTenantDto NaturalTenantWithoutPerson()
    {
        CreateNaturalTenantDto dto =
            CreateNaturalTenantDtoTestDataAttribute_Valid.CreateNaturalTenantBaseDto();
        dto.Person = null;
        return dto;
    }

    public static CreateNaturalTenantDto NaturalTenantPersonMissingData()
    {
        CreateNaturalTenantDto dto =
            CreateNaturalTenantDtoTestDataAttribute_Valid.CreateNaturalTenantBaseDto();
        dto.Person.Email = null;
        return dto;
    }
}
