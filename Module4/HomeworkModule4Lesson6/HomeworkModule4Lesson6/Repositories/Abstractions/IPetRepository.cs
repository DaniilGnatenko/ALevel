using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Models;

namespace HomeworkModule4Lesson6.Repositories.Abstractions;

public interface IPetRepository
{
    Task<int> AddPetAsync(string name, int age, int breedId, int locationId, int categoryId);
    Task<PetEntity?> GetPetById(int id);
    Task<int> UpdatePet(int id, string name, int age);
    Task<bool> DeletePetById(int id);
    Task<IList<PetGroupResult>> GetGroupedPetsAsync(int minAge, string locationName);
}
