using RealEstate.Domain.Entities;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public interface INaturalTenantService
{
    Task<List<CreateNaturalTenantDto>> GetTenantsAsync();
    Task<CreateNaturalTenantDto?> GetTenantByIdAsync(int id);
    Task<CreateNaturalTenantDto> CreateTenantAsync(CreateNaturalTenantDto tenantDto);
    Task<bool> UpdateTenantAsync(UpdateNaturalTenantDto tenantDto);
    Task<bool> DeleteTenantAsync(int id);
}
