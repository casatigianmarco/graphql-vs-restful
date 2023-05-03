using MediatR;
using Senai.TCC.Catalog.Application.Helpers;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class ReadCatalogItemsQueryHandler : IRequestHandler<ReadCatalogItemsQuery, IEnumerable<CatalogItemViewModel>?>
{
    private readonly ICatalogRepository _catalogRepository;

    public ReadCatalogItemsQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<IEnumerable<CatalogItemViewModel>?> Handle(ReadCatalogItemsQuery request,
        CancellationToken cancellationToken)
    {
        return (await _catalogRepository.GetCatalogItems(cancellationToken))?.Select(x => x.ToViewModel()).ToList();
    }
}