using System.Reflection;
using Tecrian.Shared.Dtos;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.UserDto;

public class CreateUserDtoDataAttribute_Valid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { GetUser() };
    }

    public static CreateUserDto GetUser() =>
        new()
        {
            Name = "Dave Mustaine",
            Email = "dave@mustaine.rock",
            Password = "1SenhaForte."
        };
}
