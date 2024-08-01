using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;
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
            Address = CreateAddressDtoDataAttribute_Valid.GetAddressWithoutComplement(),
            Email = "person@email.com",
            Name = "Comapny x",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            Representant = CreatePersonDtoDataAttribute_Valid.PersonDtoWithoutAddressComplement()
        };

    public static CreateCompanyDto CompanyDtoWithAddressComplement() =>
        new()
        {
            Address = CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement(),
            Email = "person@email.com",
            Name = "Company z",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            Representant = CreatePersonDtoDataAttribute_Valid.PersonDtoWithoutAddressComplement()
        };
}
