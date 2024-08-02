using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public class LegalTenantService(
    IRepository<LegalTenant> legalTenantRepository,
    IRepository<Person> personRepository,
    IRepository<Company> companyRepository,
    IMapper mapper
) : ILegalTenantService
{
    private readonly IRepository<LegalTenant> _legalTenantRepository = legalTenantRepository;
    private readonly IRepository<Person> _personRepository = personRepository;
    private readonly IRepository<Company> _companyRepository = companyRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CreateLegalTenantDto>> GetTenantsAsync()
    {
        List<LegalTenant> tenants = await _legalTenantRepository.GetAllAsync();
        return _mapper.Map<List<CreateLegalTenantDto>>(tenants);
    }

    public async Task<CreateLegalTenantDto?> GetTenantByIdAsync(int id)
    {
        LegalTenant? tenant = await _legalTenantRepository.GetByIdAsync(id);
        return tenant != null ? _mapper.Map<CreateLegalTenantDto>(tenant) : null;
    }

    public async Task<CreateLegalTenantDto> CreateTenantAsync(CreateLegalTenantDto dto)
    {
        Company? existingCompany = await _companyRepository.GetByIdAsync(dto.CompanyId);

        if (existingCompany?.Id == null)
            throw new Exception("Company not found");

        LegalTenant tenant = _mapper.Map<LegalTenant>(dto);
        tenant.CompanyId = (int)existingCompany.Id;

        LegalTenant addedTenant = await _legalTenantRepository.AddAsync(tenant);
        return _mapper.Map<CreateLegalTenantDto>(addedTenant);
    }

    public async Task<bool> UpdateTenantAsync(UpdateLegalTenantDto dto)
    {
        Company? company = null;

        LegalTenant existingTenant =
            await _legalTenantRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("LegalTenant not found");

        if (dto.CompanyId != null && dto.CompanyId != existingTenant.CompanyId)
            company =
                await _companyRepository.GetByIdAsync(dto.CompanyId ?? -1)
                ?? throw new Exception("Company not found");

        if (company?.Id != null)
            existingTenant.CompanyId = (int)company.Id;

        await _legalTenantRepository.UpdateAsync(existingTenant);
        return true;
    }

    public async Task<bool> DeleteTenantAsync(int id)
    {
        return await _legalTenantRepository.DeleteAsync(id);
    }
}
