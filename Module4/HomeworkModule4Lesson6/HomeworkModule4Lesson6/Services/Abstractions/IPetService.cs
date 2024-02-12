using HomeworkModule4Lesson6.Models;

namespace HomeworkModule4Lesson6.Services.Abstractions;

public interface IPetService
{
    Task<int> AddPetAsync(string name, int age, int breedId, int locationId, int categoryId);
    Task<Pet> GetPetById(int id);
    Task<int> UpdatePet(int id, string name, int age);
    Task<bool> DeletePetById(int id);
    Task<IList<PetGroupResult>> GetGroupedPetsAsync(int minAge, string locationName);
}