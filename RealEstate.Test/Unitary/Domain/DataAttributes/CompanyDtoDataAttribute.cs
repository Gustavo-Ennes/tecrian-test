using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.Domain.DataAttributes;

public class CompanyDtoTestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CompanyDtoWithoutAddressComplement() };
        yield return new object[] { CompanyDtoWithAddressComplement() };
    }

    public static CreateCompanyDto CompanyDtoWithoutAddressComplement() =>
        new()
        {
            Address = AddressDtoTestDataAttribute.GetAddressWithoutComplement(),
            Email = "person@email.com",
            Name = "Comapny x",
            Phone = "98765432154",
            Representant = PersonDtoTestDataAttribute.PersonDtoWithoutAddressComplement()
        };

    public static CreateCompanyDto CompanyDtoWithAddressComplement() =>
        new()
        {
            Address = AddressDtoTestDataAttribute.GetAddressWithComplement(),
            Email = "person@email.com",
            Name = "Company z",
            Phone = "98765432154",
            Representant = PersonDtoTestDataAttribute.PersonDtoWithoutAddressComplement()
        };
}
