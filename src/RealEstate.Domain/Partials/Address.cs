namespace RealEstate.Domain.Partials;

public class Address(
    string street,
    string number,
    string complement,
    string neighborhood,
    string city,
    string state,
    string postalCode,
    string country = "Brasil"
    )
{
    public string Street { get; set; } = street;
    public string Number { get; set; } = number;
    public string Complement { get; set; } = complement;
    public string Neighborhood { get; set; } = neighborhood;
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public string PostalCode { get; set; } = postalCode;
    public string Country { get; set; } = country;

    public override string ToString()
    {
        return $"{Street}, {Number} - {Neighborhood}, {City}/{State}, {PostalCode} | {Country}";
    }
}
