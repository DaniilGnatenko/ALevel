namespace MVC.Models.Requests;

public class PaginatedRequest
{
    [Range(0, int.MaxValue)]
    public int PageIndex { get; set; }
    [Range(0, 50)]
    public int PageSize { get; set; }
}