using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public class NaturalTenantService(
    IRepository<NaturalTenant> naturalTenantRepository,
    IRepository<Person> personRepository,
    IMapper mapper
) : INaturalTenantService
{
    private readonly IRepository<NaturalTenant> _naturalTenantRepository = naturalTenantRepository;
    private readonly IRepository<Person> _personRepository = personRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CreateNaturalTenantDto>> GetTenantsAsync()
    {
        List<NaturalTenant> tenants = await _naturalTenantRepository.GetAllAsync();
        return _mapper.Map<List<CreateNaturalTenantDto>>(tenants);
    }

    public async Task<CreateNaturalTenantDto?> GetTenantByIdAsync(int id)
    {
        NaturalTenant? tenant = await _naturalTenantRepository.GetByIdAsync(id);
        return tenant != null ? _mapper.Map<CreateNaturalTenantDto>(tenant) : null;
    }

    public async Task<CreateNaturalTenantDto> CreateTenantAsync(CreateNaturalTenantDto dto)
    {
        Person? existingPerson = await _personRepository.GetByIdAsync(dto.PersonId);

        if (existingPerson?.Id == null)
            throw new Exception("Person not found");

        NaturalTenant tenant = _mapper.Map<NaturalTenant>(dto);
        tenant.PersonId = (int)existingPerson.Id;

        NaturalTenant addedTenant = await _naturalTenantRepository.AddAsync(tenant);
        return _mapper.Map<CreateNaturalTenantDto>(addedTenant);
    }

    public async Task<bool> UpdateTenantAsync(UpdateNaturalTenantDto dto)
    {
        Person? person = null;

        NaturalTenant existingTenant =
            await _naturalTenantRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("NaturalTenant not found");

        if (dto.PersonId != null && dto.PersonId != existingTenant.PersonId)
            person =
                await _personRepository.GetByIdAsync(dto.PersonId ?? -1)
                ?? throw new Exception("Person not found");

        if (person?.Id != null)
            existingTenant.PersonId = (int)person.Id;

        await _naturalTenantRepository.UpdateAsync(existingTenant);
        return true;
    }

    public async Task<bool> DeleteTenantAsync(int id)
    {
        return await _naturalTenantRepository.DeleteAsync(id);
    }
}
