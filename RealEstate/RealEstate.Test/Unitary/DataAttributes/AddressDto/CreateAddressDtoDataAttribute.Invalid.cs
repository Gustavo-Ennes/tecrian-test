#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.AddressDto;

public class CreateAddressDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { AddressWithoutStreet() };
        yield return new object[] { AddressWithoutNumber() };
        yield return new object[] { AddressWithoutNeighborhood() };
        yield return new object[] { AddressWithoutPostalCode() };
        yield return new object[] { AddressWithoutState() };
        yield return new object[] { AddressWithoutCountry() };
        yield return new object[] { AddressNumberWithLetters() };
        yield return new object[] { AddressPostalCodeWithWrongLength() };
        yield return new object[] { AddressPostalCodeWithLetters() };
    }

    public static CreateAddressDto AddressWithoutStreet()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.Street = null;
        return dto;
    }

    public static CreateAddressDto AddressWithoutNumber()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.Number = null;
        return dto;
    }

    public static CreateAddressDto AddressNumberWithLetters()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.Number = null;
        return dto;
    }

    public static CreateAddressDto AddressWithoutNeighborhood()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.Neighborhood = null;
        return dto;
    }

    public static CreateAddressDto AddressWithoutPostalCode()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.PostalCode = null;
        return dto;
    }

    public static CreateAddressDto AddressPostalCodeWithWrongLength()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.PostalCode = "1233";
        return dto;
    }

    public static CreateAddressDto AddressPostalCodeWithLetters()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.PostalCode = "1233aa";
        return dto;
    }

    public static CreateAddressDto AddressWithoutState()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.State = null;
        return dto;
    }

    public static CreateAddressDto AddressWithoutCountry()
    {
        CreateAddressDto dto = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement();
        dto.Country = null;
        return dto;
    }
}
