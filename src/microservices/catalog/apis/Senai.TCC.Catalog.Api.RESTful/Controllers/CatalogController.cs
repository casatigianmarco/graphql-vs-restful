using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Senai.TCC.Catalog.Application.Queries;
using Senai.TCC.Catalog.Domain.Entities;
using Senai.TCC.Catalog.Shared.Dto;
using Senai.TCC.Catalog.Shared.ViewModel;

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
    
    // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
    [HttpGet]
    [Route("items")]
    [ProducesResponseType(typeof(IEnumerable<CatalogItemViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<CatalogItemViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> ItemsAsync(CancellationToken cancellationToken, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
    {
        var model = await _mediator.Send(new ReadCatalogItemsQuery(), cancellationToken);
        return Ok(model);
    }
    
    [HttpGet]
    [Route("items/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CatalogItemViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CatalogItemViewModel>> ItemByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var item = await _mediator.Send(new ReadSingleCatalogItemQuery(id), cancellationToken);

        if (item != null)
        {
            return item;
        }

        return NotFound();
    }
}