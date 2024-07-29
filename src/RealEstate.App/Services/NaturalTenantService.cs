using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;

namespace RealEstate.App.Services;

public class NaturalTenantService(
    IRepository<NaturalTenant> naturalTenantRepository,
    IRepository<Person> personRepository
) : INaturalTenantService
{
    private readonly IRepository<NaturalTenant> _naturalTenantRepository = naturalTenantRepository;
    private readonly IRepository<Person> _personRepository = personRepository;

    public async Task<List<NaturalTenant>> GetTenantsAsync()
    {
        var tenants = await _naturalTenantRepository.GetAllAsync();
        return tenants;
    }

    public async Task<NaturalTenant?> GetTenantByIdAsync(int id)
    {
        var tenant = await _naturalTenantRepository.GetByIdAsync(id);
        return tenant;
    }

    public async Task<NaturalTenant> CreateTenantAsync(CreateNaturalTenantDto dto)
    {
        NaturalTenant tenant = NaturalTenant.FromDto(dto);

        var addedTenant = await _naturalTenantRepository.AddAsync(tenant);
        return addedTenant;
    }

    public async Task<bool> UpdateTenantAsync(UpdateNaturalTenantDto dto)
    {
        NaturalTenant existingTenant =
            await _naturalTenantRepository.GetByIdAsync(dto.Id) ?? throw new Exception("Tenant not found");

        NaturalTenant updatedTenant = existingTenant.UpdateFromDto(dto);
        await _naturalTenantRepository.UpdateAsync(updatedTenant);
        return true;
    }

    public async Task<bool> DeleteTenantAsync(int id)
    {
        return await _naturalTenantRepository.DeleteAsync(id);
    }
}
