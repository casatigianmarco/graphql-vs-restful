using MediatR;
using Senai.TCC.Catalog.Shared.Dto;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Commands;

public class UpdateCatalogItemCommand : IRequest<CatalogItemViewModel>
{
    public UpdateCatalogItemCommand(int catalogItemId, UpdateCatalogItemDto catalogItemDto)
    {
        CatalogItemId = catalogItemId;
        CatalogItemDto = catalogItemDto;
    }

    public int CatalogItemId { get; set; }
    public UpdateCatalogItemDto CatalogItemDto { get; set; }
}