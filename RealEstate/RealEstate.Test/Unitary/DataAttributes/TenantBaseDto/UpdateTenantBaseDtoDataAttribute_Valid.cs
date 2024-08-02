using System.Reflection;
using RealEstate.Shared.Dtos.Base;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.CompanyDto;

public class UpdateTenantBaseDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullBaseTenant() };
        yield return new object[] { PartialBaseTenant() };
    }

    public static UpdateTenantDto FullBaseTenant() =>
        new()
        {
            Id = 1,
            EndDate = DateTime.Now,
            IsActive = false,
        };

    public static UpdateTenantDto PartialBaseTenant() => new() { Id = 1, EndDate = DateTime.Now, };
}
