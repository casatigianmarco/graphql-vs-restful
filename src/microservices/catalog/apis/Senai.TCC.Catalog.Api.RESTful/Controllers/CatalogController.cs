using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Shared.Dto;

namespace Senai.TCC.Catalog.Api.RESTful.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //PUT api/v1/[controller]/items
    [Route("items")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> UpdateProductAsync([FromBody] UpdateCatalogItemDto productToUpdate)
    {
        return Ok();
    }
}