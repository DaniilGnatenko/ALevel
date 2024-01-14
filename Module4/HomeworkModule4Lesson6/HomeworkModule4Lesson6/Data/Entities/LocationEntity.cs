namespace HomeworkModule4Lesson6.Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }
    public string LocationName { get; set; } = null!;
    public virtual List<PetEntity>? Pets { get; set; }
}
