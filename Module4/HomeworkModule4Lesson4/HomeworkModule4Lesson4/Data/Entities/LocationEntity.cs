namespace HomeworkModule4Lesson4.Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }
    public string LocationName { get; set; }
    public virtual List<PetEntity> Pets { get; set; }
}
