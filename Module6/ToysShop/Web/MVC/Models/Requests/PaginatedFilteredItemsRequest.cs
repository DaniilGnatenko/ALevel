namespace MVC.Models.Requests;

public class PaginatedFilteredItemsRequest
{
    public int Id { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
