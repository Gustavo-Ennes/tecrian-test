using RealEstate.Api.Dtos.Tenant;
using RealEstate.Domain.Entities;

namespace RealEstate.App.Services;

public interface ITenantService
{
    Task<List<Tenant>> GetTenantsAsync();
    Task<Tenant?> GetTenantByIdAsync(int id);
    Task<Tenant> CreateTenantAsync(CreateTenantDto tenantDto);
    Task<bool> UpdateTenantAsync(UpdateTenantDto tenantDto);
    Task<bool> DeleteTenantAsync(int id);
}
