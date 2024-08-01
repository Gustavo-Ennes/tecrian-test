using System.Reflection;
using RealEstate.Api.Dtos;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using RealEstate.Test.Unitary.DataAttributes.CompanyDto;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;

public class UpdateLegalTenantDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullLegalTenant() };
        yield return new object[] { PartialLegalTenant() };
    }

    public static UpdateLegalTenantDto FullLegalTenant() =>
        new()
        {
            Id = 1,
            Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(),
            Company = UpdateCompanyDtoDataAttribute_Valid.FullCompany(),
        };

    public static UpdateLegalTenantDto PartialLegalTenant() =>
        new() { Id = 1, Address = UpdateAddressDtoDataAttribute_Valid.FullAddress(), };
}
