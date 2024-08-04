using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Infra.Database;

public class RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : DbContext(options)
{
    public DbSet<LegalTenant> LegalTenant { get; set; }
    public DbSet<NaturalTenant> NaturalTenant { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Company> Company { get; set; }
}
