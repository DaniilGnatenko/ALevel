using HomeworkModule4Lesson6.Models;

namespace HomeworkModule4Lesson6.Services.Abstractions;

public interface IBreedService
{
    Task<int> AddBreedAsync(string breedName, int categoryId);
    Task<Breed> GetBreedById(int id);
    Task<int> UpdateBreed(int id, string breedName);
    Task<bool> DeleteBreedById(int id);
}