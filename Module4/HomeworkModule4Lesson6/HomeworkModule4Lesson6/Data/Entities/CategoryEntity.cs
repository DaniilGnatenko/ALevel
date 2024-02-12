namespace HomeworkModule4Lesson6.Data.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public virtual List<PetEntity>? Pets { get; set; }
    public virtual List<BreedEntity>? Breeds { get; set; }
}
