using RealEstate.Api.Dtos;
using RealEstate.Utils;

namespace RealEstate.Domain.Entities;

public class LegalTenant : TenantBase
{
    public required Company Company { get; set; }

    public LegalTenant() { }

    public static LegalTenant FromDto(CreateLegalTenantDto dto, Person representant)
    {
        Company company = Company.FromDto(dto.Company, representant);
        return new() { Company = company };
    }

    public LegalTenant UpdateFromDto(UpdateLegalTenantDto dto)
    {
      EndDate = dto.EndDate != null ? dto.EndDate : EndDate;
      IsActive = dto.IsActive ?? IsActive;
      Notes = dto.Notes ?? Notes;
      Documents = dto.Documents ?? Documents;

      if(dto.Company != null)
        Company = Company.UpdateFromDto(dto.Company) ?? Company;
      
      return this;      
    }


    public override string ToString() => 
        this.SerializeIndented();
}
