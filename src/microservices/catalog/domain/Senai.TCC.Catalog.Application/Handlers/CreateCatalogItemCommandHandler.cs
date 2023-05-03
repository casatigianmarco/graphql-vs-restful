using MediatR;
using Senai.TCC.Catalog.Application.Commands;
using Senai.TCC.Catalog.Application.Helpers;
using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, CatalogItemViewModel?>
{
    private readonly ICatalogRepository _catalogRepository;

    public CreateCatalogItemCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogItemViewModel?> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = new CatalogItem
        {
            Name = request.CatalogItemDto.Name,
            Description = request.CatalogItemDto.Description,
            Price = request.CatalogItemDto.Price,
            CatalogBrandId = request.CatalogItemDto.CatalogBrandId,
            CatalogTypeId = request.CatalogItemDto.CatalogTypeId
        };

        var catalogItemAdded = await _catalogRepository.AddCatalogItem(catalogItem, cancellationToken);
        return catalogItemAdded?.ToViewModel();
    }
}