#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using System.Reflection;
using Tecrian.Shared.Dtos;
using Tecrian.Test.DataAttributes.UserDto;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.LogInDto;

public class LoginDtoDataAttribute_Invalid : DataAttribute
{
  public override IEnumerable<object[]> GetData(MethodInfo testMethod)
  {
    yield return new object[] { LoginWithoutEmail() };
    yield return new object[] { LoginWithoutPassword() };
    yield return new object[] { LoginWithEmptyEmail() };
    yield return new object[] { LoginWithEmptyPassword() };
  }

  public static LoginDto LoginWithoutEmail()
  {
    LoginDto dto = LoginDtoDataAttribute_Valid.GetLoginDto();
    dto.Email = null;
    return dto;
  }

  public static LoginDto LoginWithoutPassword()
  {
    LoginDto dto = LoginDtoDataAttribute_Valid.GetLoginDto();
    dto.Password = null;
    return dto;
  }

  public static LoginDto LoginWithEmptyEmail()
  {
    LoginDto dto = LoginDtoDataAttribute_Valid.GetLoginDto();
    dto.Email = "";
    return dto;
  }

  public static LoginDto LoginWithEmptyPassword()
  {
    LoginDto dto = LoginDtoDataAttribute_Valid.GetLoginDto();
    dto.Password = "";
    return dto;
  }

  public static LoginDto LoginWithoutUser()
  {
    // this guy is in test db
    CreateUserDto userDto = CreateUserDtoDataAttribute_Valid.GetUser();
    return new LoginDto() {Email = "some@other.email", Password = userDto.Password};
  }

  public static LoginDto LoginWithWrongPassword()
  {
    CreateUserDto userDto = CreateUserDtoDataAttribute_Valid.GetUser();
    return new LoginDto() { Email = userDto.Email, Password = "SomeOtherPassword" };
  }

}