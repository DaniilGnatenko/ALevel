namespace HomeworkModule4Lesson6.Data.Entities;

public class BreedEntity
{
    public int Id { get; set; }
    public string BreedName { get; set; } = null!;
    public int CategoryId { get; set; }

    public virtual CategoryEntity? Category { get; set; }
    public virtual List<PetEntity>? Pets { get; set; }
    
}
