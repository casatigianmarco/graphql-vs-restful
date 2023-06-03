using GraphQL.Types;
using Npgsql.PostgresTypes;
using Senai.TCC.Catalog.Shared.Dto;

namespace Senai.TCC.Catalog.Api.GraphQL.GraphQL.Types;

public sealed class CreateCatalogItemType : InputObjectGraphType<CreateCatalogItemDto>
{
    public CreateCatalogItemType()
    {
        Name = "createCatalogItem";
        Field(c => c.Name);
        Field(c => c.Description);
        Field(c => c.Price);
        Field(c => c.CatalogBrandId);
        Field(c => c.CatalogTypeId).Name("categoryId");
    }    
}

public sealed class UpdateCatalogItemType : InputObjectGraphType<UpdateCatalogItemDto>
{
    public UpdateCatalogItemType()
    {
        Name = "updateCatalogItem";
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.Description);
        Field(c => c.Price);
        Field(c => c.CatalogBrandId);
        Field(c => c.CatalogTypeId).Name("categoryId");
    }    
}