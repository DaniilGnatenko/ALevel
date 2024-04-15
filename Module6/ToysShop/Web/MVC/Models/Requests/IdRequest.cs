namespace MVC.Models.Requests
{
    public class IdRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
