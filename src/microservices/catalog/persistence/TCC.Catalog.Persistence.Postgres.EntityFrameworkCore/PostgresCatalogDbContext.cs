using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TCC.Catalog.Domain.Entities;
using TCC.Catalog.Persistence.Postgres.EntityFrameworkCore.Configurations;

namespace TCC.Catalog.Persistence.Postgres.EntityFrameworkCore;

public class PostgresCatalogDbContext : DbContext
{
    private const string Schema = "catalog";
    private const string MigrationHistoryTable = "__CatalogDbSchemaMigrations";
    
    public PostgresCatalogDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(x => x.MigrationsHistoryTable(MigrationHistoryTable, Schema));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("catalog");
        modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
    }

    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
}

public class CatalogDbContextDesignFactory : IDesignTimeDbContextFactory<PostgresCatalogDbContext>
{
    public PostgresCatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostgresCatalogDbContext>()
            .UseNpgsql("User ID=postgres;Password=tccsenaipa55w0rd;Host=localhost;Port=5432;Database=catalog;Pooling=true;");

        return new PostgresCatalogDbContext(optionsBuilder.Options);
    }
}