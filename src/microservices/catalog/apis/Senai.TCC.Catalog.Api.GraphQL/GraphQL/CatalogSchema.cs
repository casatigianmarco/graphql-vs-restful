using GraphQL.Types;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL;

public class CatalogSchema : Schema
{
    public CatalogSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<CatalogQuery>();
        Mutation = provider.GetRequiredService<CatalogMutation>();
    }
}