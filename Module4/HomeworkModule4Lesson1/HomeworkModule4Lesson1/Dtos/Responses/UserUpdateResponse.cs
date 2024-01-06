namespace HomeworkModule4Lesson1.Dtos.Responses;

public class UserUpdateResponse
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Id { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}