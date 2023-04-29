using Microsoft.EntityFrameworkCore;
using TCC.Catalog.Domain.Entities;
using TCC.Catalog.Domain.Repositories;

namespace TCC.Catalog.Persistence.Postgres.EntityFrameworkCore.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly PostgresCatalogDbContext _postgresCatalogDbContext;

    public CatalogRepository(PostgresCatalogDbContext postgresCatalogDbContext)
    {
        _postgresCatalogDbContext = postgresCatalogDbContext;
    }

    public async Task<CatalogItem> AddCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemAdded = await _postgresCatalogDbContext.CatalogItems.AddAsync(catalogItem, cancellationToken);
        await _postgresCatalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemAdded.Entity;
    }

    public async Task<CatalogItem> DeleteCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemDeleted = _postgresCatalogDbContext.CatalogItems.Remove(catalogItem);
        await _postgresCatalogDbContext.SaveChangesAsync(cancellationToken);
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
        return _postgresCatalogDbContext.CatalogItems.AsQueryable();
    }

    public async Task<CatalogItem> UpdateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemUpdated = _postgresCatalogDbContext.CatalogItems.Update(catalogItem);
        await _postgresCatalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemUpdated.Entity;
    }
}