#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using Tecrian.Shared.Dtos;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.UserDto;

public class CreateUserDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { UserWithoutName() };
        yield return new object[] { UserWithEmptyName() };
        yield return new object[] { UserWithoutEmail() };
        yield return new object[] { UserWithEmptyEmail() };
        yield return new object[] { UserWithInvalidEmail1() };
        yield return new object[] { UserWithInvalidEmail2() };
        yield return new object[] { UserWithoutPassword() };
        yield return new object[] { UserWithEmptyPassword() };
        yield return new object[] { UserPasswordWithoutCapitalLetter() };
        yield return new object[] { UserPasswordWithoutNonCapitalLetter() };
        yield return new object[] { UserPasswordWithoutDigit() };
        yield return new object[] { UserPasswordWithoutSpecialCharacter() };
        yield return new object[] { UserWithWrongPasswordLength() };
    }

    public static CreateUserDto UserWithoutName()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Name = null;
        return dto;
    }

    public static CreateUserDto UserWithEmptyName()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Name = "";
        return dto;
    }

    public static CreateUserDto UserWithoutEmail()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Email = null;
        return dto;
    }

    public static CreateUserDto UserWithEmptyEmail()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Email = "";
        return dto;
    }

    public static CreateUserDto UserWithInvalidEmail1()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Email = "dev.123@.com.#@";
        return dto;
    }

    public static CreateUserDto UserWithInvalidEmail2()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Email = "1@dev.c";
        return dto;
    }

    public static CreateUserDto UserWithoutPassword()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = null;
        return dto;
    }

    public static CreateUserDto UserWithEmptyPassword()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "";
        return dto;
    }

    public static CreateUserDto UserWithWrongPasswordLength()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "!Sen.";
        return dto;
    }

    public static CreateUserDto UserPasswordWithoutCapitalLetter()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "1!senha.";
        return dto;
    }

    public static CreateUserDto UserPasswordWithoutNonCapitalLetter()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "1!SENHA.";
        return dto;
    }

    public static CreateUserDto UserPasswordWithoutDigit()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "!SenhaNova.";
        return dto;
    }

    public static CreateUserDto UserPasswordWithoutSpecialCharacter()
    {
        CreateUserDto dto = CreateUserDtoDataAttribute_Valid.GetUser();
        dto.Password = "SenhaNova123";
        return dto;
    }
}
