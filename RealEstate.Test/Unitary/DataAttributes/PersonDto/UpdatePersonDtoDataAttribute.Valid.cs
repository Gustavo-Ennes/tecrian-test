using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class UpdatePersonDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullPerson() };
        yield return new object[] { PartialPerson() };
    }

    public static UpdatePersonDto FullPerson() =>
        new()
        {
            Id = 1,
            Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(),
            Email = "new@mail.com",
            Name = "Person 1",
            Phone = "3216549877"
        };

    public static UpdatePersonDto PartialPerson() => new() { Id = 1, Email = "new@mail.com", };
}
