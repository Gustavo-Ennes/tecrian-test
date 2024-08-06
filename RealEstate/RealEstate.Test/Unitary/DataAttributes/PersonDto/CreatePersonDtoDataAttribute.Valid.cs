using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class CreatePersonDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Person1() };
        yield return new object[] { Person2() };
    }

    public static CreatePersonDto Person1() =>
        new()
        {
            AddressId = 1,
            Email = "mary@email.com",
            Name = "Mary Doe",
            Phone = "3216549872"
        };

    public static CreatePersonDto Person2() =>
        new()
        {
            AddressId = 1,
            Email = "jhon@email.com",
            Name = "Jhon Doe",
            Phone = "3216549877"
        };
}
