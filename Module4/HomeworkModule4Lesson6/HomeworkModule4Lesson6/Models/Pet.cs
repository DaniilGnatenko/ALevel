namespace HomeworkModule4Lesson6.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public Category? Category { get; set; }
    public Breed? Breed { get; set; }
    public Location? Location { get; set; }
}
