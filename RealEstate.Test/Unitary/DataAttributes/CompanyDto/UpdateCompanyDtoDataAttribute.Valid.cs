using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.CompanyDto;

public class UpdateCompanyDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullCompany() };
        yield return new object[] { PartialCompany() };
        yield return new object[] { JustOneProp() };
    }

    public static UpdateCompanyDto FullCompany() =>
        new()
        {
            Id = 1,
            Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(),
            Email = "person@email.com",
            Name = "Company z",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            Representant = UpdatePersonDtoDataAttribute_Valid.FullPerson()
        };

    public static UpdateCompanyDto PartialCompany() =>
        new()
        {
            Id = 1,
            Email = "person@email.com",
            Name = "Company z",
            Phone = "98765432154",
        };

    public static UpdateCompanyDto JustOneProp() => new() { Id = 1, Name = "Company z", };
}
