using MediatR;
using Senai.TCC.Catalog.Application.Commands;
using Senai.TCC.Catalog.Application.Helpers;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, CatalogItemViewModel?>
{
    private readonly ICatalogRepository _catalogRepository;

    public UpdateCatalogItemCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogItemViewModel?> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetCatalogItem(request.CatalogItemId, cancellationToken);
        if (catalogItem is null) return null;

        catalogItem.Name = request.CatalogItemDto.Name;
        catalogItem.CatalogBrandId = request.CatalogItemDto.CatalogBrandId;
        catalogItem.CatalogTypeId = request.CatalogItemDto.CatalogTypeId;
        catalogItem.Price = request.CatalogItemDto.Price;
        catalogItem.Description = request.CatalogItemDto.Description;

        var catalogItemUpdated = await _catalogRepository.UpdateCatalogItem(catalogItem, cancellationToken);
        return catalogItemUpdated?.ToViewModel();
    }
}