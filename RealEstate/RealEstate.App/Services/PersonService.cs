using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Shared.Dtos;

namespace RealEstate.App.Services;

public class PersonService(
    IRepository<Person> personRepository,
    IRepository<Address> addressRepository,
    IMapper mapper
) : IPersonService
{
    private readonly IRepository<Person> _personRepository = personRepository;
    private readonly IRepository<Address> _addressRepository = addressRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CreatePersonDto>> GetPersonsAsync()
    {
        List<Person> personas = await _personRepository.GetAllAsync();
        return _mapper.Map<List<CreatePersonDto>>(personas);
    }

    public async Task<CreatePersonDto?> GetPersonByIdAsync(int id)
    {
        Person? person = await _personRepository.GetByIdAsync(id);
        return person != null ? _mapper.Map<CreatePersonDto>(person) : null;
    }

    public async Task<CreatePersonDto> CreatePersonAsync(CreatePersonDto dto)
    {
        Address? existingAddress = await _addressRepository.GetByIdAsync(dto.AddressId);

        if (existingAddress?.Id == null)
            throw new Exception("Address not found");

        Person person = _mapper.Map<Person>(dto);
        person.AddressId = (int)existingAddress.Id;

        Person addedPerson = await _personRepository.AddAsync(person);
        return _mapper.Map<CreatePersonDto>(addedPerson);
    }

    public async Task<bool> UpdatePersonAsync(UpdatePersonDto dto)
    {
        Address? address = null;

        Person existingPerson =
            await _personRepository.GetByIdAsync(dto.Id) ?? throw new Exception("Person not found");

        if (dto.AddressId != null && dto.AddressId != existingPerson.AddressId)
            address =
                await _addressRepository.GetByIdAsync(dto.AddressId ?? -1)
                ?? throw new Exception("Address not found");

        if (address?.Id != null)
            existingPerson.AddressId = (int)address.Id;

        await _personRepository.UpdateAsync(existingPerson);
        return true;
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        return await _personRepository.DeleteAsync(id);
    }
}
