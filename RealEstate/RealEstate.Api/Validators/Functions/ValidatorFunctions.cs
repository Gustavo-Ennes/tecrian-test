using System.Text.RegularExpressions;

namespace RealEstate.Api.Validators.Functions;

public partial class ValidatorFunctions
{
    public static readonly Regex EmailRegex = MyRegex();

    public static bool HaveLengthEnought_Person(string? name) =>
        name?.Trim().Length >= 8 && name.Split(' ').Length >= 2;

    public static bool HaveLengthEnought_Company(string? name) => name?.Trim().Length >= 3;

    public static bool BeAValidPhone(string? phone) =>
        HasOnlyDigits(phone) && phone?.Trim().Length >= 10 && phone?.Trim().Length <= 11;

    public static bool HaveCnpjLength(string? cnpj) =>
        HasOnlyDigits(cnpj) && cnpj?.Trim().Length == 14;

    public static bool BeAValidEmail(string? email) => EmailRegex.IsMatch(email ?? "");

    public static bool HasOnlyDigits(string? number) => number?.All(char.IsDigit) ?? false;

    public static bool BeAValidCep(string? postalCode) =>
        HasOnlyDigits(postalCode) && postalCode?.Trim().Length == 8;

    [GeneratedRegex(@"^[a-zA-Z][a-zA-Z0-9\.\-_]+@[0-9a-z]+\.[a-z]+(\.[a-z]+)*$")]
    public static partial Regex MyRegex();
}
