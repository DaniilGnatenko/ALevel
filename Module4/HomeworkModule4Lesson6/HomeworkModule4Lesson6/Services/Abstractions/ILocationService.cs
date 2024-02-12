using HomeworkModule4Lesson6.Models;

namespace HomeworkModule4Lesson6.Services.Abstractions;

public interface ILocationService
{
    Task<int> AddLocationAsync(string locationName);
    Task<Location> GetLocation(int id);
    Task<int> UpdateLocation(int id, string locationName);
    Task<bool> DeleteLocation(int id);
}