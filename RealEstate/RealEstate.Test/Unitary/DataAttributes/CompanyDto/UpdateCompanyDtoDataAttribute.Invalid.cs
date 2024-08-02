using System.Reflection;
using RealEstate.Shared.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.CompanyDto;

public class UpdateCompanyDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { CompanyWithoutId() };
        yield return new object[] { CompanyNameLessLength() };
        yield return new object[] { CompanyInvalidEmail() };
        yield return new object[] { CompanyPhoneWithLetter() };
        yield return new object[] { CompanyPhoneWrongLength() };
        yield return new object[] { CompanyPhoneWrongLength2() };
        yield return new object[] { CompanyCnpjWithLetters() };
        yield return new object[] { CompanyCnpjWrongLength() };
        yield return new object[] { CompanyCnpjWrongLength2() };
    }

    public static UpdateCompanyDto CompanyWithoutId() => new() { Name = "gustavo ennes" };

    public static UpdateCompanyDto CompanyNameLessLength() => new() { Id = 1, Name = "Nu" };

    public static UpdateCompanyDto CompanyInvalidEmail() => new() { Id = 1, Email = "nu@.com.net" };

    public static UpdateCompanyDto CompanyPhoneWithLetter() =>
        new() { Id = 1, Phone = "123123sd", };

    public static UpdateCompanyDto CompanyPhoneWrongLength() =>
        new() { Id = 1, Phone = "321654987", };

    public static UpdateCompanyDto CompanyPhoneWrongLength2() =>
        new() { Id = 1, Phone = "132165498721", };

    public static UpdateCompanyDto CompanyCnpjWithLetters() =>
        new() { Id = 1, Cnpj = "321654987654aa", };

    public static UpdateCompanyDto CompanyCnpjWrongLength() =>
        new() { Id = 1, Cnpj = "3216549876541", };

    public static UpdateCompanyDto CompanyCnpjWrongLength2() =>
        new() { Id = 1, Cnpj = "321654987654121", };
}
