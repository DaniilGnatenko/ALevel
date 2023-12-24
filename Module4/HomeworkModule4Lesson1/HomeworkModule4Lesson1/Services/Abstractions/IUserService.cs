using HomeworkModule4Lesson1.Dtos.Responses;
using HomeworkModule4Lesson1.Dtos;

namespace HomeworkModule4Lesson1.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job);
}

