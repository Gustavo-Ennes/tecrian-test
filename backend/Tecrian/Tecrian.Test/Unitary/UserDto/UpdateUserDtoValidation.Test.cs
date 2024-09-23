using FluentValidation.TestHelper;
using Tecrian.Api.Validators.User;
using Tecrian.Shared.Dtos;
using Tecrian.Test.DataAttributes.UserDto;

namespace Tecrian.Test.Unitary.UserDto;

public class UserUpdateValidationTest
{
    public static readonly UpdateUserValidator validator = new();

    [Theory]
    [UpdateUserDtoDataAttribute_Valid]
    public static void ShouldValidateUserDto(UpdateUserDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [UpdateUserDtoDataAttribute_Invalid]
    public static void ShouldInvalidateUserDto(UpdateUserDto dto)
    {
        var result = validator.TestValidate(dto);
        result.ShouldHaveAnyValidationError();
    }
}
