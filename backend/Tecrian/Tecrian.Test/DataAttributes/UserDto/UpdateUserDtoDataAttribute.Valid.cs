using System.Reflection;
using Tecrian.Shared.Dtos;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.UserDto;

public class UpdateUserDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { FullUser() };
        yield return new object[] { PartialUser() };
        yield return new object[] { JustOneProp() };
    }

    public static UpdateUserDto FullUser() =>
        new()
        {
            Id = 1,
            Name = "John Petrucci",
            Email = "john@dreamtheater.com",
            Password = "123Jhon!."

        };

    public static UpdateUserDto PartialUser() =>
        new()
        {
            Id = 1,
            Name = "John Petrucci",
            Email = "john@dreamtheater.com",
        };

    public static UpdateUserDto JustOneProp() => new()
    {
        Id = 1,
        Name = "John Petrucci",
    };
}
