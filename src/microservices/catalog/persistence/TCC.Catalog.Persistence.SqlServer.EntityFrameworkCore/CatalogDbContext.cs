using Microsoft.EntityFrameworkCore;

namespace TCC.Catalog.Persistence.SqlServer.EntityFrameworkCore;

public class CatalogDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}