namespace HomeworkModule4Lesson1.Dtos.Responses;

public class BaseResponse<T>
    where T : class
{
    public T Data { get; set; }
    public SupportDto Support { get; set; }
}