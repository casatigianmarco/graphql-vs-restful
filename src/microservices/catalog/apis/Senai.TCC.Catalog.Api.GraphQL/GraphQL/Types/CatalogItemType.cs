using GraphQL.Types;
using Senai.TCC.Catalog.Shared.ViewModel;
using GraphQL.DataLoader;
using Senai.TCC.Catalog.Api.GraphQL.GraphQL.DataLoaders;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;

public sealed class CatalogItemType : ObjectGraphType<CatalogItemViewModel>
{
    public CatalogItemType()
    {
        Field(c => c.Id);
        Field(c => c.Name).Description("The name of the catalog item");
        Field(c => c.Description).Description("A short description of the catalog item");
        Field(c => c.Price).Description("The catalog's item price");
        Field(c => c.PictureFileName, nullable: true).Description("The file name of the catalog's item picture");
        Field<BrandType, CatalogBrandViewModel>("brand")
            .ResolveAsync(context =>
            {
                var loader = context.RequestServices?.GetRequiredService<BrandsDataLoader>();
                if (loader is null) throw new ArgumentNullException("Data loader was not correctly injected");
                return loader.LoadAsync(context.Source.CatalogBrand.Id);
            });
        Field<CategoryType, CatalogTypeViewModel>("category")
            .ResolveAsync(context =>
            {
                var loader = context.RequestServices?.GetRequiredService<CategoriesDataLoader>();
                if (loader is null) throw new ArgumentNullException("Data loader was not correctly injected");
                return loader.LoadAsync(context.Source.CatalogType.Id);
            });
    }
}