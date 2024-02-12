namespace HomeworkModule4Lesson6.Models;

public sealed class Breed
{
    public int Id { get; set; }
    public string BreedName { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
