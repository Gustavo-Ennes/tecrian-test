using Microsoft.EntityFrameworkCore;
using Tecrian.Infra.Database;

namespace Tecrian.Test.Integration.Fixtures;

public class BaseFixture : IDisposable
{
    public TecrianDbContext DbContext { get; private set; }

    public BaseFixture()
    {
        var options = new DbContextOptionsBuilder<TecrianDbContext>()
            .UseInMemoryDatabase("TecrianInMemory")
            .Options;
        DbContext = new TecrianDbContext(options);
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}