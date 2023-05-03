using MediatR;
using Senai.TCC.Catalog.Application.Helpers;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class ReadSingleCatalogItemQueryHandler : IRequestHandler<ReadSingleCatalogItemQuery, CatalogItemViewModel?>
{
    private readonly ICatalogRepository _catalogRepository;

    public ReadSingleCatalogItemQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogItemViewModel?> Handle(ReadSingleCatalogItemQuery request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetCatalogItem(request.CatalogItemId, cancellationToken);
        return catalogItem?.ToViewModel();
    }
}