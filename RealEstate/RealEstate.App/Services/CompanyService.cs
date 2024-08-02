using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public class CompanyService(
    IRepository<Company> companyRepository,
    IRepository<Person> personRepository,
    IRepository<Address> addressRepository,
    IMapper mapper
) : ICompanyService
{
    private readonly IRepository<Company> _companyRepository = companyRepository;
    private readonly IRepository<Person> _personRepository = personRepository;
    private readonly IRepository<Address> _AddressRepository = addressRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CreateCompanyDto>> GetCompanysAsync()
    {
        List<Company> companies = await _companyRepository.GetAllAsync();
        return _mapper.Map<List<CreateCompanyDto>>(companies);
    }

    public async Task<CreateCompanyDto?> GetCompanyByIdAsync(int id)
    {
        Company? company = await _companyRepository.GetByIdAsync(id);
        return company != null ? _mapper.Map<CreateCompanyDto>(company) : null;
    }

    public async Task<CreateCompanyDto> CreateCompanyAsync(CreateCompanyDto dto)
    {
        Person? existingRepresentant = await _personRepository.GetByIdAsync(dto.RepresentantId);

        if (existingRepresentant?.Id == null)
            throw new Exception("Representant not found");

        Company company = _mapper.Map<Company>(dto);
        company.RepresentantId = (int)existingRepresentant.Id;

        Company addedCompany = await _companyRepository.AddAsync(company);
        return _mapper.Map<CreateCompanyDto>(addedCompany);
    }

    public async Task<bool> UpdateCompanyAsync(UpdateCompanyDto dto)
    {
        Address? address = null;
        Person? representant = null;

        Company existingCompany =
            await _companyRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("Company not found");

        if (dto.RepresentantId != null && dto.RepresentantId != existingCompany.RepresentantId)
            representant =
                await _personRepository.GetByIdAsync(dto.RepresentantId ?? -1)
                ?? throw new Exception("Representant not found");

        if (dto.AddressId != null && dto.AddressId != existingCompany.AddressId)
            address =
                await _AddressRepository.GetByIdAsync(dto.AddressId ?? -1)
                ?? throw new Exception("Address not found");

        if (representant?.Id != null)
            existingCompany.RepresentantId = (int)representant.Id;
        if (address?.Id != null)
            existingCompany.AddressId = (int)address.Id;

        await _companyRepository.UpdateAsync(existingCompany);
        return true;
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        return await _companyRepository.DeleteAsync(id);
    }
}
