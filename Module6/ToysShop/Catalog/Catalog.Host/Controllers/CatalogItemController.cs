using Catalog.Host.Models.Requests.CatalogProductRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteRequest request)
    {
        var result = await _catalogItemService.Delete(request.Id);
        return Ok(new DeleteItemResponse() { IsSuccess = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateProductRequest request)
    {
        var result = await _catalogItemService.Update(request.Id, request.Name, request.Description, request.Price, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new UpdateResponse<int?>() { Id = result });
    }
}
