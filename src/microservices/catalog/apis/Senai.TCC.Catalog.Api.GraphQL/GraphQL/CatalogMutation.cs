using GraphQL;
using GraphQL.Types;
using MediatR;
using Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;
using Senai.TCC.Catalog.Application.Commands;
using Senai.TCC.Catalog.Shared.Dto;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL;

public sealed class CatalogMutation : ObjectGraphType
{
    public CatalogMutation()
    {
        Field<CatalogItemType>("createCatalogItem")
            .Argument<NonNullGraphType<CreateCatalogItemType>>("catalogItem")
            .ResolveAsync(async (context) =>
            {
                var mediator = context.RequestServices?.GetRequiredService<IMediator>();
                if (mediator is null) throw new ArgumentException("Missing Mediatr service", nameof(mediator));
                var catalogItem = context.GetArgument<CreateCatalogItemDto>("catalogItem");
                return await mediator.Send(new CreateCatalogItemCommand(catalogItem), context.CancellationToken);
            });

        Field<CatalogItemType>("updateCatalogItem")
            .Argument<NonNullGraphType<IdGraphType>>("catalogItemId")
            .Argument<NonNullGraphType<UpdateCatalogItemType>>("catalogItem")
            .ResolveAsync(async (context) =>
            {
                var mediator = context.RequestServices?.GetRequiredService<IMediator>();
                if (mediator is null) throw new ArgumentException("Missing Mediatr service", nameof(mediator));
                var catalogItemId = context.GetArgument<int>("catalogItemId");
                var catalogItem = context.GetArgument<UpdateCatalogItemDto>("catalogItem");
                return await mediator.Send(new UpdateCatalogItemCommand(catalogItemId, catalogItem),
                    context.CancellationToken);
            });

        Field<CatalogItemType>("deleteCatalogItem")
            .Argument<NonNullGraphType<IdGraphType>>("catalogItemId")
            .ResolveAsync(async (context) =>
            {
                var mediator = context.RequestServices?.GetRequiredService<IMediator>();
                if (mediator is null) throw new ArgumentException("Missing Mediatr service", nameof(mediator));
                var catalogItemId = context.GetArgument<int>("catalogItemId");
                return await mediator.Send(new DeleteCatalogItemCommand(catalogItemId),
                    context.CancellationToken);
            });
    }
}