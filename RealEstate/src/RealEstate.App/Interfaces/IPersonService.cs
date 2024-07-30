using RealEstate.Domain.Entities;

namespace RealEstate.App.Services;

public interface IPersonService
{
    Task<List<Person>> GetPersonsAsync();
    Task<Person?> GetPersonByIdAsync(int id);
    // Task<Person> CreatePersonAsync(CreatePersonDto PersonDto);
    // Task<bool> UpdatePersonAsync(UpdatePersonDto PersonDto);
    Task<bool> DeletePersonAsync(int id);
}
