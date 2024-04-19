namespace MVC.Models.Requests;

public class PaginatedItemsRequest<T>
    where T : notnull
{
    [Range(0, int.MaxValue)]
    public int PageIndex { get; set; }
    [Range(0, 50)]
    public int PageSize { get; set; }
    public Dictionary<T, int>? Filters { get; set; }
}