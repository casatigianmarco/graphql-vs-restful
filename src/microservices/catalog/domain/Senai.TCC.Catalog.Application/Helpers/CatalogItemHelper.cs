using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Shared.ViewModel;

namespace Senai.TCC.Catalog.Application.Helpers;

public static class CatalogItemHelper
{
    public static CatalogItemViewModel ToViewModel(this CatalogItem catalogItem)
    {
        return new CatalogItemViewModel
        {
            Id = catalogItem.Id,
            CatalogBrand = new CatalogBrandViewModel
            {
                Id = catalogItem.CatalogBrandId,
                Brand = catalogItem.CatalogBrand?.Brand ?? string.Empty
            },
            CatalogType = new CatalogTypeViewModel
            {
                Id = catalogItem.CatalogTypeId,
                Type = catalogItem.CatalogType?.Type ?? string.Empty
            },
            Description = catalogItem.Description,
            Name = catalogItem.Name,
            PictureFileName = catalogItem.PictureFileName,
            Price = catalogItem.Price,
            // CatalogBrandId = catalogItem.CatalogBrandId,
            // CatalogTypeId = catalogItem.CatalogTypeId
        };
    }
}