namespace Basket.Models.Dtos;

public class BasketDto
{
    public int TotalCount { get; set; }
    public int TotalPrice { get; set; }
    public List<CatalogItemDto>? Items { get; set; }
}
