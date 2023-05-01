namespace Senai.TCC.Catalog.Shared.ViewModel;

public class CatalogItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureFileName { get; set; }
    public CatalogTypeViewModel CatalogType { get; set; }
    public CatalogBrandViewModel CatalogBrand { get; set; }
}