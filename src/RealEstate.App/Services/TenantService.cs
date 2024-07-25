using RealEstate.Api.Dtos.Tenant;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Repositories;

namespace RealEstate.App.Services;

public class TenantService(IRepository<Tenant> tenantRepository) : ITenantService
{
    private readonly IRepository<Tenant> _tenantRepository = tenantRepository;

    public async Task<List<Tenant>> GetTenantsAsync()
    {
        var tenants = await _tenantRepository.GetAllAsync();
        return tenants;
    }

    public async Task<Tenant?> GetTenantByIdAsync(int id)
    {
        var tenant = await _tenantRepository.GetByIdAsync(id);
        return tenant;
    }

    public async Task<Tenant> CreateTenantAsync(CreateTenantDto dto)
    {
        var tenant = Tenant.FromDto(dto);
        var addedTenant = await _tenantRepository.AddAsync(tenant);
        return addedTenant;
    }

    public async Task<bool> UpdateTenantAsync(UpdateTenantDto dto)
    {
        var existingTenant =
            await _tenantRepository.GetByIdAsync(dto.Id) ?? throw new Exception("Tenant not found");
        var updatedTenant = Tenant.UpdateFromDto(existingTenant, dto);

        await _tenantRepository.UpdateAsync(updatedTenant);
        return true;
    }

    public async Task<bool> DeleteTenantAsync(int id)
    {
        return await _tenantRepository.DeleteAsync(id);
    }
}
