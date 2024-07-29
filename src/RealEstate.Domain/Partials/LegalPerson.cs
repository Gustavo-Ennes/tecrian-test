namespace RealEstate.Domain.Partials;

public abstract class LegalPerson
{
    public string Cnpj { get; set; } = string.Empty;
    public string RazaoSocial {get;set;} = string.Empty;

}
