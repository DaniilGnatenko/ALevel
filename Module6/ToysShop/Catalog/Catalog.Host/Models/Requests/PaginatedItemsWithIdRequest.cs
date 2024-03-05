namespace Catalog.Host.Models.Requests;

public class PaginatedItemsWithIdRequest
{
    public int Id { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
