using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class CreatePersonDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { PersonDtoWithoutAddressComplement() };
        yield return new object[] { PersonDtoWithAddressComplement() };
    }

    public static CreatePersonDto PersonDtoWithoutAddressComplement() =>
        new()
        {
            Address = CreateAddressDtoDataAttribute_Valid.GetAddressWithoutComplement(),
            Email = "person@email.com",
            Name = "Jhon Doe",
            Phone = "3216549877"
        };

    public static CreatePersonDto PersonDtoWithAddressComplement() =>
        new()
        {
            Address = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement(),
            Email = "person@email.com",
            Name = "Jhon Doe",
            Phone = "3216549877"
        };
}
