#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class CreatePersonDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { InvalidPersonDtoWithoutEmail() };
        yield return new object[] { InvalidPersonDtoWithoutPhone() };
    }

    //without name
    public static CreatePersonDto InvalidPersonDtoWithoutName()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.Person1();
        dto.Name = null;
        return dto;
    }

    // withour email
    public static CreatePersonDto InvalidPersonDtoWithoutEmail()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.Person1();
        dto.Email = null;
        return dto;
    }

    //without phone
    public static CreatePersonDto InvalidPersonDtoWithoutPhone()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.Person1();
        dto.Phone = null;
        return dto;
    }
}
