using System.Linq.Expressions;
using MediatR;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Domain.Repositories;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Handlers;

public class ReadCatalogCategoriesQueryHandler : IRequestHandler<ReadCatalogCategoriesQuery, IEnumerable<CatalogTypeViewModel>?>
{
    private readonly ICatalogRepository _catalogRepository;
    public ReadCatalogCategoriesQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }
    
    public async Task<IEnumerable<CatalogTypeViewModel>?> Handle(ReadCatalogCategoriesQuery request, CancellationToken cancellationToken)
    {
        var types = await _catalogRepository.GetCatalogTypes(cancellationToken, catalogTypeIds: request.CatalogCategoriesIds?.Distinct());
        return types?.Select(b => new CatalogTypeViewModel
        {
            Id = b.Id,
            Type = b.Type
        });
    }
}