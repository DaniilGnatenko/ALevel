namespace HomeworkModule4Lesson4.Data.Entities;

public class BreedEntity
{
    public int Id { get; set; }
    public string BreedName { get; set; }
    public int CategoryID { get; set; }
    public virtual CategoryEntity Category { get; set; }
    public virtual List<PetEntity> Pets { get; set; }
}
