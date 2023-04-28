using Microsoft.EntityFrameworkCore;
using TCC.Catalog.Domain.Entities;
using TCC.Catalog.Domain.Repositories;

namespace TCC.Catalog.Persistence.Postgres.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly CatalogDbContext _catalogDbContext;

    public CatalogRepository(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext;
    }

    public async Task<CatalogItem> AddCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemAdded = await _catalogDbContext.CatalogItems.AddAsync(catalogItem, cancellationToken);
        await _catalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemAdded.Entity;
    }

    public async Task<CatalogItem> DeleteCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemDeleted = _catalogDbContext.CatalogItems.Remove(catalogItem);
        await _catalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemDeleted.Entity;
    }

    public async Task<CatalogItem?> GetCatalogItem(int catalogItemId, CancellationToken cancellationToken,
        bool asNoTracking = true)
    {
        var catalogItemsQueryable = GetCatalogItemsQueryable();
        if (asNoTracking)
        {
            catalogItemsQueryable = catalogItemsQueryable.AsNoTracking();
        }

        return await catalogItemsQueryable.SingleOrDefaultAsync(i => i.Id == catalogItemId, cancellationToken);
    }

    public async Task<IEnumerable<CatalogItem>?> GetCatalogItems(CancellationToken cancellationToken,
        bool asNoTracking = true)
    {
        var catalogItemsQueryable = GetCatalogItemsQueryable();
        if (asNoTracking)
        {
            catalogItemsQueryable = catalogItemsQueryable.AsNoTracking();
        }

        return await catalogItemsQueryable.ToListAsync(cancellationToken);
    }

    public IQueryable<CatalogItem> GetCatalogItemsQueryable()
    {
        return _catalogDbContext.CatalogItems.AsQueryable();
    }

    public async Task<CatalogItem> UpdateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemUpdated = _catalogDbContext.CatalogItems.Update(catalogItem);
        await _catalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemUpdated.Entity;
    }
}