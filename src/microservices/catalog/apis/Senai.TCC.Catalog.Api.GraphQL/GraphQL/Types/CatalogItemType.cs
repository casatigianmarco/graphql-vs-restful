using GraphQL.Types;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;

public sealed class CatalogItemType : ObjectGraphType<CatalogItemViewModel>
{
    public CatalogItemType()
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.Description);
    }
}