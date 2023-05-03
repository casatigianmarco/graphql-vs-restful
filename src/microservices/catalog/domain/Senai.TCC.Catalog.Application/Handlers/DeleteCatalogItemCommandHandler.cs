using MediatR;
using Senai.TCC.Catalog.Application.Commands;
using Senai.TCC.Catalog.Application.Helpers;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, CatalogItemViewModel?>
{
    private readonly ICatalogRepository _catalogRepository;

    public DeleteCatalogItemCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogItemViewModel?> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetCatalogItem(request.CatalogItemId, cancellationToken);
        if (catalogItem is null) return null;
        
        var catalogItemDeleted = await _catalogRepository.DeleteCatalogItem(catalogItem, cancellationToken);
        return catalogItemDeleted?.ToViewModel();
    }
}