using System.Reflection;
using RealEstate.Api.Dtos;
using Xunit.Sdk;

namespace RealEstate.Test.Unitary.DataAttributes.PersonDto;

public class UpdatePersonDtoDataAttribute_Invalid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { PersonWithoutId() };
        yield return new object[] { PersonNameOneWord() };
        yield return new object[] { PersonNameMinimumLength() };
        yield return new object[] { PersonWrongEmail() };
        yield return new object[] { PersonPhoneWithLetter() };
        yield return new object[] { PersonPhoneMinimumLength() };
        yield return new object[] { PersonPhoneMinimumLength2() };
    }

    public static UpdatePersonDto PersonWithoutId() => new() { Name = "gustavo ennes" };

    public static UpdatePersonDto PersonNameOneWord() => new() { Id = 1, Name = "abracadabra" };

    public static UpdatePersonDto PersonNameMinimumLength() => new() { Id = 1, Name = "seu ze", };

    public static UpdatePersonDto PersonWrongEmail() => new() { Id = 1, Email = "ggg@.net.123" };

    public static UpdatePersonDto PersonPhoneWithLetter() => new() { Id = 1, Phone = "123123123a" };

    public static UpdatePersonDto PersonPhoneMinimumLength() =>
        new() { Id = 1, Phone = "123123123" };

    public static UpdatePersonDto PersonPhoneMinimumLength2() =>
        new() { Id = 1, Phone = "123123123121" };
}
