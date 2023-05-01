using Senai.TCC.Catalog.Domain.Entities;

namespace Senai.TCC.Catalog.Domain.Repositories;

public interface ICatalogRepository
{
    public Task<CatalogItem> AddCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken);
    
    public Task<CatalogItem> DeleteCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken);

    public Task<CatalogItem?> GetCatalogItem(int catalogItemId, CancellationToken cancellationToken,
        bool asNoTracking = true);

    public Task<IEnumerable<CatalogItem>?> GetCatalogItems(CancellationToken cancellationToken,
        bool asNoTracking = true);

    public IQueryable<CatalogItem>? GetCatalogItemsQueryable();
    public Task<CatalogItem> UpdateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken);
}