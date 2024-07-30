using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.Domain.DataAttributes;

public class AddressDtoTestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { GetAddressWithoutComplement() };
        yield return new object[] { GetAddressWithoutComplement() };
    }

    public static AddressCreateDto GetAddressWithoutComplement() =>
        new()
        {
            Street = "Rua Augusta",
            Number = "11",
            Neighborhood = "Vila Olímpia",
            City = "São Paulo",
            Country = "Brasil",
            PostalCode = "15987654",
            State = "São Paulo"
        };

    public static AddressCreateDto GetAddressWithComplement()
    {
        AddressCreateDto dto = GetAddressWithoutComplement();
        dto.Complement = "Ala C, esquina";
        return dto;
    }
}
