using RealEstate.Domain.Entities;

namespace RealEstate.App.Services;

public interface ICompanyService
{
    Task<List<Company>> GetCompanysAsync();
    Task<Company?> GetCompanyByIdAsync(int id);
    // Task<Company> CreateCompanyAsync(CreateCompanyDto CompanyDto);
    // Task<bool> UpdateCompanyAsync(UpdateCompanyDto CompanyDto);
    Task<bool> DeleteCompanyAsync(int id);
}
