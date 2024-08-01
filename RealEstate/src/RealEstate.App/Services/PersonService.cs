using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;

namespace RealEstate.App.Services;

public class PersonService(IRepository<Person> personRepository) : IPersonService
{
    private readonly IRepository<Person> _personRepository = personRepository;

    public async Task<List<Person>> GetPersonsAsync()
    {
        var Persons = await _personRepository.GetAllAsync();
        return Persons;
    }

    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        var Person = await _personRepository.GetByIdAsync(id);
        return Person;
    }

    public async Task<Person> CreatePersonAsync(CreatePersonDto dto)
    {
        Person newPerson = Person.FromDto(dto);
        var addedPerson = await _personRepository.AddAsync(newPerson);
        return addedPerson;
    }

    public async Task<bool> UpdatePersonAsync(UpdatePersonDto dto)
    {
        var existingPerson =
            await _personRepository.GetByIdAsync(dto.Id ?? -1) ?? throw new Exception("Person not found");
        var updatedPerson = existingPerson.UpdateFromDto(dto);

        await _personRepository.UpdateAsync(updatedPerson);
        return true;
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        return await _personRepository.DeleteAsync(id);
    }
}
