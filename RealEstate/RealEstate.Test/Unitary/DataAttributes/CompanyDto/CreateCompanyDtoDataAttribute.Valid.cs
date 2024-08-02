using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.CompanyDto;

public class CreateCompanyDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CompanyDtoWithoutAddressComplement() };
        yield return new object[] { CompanyDtoWithAddressComplement() };
    }

    public static CreateCompanyDto CompanyDtoWithoutAddressComplement() =>
        new()
        {
            AddressId = 1,
            Email = "person@email.com",
            Name = "Comapny x",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            RepresentantId = 1
        };

    public static CreateCompanyDto CompanyDtoWithAddressComplement() =>
        new()
        {
            AddressId = 1,
            Email = "person@email.com",
            Name = "Company z",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            RepresentantId = 1
        };
}
