using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Infra.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenant { get; set; }
}
