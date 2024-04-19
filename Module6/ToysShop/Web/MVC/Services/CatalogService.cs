using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models.Requests;
using MVC.Models.Enums;
using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.Models.Responses;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Catalog<CatalogItem>> GetCatalogItems(int page, int take, int? brand, int? type)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (brand.HasValue && brand != 1)
        {
            filters.Add(CatalogTypeFilter.Brand, brand.Value);
        }

        if (type.HasValue && type != 1)
        {
            filters.Add(CatalogTypeFilter.Type, type.Value);
        }

        var result = await _httpClient.SendAsync<Catalog<CatalogItem>, PaginatedItemsRequest<CatalogTypeFilter>>(
            $"{_settings.Value.CatalogUrl}/items",
            HttpMethod.Post,
            new PaginatedItemsRequest<CatalogTypeFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filters = filters
            });

        return result;
    }

    public async Task<CatalogItem> GetItem(int id)
	{
		var result = await _httpClient.SendAsync<CatalogItem, IdRequest>(
			$"{_settings.Value.CatalogUrl}/item",
			HttpMethod.Post,
			new IdRequest() { Id = id });

		return result;
	}

    public async Task<IEnumerable<SelectListItem>> GetBrands(int page, int take)
    {
        var result = await _httpClient.SendAsync<Catalog<CatalogBrand>, PaginatedRequest>(
            $"{_settings.Value.CatalogUrl}/brands",
            HttpMethod.Post,
            new PaginatedRequest()
           {
               PageIndex = page,
               PageSize = take
           });

        return result.Data.Select(x => new SelectListItem()
        {
            Value = x.Id.ToString(),
            Text = x.BrandName
        }).OrderBy(x => x.Value);
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes(int page, int take)
    {
        var result = await _httpClient.SendAsync<Catalog<CatalogType>, PaginatedRequest>(
            $"{_settings.Value.CatalogUrl}/types",
            HttpMethod.Post,
            new PaginatedRequest()
          {
              PageIndex = page,
              PageSize = take
          });

        return result.Data.Select(x => new SelectListItem()
        {
            Value = x.Id.ToString(),
            Text = x.TypeName
        }).OrderBy(x => x.Value);
    }
}
