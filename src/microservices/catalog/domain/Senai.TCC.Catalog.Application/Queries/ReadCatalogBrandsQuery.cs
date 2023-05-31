using MediatR;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Queries;

public class ReadCatalogBrandsQuery : IRequest<IEnumerable<CatalogBrandViewModel>?>
{
    public ReadCatalogBrandsQuery(IEnumerable<int>? catalogBrandIds = null)
    {
        CatalogBrandIds = catalogBrandIds;
    }
    
    public IEnumerable<int>? CatalogBrandIds { get; }
}