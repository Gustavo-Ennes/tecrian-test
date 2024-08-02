using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public interface ILegalTenantService
{
    Task<List<CreateLegalTenantDto>> GetTenantsAsync();
    Task<CreateLegalTenantDto?> GetTenantByIdAsync(int id);
    Task<CreateLegalTenantDto> CreateTenantAsync(CreateLegalTenantDto tenantDto);
    Task<bool> UpdateTenantAsync(UpdateLegalTenantDto tenantDto);
    Task<bool> DeleteTenantAsync(int id);
}
