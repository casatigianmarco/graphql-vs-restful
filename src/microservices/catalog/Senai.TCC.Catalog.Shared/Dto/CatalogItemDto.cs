namespace Senai.TCC.Catalog.Shared.Dto;

public abstract class CatalogItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CatalogTypeId { get; set; }
    public int CatalogBrandId { get; set; }
}