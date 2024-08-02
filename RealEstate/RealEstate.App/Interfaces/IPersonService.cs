using RealEstate.Domain.Entities;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public interface IPersonService
{
    Task<List<CreatePersonDto>> GetPersonsAsync();
    Task<CreatePersonDto?> GetPersonByIdAsync(int id);
    Task<CreatePersonDto> CreatePersonAsync(CreatePersonDto PersonDto);
    Task<bool> UpdatePersonAsync(UpdatePersonDto PersonDto);
    Task<bool> DeletePersonAsync(int id);
}
