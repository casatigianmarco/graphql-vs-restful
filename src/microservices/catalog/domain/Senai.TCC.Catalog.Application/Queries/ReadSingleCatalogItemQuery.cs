using MediatR;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Queries;

public class ReadSingleCatalogItemQuery : IRequest<CatalogItemViewModel?>
{
    public ReadSingleCatalogItemQuery(int catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }
    
    public int CatalogItemId { get; }
}