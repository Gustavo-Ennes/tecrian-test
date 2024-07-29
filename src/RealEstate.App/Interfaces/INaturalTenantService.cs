using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;

namespace RealEstate.App.Services;

public interface INaturalTenantService
{
    Task<List<NaturalTenant>> GetTenantsAsync();
    Task<NaturalTenant?> GetTenantByIdAsync(int id);
    Task<NaturalTenant> CreateTenantAsync(CreateNaturalTenantDto tenantDto);
    Task<bool> UpdateTenantAsync(UpdateNaturalTenantDto tenantDto);
    Task<bool> DeleteTenantAsync(int id);
}
