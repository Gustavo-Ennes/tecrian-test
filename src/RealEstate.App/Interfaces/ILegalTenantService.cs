using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;

namespace RealEstate.App.Services;

public interface ILegalTenantService
{
    Task<List<LegalTenant>> GetTenantsAsync();
    Task<LegalTenant?> GetTenantByIdAsync(int id);
    Task<LegalTenant> CreateTenantAsync(CreateLegalTenantDto tenantDto);
    Task<bool> UpdateTenantAsync(UpdateLegalTenantDto tenantDto);
    Task<bool> DeleteTenantAsync(int id);
}
