using GraphQL.Types;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;

public sealed class CategoryType : ObjectGraphType<CatalogTypeViewModel>
{
    public CategoryType()
    {
        Field(ct => ct.Id).Description("The id of the category");
        Field(cb => cb.Type)
            .Name("name")
            .Description("The name of the category");
    }
}