using MediatR;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class ReadCatalogBrandsQueryHandler : IRequestHandler<ReadCatalogBrandsQuery, IEnumerable<CatalogBrandViewModel>?>
{
    private readonly ICatalogRepository _catalogRepository;
    public ReadCatalogBrandsQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }
    
    public async Task<IEnumerable<CatalogBrandViewModel>?> Handle(ReadCatalogBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _catalogRepository.GetCatalogBrands(cancellationToken, catalogBrandIds: request.CatalogBrandIds?.Distinct());
        return brands?.Select(b => new CatalogBrandViewModel
        {
            Id = b.Id,
            Brand = b.Brand
        });
    }
}