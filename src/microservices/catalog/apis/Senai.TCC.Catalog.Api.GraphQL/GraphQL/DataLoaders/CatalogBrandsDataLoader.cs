using GraphQL.DataLoader;
using MediatR;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.DataLoaders;

public class BrandsDataLoader : DataLoaderBase<int, CatalogBrandViewModel>
{
    private readonly IMediator _mediator;
    public BrandsDataLoader(IMediator mediator)
    {
        _mediator = mediator;
    }
    protected override async Task FetchAsync(IEnumerable<DataLoaderPair<int, CatalogBrandViewModel>> list, CancellationToken cancellationToken)
    {
        var dataLoaderPairs = list as DataLoaderPair<int, CatalogBrandViewModel>[] ?? list.ToArray();
        var brandIds = dataLoaderPairs.Select(pair => pair.Key);
        IDictionary<int, CatalogBrandViewModel>? data = (await _mediator.Send(new ReadCatalogBrandsQuery(brandIds), cancellationToken))?.ToDictionary(x => x.Id);
        foreach (var entry in dataLoaderPairs)
        {
            entry.SetResult(data.TryGetValue(entry.Key, out var order) ? order : null);
        }
    }
}