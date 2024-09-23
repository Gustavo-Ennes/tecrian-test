using FluentValidation.TestHelper;
using Tecrian.Api.Validators.User;
using Tecrian.Shared.Dtos;
using Tecrian.Test.DataAttributes.UserDto;

namespace Tecrian.Test.Unitary.UserDto;

public class UserCreateValidationTest
{
    public static readonly CreateUserValidator validator = new();

    [Theory]
    [CreateUserDtoDataAttribute_Valid]
    public static void ShouldValidateUserDto(CreateUserDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [CreateUserDtoDataAttribute_Invalid]
    public static void ShouldInvalidateUserDto(CreateUserDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
