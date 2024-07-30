using RealEstate.Api.Dtos;
using RealEstate.Utils;

namespace RealEstate.Domain.Entities;

public class NaturalTenant : TenantBase
{
    public required Person Person { get; set; }

    public NaturalTenant() { }

    public static NaturalTenant FromDto(CreateNaturalTenantDto dto)
    {
        Person person = Person.FromDto(dto.Person);
        return new() { Person = person };
    }

    public NaturalTenant UpdateFromDto(UpdateNaturalTenantDto dto)
    {
        EndDate = dto.EndDate ?? EndDate;
        IsActive = dto.IsActive ?? IsActive;
        Notes = dto.Notes ?? Notes;
        Documents = dto.Documents ?? Documents;

        if (dto.Person != null)
            Person = Person.UpdateFromDto(dto.Person);

        return this;
    }

    public override string ToString() => 
        this.SerializeIndented();
}
