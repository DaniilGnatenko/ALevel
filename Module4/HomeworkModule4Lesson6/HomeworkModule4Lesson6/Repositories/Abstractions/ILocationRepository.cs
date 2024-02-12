using HomeworkModule4Lesson6.Data.Entities;

namespace HomeworkModule4Lesson6.Repositories.Abstractions;

public interface ILocationRepository
{
    Task<int> AddLocationAsync(string locationName);
    Task<LocationEntity?> GetLocation(int id);
    Task<int> UpdateLocation(int id, string locationName);
    Task<bool> DeleteLocation(int id);
}
