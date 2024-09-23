using System.Reflection;
using Tecrian.Shared.Dtos;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.UserDto;

public class UpdateUserDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { UserEmptyEmail() };
        yield return new object[] { UserInvalidEmail() };
        yield return new object[] { UserEmptyPassword() };
        yield return new object[] { UserWrongLengthPassword() };
        yield return new object[] { UserPasswordWithoutCapitalLetter() };
        yield return new object[] { UserPasswordWithoutNonCapitalLetter() };
        yield return new object[] { UserPasswordWithoutDigit() };
        yield return new object[] { UserPasswordWithoutSpecialCharacter() };
    }

    public static UpdateUserDto UserEmptyEmail() => new() { Id = 1, Email = "" };

    public static UpdateUserDto UserInvalidEmail() => new() { Id = 1, Email = "asd@12.Com22" };

    public static UpdateUserDto UserEmptyPassword() => new() { Id = 1, Password = "" };

    public static UpdateUserDto UserWrongLengthPassword() => new() { Id = 1, Password = "12S2!." };

    public static UpdateUserDto UserPasswordWithoutCapitalLetter() => new() { Id = 1, Password = "!senhaforte.1" };

    public static UpdateUserDto UserPasswordWithoutNonCapitalLetter() => new() { Id = 1, Password = "!SENHAFORTE.1" };

    public static UpdateUserDto UserPasswordWithoutDigit() => new() { Id = 1, Password = "!SENHAFORTE.!" };

    public static UpdateUserDto UserPasswordWithoutSpecialCharacter() => new() { Id = 1, Password = "1senhaFORTE" };
}
