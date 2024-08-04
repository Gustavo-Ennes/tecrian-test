using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstate.Infra.Database.Factory;

public class RealEstateDbContextFactory : IDesignTimeDbContextFactory<RealEstateDbContext>
{
    public RealEstateDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RealEstateDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=RealEstateTest;User Id=sa;Password=1Ilesor.;",
            sqlOptions => sqlOptions.MigrationsAssembly("RealEstate.Api")
        );

        return new RealEstateDbContext(optionsBuilder.Options);
    }
}
