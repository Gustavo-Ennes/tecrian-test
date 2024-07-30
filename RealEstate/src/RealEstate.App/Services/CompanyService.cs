using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;

namespace RealEstate.App.Services;

public class CompanyService(
    IRepository<Company> companyRepository,
    IRepository<Person> personRepository
) : ICompanyService
{
    private readonly IRepository<Company> _companyRepository = companyRepository;
    private readonly IRepository<Person> _personRepository = personRepository;

    public async Task<List<Company>> GetCompanysAsync()
    {
        var companys = await _companyRepository.GetAllAsync();
        return companys;
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        var companys = await _companyRepository.GetByIdAsync(id);
        return companys;
    }

    public async Task<Company> CreateCompanyAsync(CreateCompanyDto dto)
    {
        Person representant = Person.FromDto(dto.Representant);
        Company company = Company.FromDto(dto, representant);
        var addedCompany = await _companyRepository.AddAsync(company);
        return addedCompany;
    }

    public async Task<bool> UpdateCompanyAsync(UpdateCompanyDto dto)
    {
        var existingCompany =
            await _companyRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("Company not found");
        var updatedCompany = existingCompany.UpdateFromDto(dto);

        await _companyRepository.UpdateAsync(updatedCompany);
        return true;
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        return await _companyRepository.DeleteAsync(id);
    }
}
