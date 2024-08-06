using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Test.Integration.Fixtures;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;

namespace RealEstate.Test.Integration.Base;

[Collection("LegalTenant")]
public class LegalTenantTests(
    CustomWebApplicationFactory<Program> program,
    LegalTenantFixture fixture
) : BaseIntegration(program)
{
    private readonly LegalTenantFixture _fixture = fixture;

    [Fact]
    public async Task AddLegalTenant()
    {
        await _fixture.AddData();
        Address? addedAddress = await _fixture._addressRepository.GetByIdAsync(1);

        // Assert - Add
        Assert.NotNull(addedAddress);
        Assert.Equal(
            CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement().Street,
            addedAddress.Street
        );
        Assert.Equal(
            CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement().Neighborhood,
            addedAddress.Neighborhood
        );

        // Act - Remove
        if (addedAddress.Id != null)
        {
            await _fixture._addressRepository.DeleteAsync((int)addedAddress.Id);
            var removedUser = await _fixture._addressRepository.GetByIdAsync((int)addedAddress.Id);
            Assert.Null(removedUser);
        }
    }
}
