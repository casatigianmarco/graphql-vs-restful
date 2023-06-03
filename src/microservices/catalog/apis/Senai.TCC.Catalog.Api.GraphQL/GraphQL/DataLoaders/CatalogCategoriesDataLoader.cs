using GraphQL.DataLoader;
using MediatR;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.DataLoaders;

public class CategoriesDataLoader : DataLoaderBase<int, CatalogTypeViewModel>
{
    private readonly IMediator _mediator;
    public CategoriesDataLoader(IMediator mediator)
    {
        _mediator = mediator;
    }
    protected override async Task FetchAsync(IEnumerable<DataLoaderPair<int, CatalogTypeViewModel>> list, CancellationToken cancellationToken)
    {
        IEnumerable<int> categoriesIds = list.Select(pair => pair.Key);
        IDictionary<int, CatalogTypeViewModel>? data = (await _mediator.Send(new ReadCatalogCategoriesQuery(categoriesIds), cancellationToken))?.ToDictionary(x => x.Id);
        foreach (DataLoaderPair<int, CatalogTypeViewModel> entry in list)
        {
            entry.SetResult(data.TryGetValue(entry.Key, out var order) ? order : null);
        }
    }
}