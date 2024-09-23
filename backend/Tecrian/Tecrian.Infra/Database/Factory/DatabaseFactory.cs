using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tecrian.Infra.Database.Factory;

public class TecrianDbContextFactory : IDesignTimeDbContextFactory<TecrianDbContext>
{
    public TecrianDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TecrianDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=TecrianTest;User Id=sa;Password=1Ilesor.;",
            sqlOptions => sqlOptions.MigrationsAssembly("Tecrian.Api")
        );

        return new TecrianDbContext(optionsBuilder.Options);
    }
}
