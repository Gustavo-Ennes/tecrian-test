using Microsoft.EntityFrameworkCore;
using Tecrian.Domain.Entities;

namespace Tecrian.Infra.Database;

public class TecrianDbContext(DbContextOptions<TecrianDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
}
