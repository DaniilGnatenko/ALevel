namespace Catalog.Host.Models.Responses
{
    public class UpdateResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
