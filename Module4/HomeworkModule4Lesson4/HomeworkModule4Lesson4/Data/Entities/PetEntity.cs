namespace HomeworkModule4Lesson4.Data.Entities;

public class PetEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? CategoryId { get; set; }
    public int? BreedId { get; set; }
    public double Age { get; set; }
    public int? LocationId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public virtual CategoryEntity Category { get; set; }
    public virtual BreedEntity Breed { get; set; }
    public virtual LocationEntity Location { get; set;}
}
