using GraphQL.Types;
using MediatR;
using Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;
using Senai.TCC.Catalog.Application.Queries;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL;

public sealed class CatalogQuery : ObjectGraphType
{
    public CatalogQuery()
    {
        Field<ListGraphType<CatalogItemType>>("itens").ResolveAsync(async (context) =>
        {
            var mediator = context.RequestServices?.GetRequiredService<IMediator>();
            if (mediator is null) throw new ArgumentException("Missing Mediatr service", nameof(mediator));
            return await mediator.Send(new ReadCatalogItemsQuery());
        });
    }
}