namespace HomeworkModule4Lesson6.Data.Entities;

public class PetEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string? ImageURL { get; set; }
    public string? Description { get; set; }
    public int BreedId { get; set; }
    public int CategoryId { get; set; }
    public int LocationId { get; set; }
    public virtual BreedEntity? Breed { get; set; }
    public virtual CategoryEntity? Category { get; set; }
    public virtual LocationEntity? Location { get; set; }
}
