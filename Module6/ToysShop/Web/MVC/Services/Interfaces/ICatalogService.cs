using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog<CatalogItem>> GetCatalogItems(int page, int take, int? brand, int? type);
    Task<CatalogItem> GetItem(int id);
    Task<IEnumerable<SelectListItem>> GetBrands(int page, int take);
    Task<IEnumerable<SelectListItem>> GetTypes(int page, int take);
}
