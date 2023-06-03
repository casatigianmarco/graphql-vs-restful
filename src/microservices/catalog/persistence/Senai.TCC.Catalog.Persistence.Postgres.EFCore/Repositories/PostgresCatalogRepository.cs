using Microsoft.EntityFrameworkCore;
using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Domain.Repositories;

namespace Senai.TCC.Catalog.Persistence.Postgres.EFCore.Repositories;

public class PostgresCatalogRepository : ICatalogRepository
{
    private readonly PostgresCatalogDbContext _postgresCatalogDbContext;

    public PostgresCatalogRepository(PostgresCatalogDbContext postgresCatalogDbContext)
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

    public async Task<IEnumerable<CatalogBrand>?> GetCatalogBrands(CancellationToken cancellationToken, bool asNoTracking = true,
        IEnumerable<int>? catalogBrandIds = null)
    {
        var catalogBrandsQueryable = GetCatalogBrandsQueryable();
        if (asNoTracking)
        {
            catalogBrandsQueryable = catalogBrandsQueryable.AsNoTracking();
        }

        var brandIds = catalogBrandIds?.ToList();
        if (brandIds is not null && brandIds.Any())
        {
            catalogBrandsQueryable = catalogBrandsQueryable.Where(c => brandIds.Contains(c.Id));
        }

        return await catalogBrandsQueryable.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<CatalogType>?> GetCatalogTypes(CancellationToken cancellationToken, bool asNoTracking = true, IEnumerable<int>? catalogTypeIds = null)
    {
        var catalogTypesQueryable = GetCatalogTypesQueryable();
        if (asNoTracking)
        {
            catalogTypesQueryable = catalogTypesQueryable.AsNoTracking();
        }

        var brandIds = catalogTypeIds?.ToList();
        if (brandIds is not null && brandIds.Any())
        {
            catalogTypesQueryable = catalogTypesQueryable.Where(c => brandIds.Contains(c.Id));
        }

        return await catalogTypesQueryable.ToListAsync(cancellationToken);
    }

    private IQueryable<CatalogItem> GetCatalogItemsQueryable()
    {
        return _postgresCatalogDbContext.CatalogItems.AsQueryable();
    }

    private IQueryable<CatalogBrand> GetCatalogBrandsQueryable()
    {
        return _postgresCatalogDbContext.CatalogBrands.AsQueryable();
    }

    private IQueryable<CatalogType> GetCatalogTypesQueryable()
    {
        return _postgresCatalogDbContext.CatalogTypes.AsQueryable();
    }

    public async Task<CatalogItem> UpdateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken)
    {
        var catalogItemUpdated = _postgresCatalogDbContext.CatalogItems.Update(catalogItem);
        await _postgresCatalogDbContext.SaveChangesAsync(cancellationToken);
        return catalogItemUpdated.Entity;
    }
}