using MediatR;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Queries;

public class ReadCatalogCategoriesQuery : IRequest<IEnumerable<CatalogTypeViewModel>?>
{
    public ReadCatalogCategoriesQuery(IEnumerable<int>? catalogCategoriesIds = null)
    {
        CatalogCategoriesIds = catalogCategoriesIds;
    }
    
    public IEnumerable<int>? CatalogCategoriesIds { get; }
}