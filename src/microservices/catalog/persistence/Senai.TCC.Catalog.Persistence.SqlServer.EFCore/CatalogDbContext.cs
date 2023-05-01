using Microsoft.EntityFrameworkCore;

namespace Senai.TCC.Catalog.Persistence.SqlServer.EFCore;

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