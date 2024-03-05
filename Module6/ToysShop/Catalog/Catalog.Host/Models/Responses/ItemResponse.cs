using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Models.Responses
{
    public class ItemResponse<CatalogItemDto>
    {
        public CatalogItemDto Item { get; set; }
    }
}
