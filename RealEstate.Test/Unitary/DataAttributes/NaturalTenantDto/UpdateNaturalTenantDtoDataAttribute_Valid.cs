using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;

public class UpdateNaturalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullNaturalTenant() };
        yield return new object[] { PartialNaturalTenant() };
    }

    public static UpdateNaturalTenantDto FullNaturalTenant() =>
        new()
        {
            Id = 1,
            Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(),
            Person = UpdatePersonDtoDataAttribute_Valid.FullPerson(),
        };

    public static UpdateNaturalTenantDto PartialNaturalTenant() =>
        new() { Id = 1, Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(), };
}
