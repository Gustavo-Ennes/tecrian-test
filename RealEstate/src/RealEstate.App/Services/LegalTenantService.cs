using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;

namespace RealEstate.App.Services;

public class LegalTenantService(
    IRepository<LegalTenant> legalTenantRepository,
    IRepository<Person> personRepository
) : ILegalTenantService
{
    private readonly IRepository<LegalTenant> _legalTenantRepository = legalTenantRepository;
    private readonly IRepository<Person> _personRepository = personRepository;

    public async Task<List<LegalTenant>> GetTenantsAsync()
    {
        List<LegalTenant> tenants = await _legalTenantRepository.GetAllAsync();
        return tenants;
    }

    public async Task<LegalTenant?> GetTenantByIdAsync(int id)
    {
        LegalTenant? tenant = await _legalTenantRepository.GetByIdAsync(id);
        return tenant;
    }

    public async Task<LegalTenant> CreateTenantAsync(CreateLegalTenantDto dto)
    {
        Person representant = Person.FromDto(dto.Company.Representant);
        LegalTenant tenant = LegalTenant.FromDto(dto, representant);
        LegalTenant addedTenant = await _legalTenantRepository.AddAsync(tenant);
        return addedTenant;
    }

    public async Task<bool> UpdateTenantAsync(UpdateLegalTenantDto dto)
    {
        LegalTenant existingTenant =
            await _legalTenantRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("Tenant not found");

        LegalTenant updatedTenant = existingTenant.UpdateFromDto(dto);
        await _legalTenantRepository.UpdateAsync(updatedTenant);
        return true;
    }

    public async Task<bool> DeleteTenantAsync(int id)
    {
        return await _legalTenantRepository.DeleteAsync(id);
    }
}
