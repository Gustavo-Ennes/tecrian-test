using RealEstate.Infra.Database;

namespace RealEstate.Test.Integration.Fixtures;

public interface IFixture
{
    Task AddData();
}
