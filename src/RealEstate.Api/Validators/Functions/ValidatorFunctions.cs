using System.Text.RegularExpressions;

namespace RealEstate.Api.Validators.Functions;

public partial class ValidatorFunctions
{

    public static readonly Regex EmailRegex = MyRegex();
    public static bool HaveLengthEnought(string? name) =>
        name?.Trim().Length > 8 && name.Split(' ').Length >= 2;

    public static bool BeAValidPhone(string? phone) =>
        phone?.Trim().Length >= 10 && phone.Trim().Length <= 11;

    public static bool HaveCnpjLength(string? cnpj) => cnpj?.Trim().Length == 14;

    public static bool BeAValidEmail(string? email) => EmailRegex.IsMatch(email ?? "");

    public static bool HasOnlyDigits(string? number) => int.TryParse(number?.Trim(), out _);

    public static bool BeAValidCep(string? postalCode) =>
        HasOnlyDigits(postalCode) && postalCode?.Trim().Length == 8;

    [GeneratedRegex(@"^[^@\s]+@[^@\su]+\.[^@\s]+$")]
    public static partial Regex MyRegex();

}