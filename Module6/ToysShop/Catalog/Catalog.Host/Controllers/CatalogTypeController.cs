using Catalog.Host.Models.Requests.CatalogBrandRequests;
using Catalog.Host.Models.Requests.CreateRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateRequest request)
    {
        var result = await _catalogTypeService.Add(request.Name);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteRequest request)
    {
        var result = await _catalogTypeService.Delete(request.Id);
        return Ok(new DeleteItemResponse() { IsSuccess = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateRequest request)
    {
        var result = await _catalogTypeService.Update(request.Id, request.NewName);
        return Ok(new UpdateResponse<int?>() { Id = result });
    }
}
