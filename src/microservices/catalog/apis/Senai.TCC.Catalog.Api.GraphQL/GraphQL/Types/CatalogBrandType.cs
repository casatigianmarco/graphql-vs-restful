using GraphQL.Types;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;

public sealed class BrandType : ObjectGraphType<CatalogBrandViewModel>
{
    public BrandType()
    {
        Field(cb => cb.Id).Description("The id of the brand");
        Field(cb => cb.Brand)
            .Name("name")
            .Description("The name of the brand");
    }
}