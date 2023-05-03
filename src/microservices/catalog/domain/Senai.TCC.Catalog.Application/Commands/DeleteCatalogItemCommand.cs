using MediatR;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Commands;

public class DeleteCatalogItemCommand : IRequest<CatalogItemViewModel>
{
    public DeleteCatalogItemCommand(int catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }

    public int CatalogItemId { get; }
}