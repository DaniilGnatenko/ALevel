using HomeworkModule4Lesson6.Data.Entities;

namespace HomeworkModule4Lesson6.Repositories.Abstractions;

public interface IBreedRepository
{
    Task<int> AddBreedAsync(string breedName, int categoryId);
    Task<BreedEntity?> GetBreedById(int id);
    Task<int> UpdateBreed(int id, string breedName);
    Task<bool> DeleteBreedById(int id);
}