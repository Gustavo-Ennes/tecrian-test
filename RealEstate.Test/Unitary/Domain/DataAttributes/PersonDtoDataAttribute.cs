using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.Domain.DataAttributes;

public class PersonDtoTestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { PersonDtoWithoutAddressComplement() };
        yield return new object[] { PersonDtoWithAddressComplement() };
    }

    public static CreatePersonDto PersonDtoWithoutAddressComplement() =>
        new()
        {
            Address = AddressDtoTestDataAttribute.GetAddressWithoutComplement(),
            Email = "person@email.com",
            Name = "Jhon Doe",
            Phone = "98765432154"
        };

    public static CreatePersonDto PersonDtoWithAddressComplement() =>
        new()
        {
            Address = AddressDtoTestDataAttribute.GetAddressWithComplement(),
            Email = "person@email.com",
            Name = "Jhon Doe",
            Phone = "98765432154"
        };
}
