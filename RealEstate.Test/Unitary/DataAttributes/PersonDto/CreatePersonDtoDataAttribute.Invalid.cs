#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class CreatePersonDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { InvalidPersonDtoWithoutAddress() };
        yield return new object[] { InvalidPersonDtoWithoutEmail() };
        yield return new object[] { InvalidPersonDtoWithoutPhone() };
        yield return new object[] { InvalidPersonDtoWithoutAddress() };
    }

    //without name
    public static CreatePersonDto InvalidPersonDtoWithoutName()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement();
        dto.Name = null;
        return dto;
    }

    // withour email
    public static CreatePersonDto InvalidPersonDtoWithoutEmail()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement();
        dto.Email = null;
        return dto;
    }

    //without phone
    public static CreatePersonDto InvalidPersonDtoWithoutPhone()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement();
        dto.Phone = null;
        return dto;
    }

    // without address
    public static CreatePersonDto InvalidPersonDtoWithoutAddress()
    {
        CreatePersonDto dto = CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement();
        dto.Address = null;
        return dto;
    }
}
