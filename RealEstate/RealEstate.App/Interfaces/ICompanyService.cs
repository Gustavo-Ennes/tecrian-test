using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public interface ICompanyService
{
    Task<List<CreateCompanyDto>> GetCompanysAsync();
    Task<CreateCompanyDto?> GetCompanyByIdAsync(int id);
    Task<CreateCompanyDto> CreateCompanyAsync(CreateCompanyDto dto);
    Task<bool> UpdateCompanyAsync(UpdateCompanyDto CompanyDto);
    Task<bool> DeleteCompanyAsync(int id);
}
