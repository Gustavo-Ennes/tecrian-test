using System.Reflection;
using Tecrian.Shared.Dtos;
using Xunit.Sdk;

namespace Tecrian.Test.DataAttributes.LogInDto;

public class LoginDtoDataAttribute_Valid : DataAttribute
{
  public override IEnumerable<object[]> GetData(MethodInfo testMethod)
  {
    yield return new object[] { GetLoginDto() };
  }

  public static LoginDto GetLoginDto() =>
      new()
      {
        Email = "dave@mustaine.rock",
        Password = "1SenhaForte."
      };
}
