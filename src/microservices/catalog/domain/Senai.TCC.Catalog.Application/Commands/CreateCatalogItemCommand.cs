using MediatR;
using Senai.TCC.Catalog.Shared.Dto;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Commands;

public class CreateCatalogItemCommand : IRequest<CatalogItemViewModel?>
{
    public CreateCatalogItemCommand(CreateCatalogItemDto catalogItemDto)
    {
        CatalogItemDto = catalogItemDto;
    }

    public CreateCatalogItemDto CatalogItemDto { get; }
}