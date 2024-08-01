using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.AddressDto;

public class UpdateAddressDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { AddressWithoutId() };
        yield return new object[] { AddressEmptyProp() };
        yield return new object[] { AddressNumberWithLetter() };
        yield return new object[] { AddressPostalCodeWithLetter() };
        yield return new object[] { AddressPostalCodeWrongLength2() };
    }

    public static UpdateAddressDto AddressWithoutId() => new() { Street = "Rua Augusta " };

    public static UpdateAddressDto AddressEmptyProp() => new() { Id = 1, Street = "" };

    public static UpdateAddressDto AddressNumberWithLetter() => new() { Id = 1, Number = "11a" };

    public static UpdateAddressDto AddressPostalCodeWithLetter() =>
        new() { Id = 1, PostalCode = "123123sd", };

    public static UpdateAddressDto AddressPostalCodeWrongLength() =>
        new() { Id = 1, PostalCode = "123123121", };

    public static UpdateAddressDto AddressPostalCodeWrongLength2() =>
        new() { Id = 1, PostalCode = "1233", };
}
