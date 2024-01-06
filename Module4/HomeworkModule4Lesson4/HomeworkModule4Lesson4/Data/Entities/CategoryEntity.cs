namespace HomeworkModule4Lesson4.Data.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public virtual List<PetEntity> Pets { get; set; }
}
