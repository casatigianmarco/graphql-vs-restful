using FluentValidation;
using Senai.TCC.Catalog.Application.Commands;

namespace Senai.TCC.Catalog.Application.Validations;

public class UpdateCatalogItemCommandValidator : AbstractValidator<UpdateCatalogItemCommand>
{
    public UpdateCatalogItemCommandValidator()
    {
        RuleFor(x => x.CatalogItemId)
            .GreaterThan(0)
            .WithMessage("Invalid catalog item id")
            .WithErrorCode("CATALOG_ID_INVALID");
        
        RuleFor(x => x.CatalogItemDto)
            .NotNull()
            .WithMessage("Invalid Catalog item dto")
            .WithErrorCode("CATALOG_ITEM_DTO_INVALID");
        
        RuleFor(x => x)
            .Must(x => x.CatalogItemId == x.CatalogItemDto.Id)
            .WithMessage("Different catalog item id on route and payload")
            .WithErrorCode("CATALOG_ITEM_ID_CONFLICT");
    }
}