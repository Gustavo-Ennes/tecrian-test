using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.AddressDto;

public class UpdateAddressDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullAddress() };
        yield return new object[] { PartialAddress() };
        yield return new object[] { JustOneProp() };
    }

    public static UpdateAddressDto FullAddress() =>
        new()
        {
            Id = 1,
            Street = "Rua Saravá",
            Number = "111",
            Neighborhood = "Vila Matilde",
            City = "Rio de Janeiro",
            Country = "Holanda",
            PostalCode = "22222222",
            State = "Rio de Janeiro",
            Complement = "Beco A"
        };

    public static UpdateAddressDto PartialAddress() =>
        new()
        {
            Id = 1,
            Street = "Rua Saravá",
            Number = "111",
            Neighborhood = "Vila Matilde",
        };

    public static UpdateAddressDto JustOneProp() => new() { Id = 1, Street = "Rua Saravá", };
}
