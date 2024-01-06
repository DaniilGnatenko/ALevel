using HomeworkModule4Lesson1.Dtos.Responses;
using HomeworkModule4Lesson1.Dtos;

namespace HomeworkModule4Lesson1.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserDto[]> GetUsersFromPage(int page);
    Task<ResourceDto> GetResourceById(int id);
    Task<ResourceDto[]> GetResources();
    Task<UserResponse> CreateUser(string name, string job);
    Task<UserUpdateResponse> UpdateUserByPut(int id, string name, string job);
    Task<UserUpdateResponse> UpdateUserByPatch(int id, string name, string job);
    Task DeleteUserByID(int id);
    Task<RegistrationResponse> RegisterUser(string email, string password);
    Task<UnsuccessfulResponse> UnsuccessfulRegistration(string email);
    Task<RegistrationResponse> LoginUser(string email, string password);
    Task<UnsuccessfulResponse> UnsuccessfulLogin(string email);
    Task<UserDto[]> GetUsersWithDelay(int delay);
}