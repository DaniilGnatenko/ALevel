using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Models;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeworkModule4Lesson6.Services;

public class PetService : BaseDataService<PetDBContext>, IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly ILogger<PetService> _loggerService;
    public PetService(
        IDbContextWrapper<PetDBContext> dbContextWrapper,
        ILogger<BaseDataService<PetDBContext>> logger,
        IPetRepository petRepository,
        ILogger<PetService> loggerService
        ) : base(dbContextWrapper, logger)
    {
        _petRepository = petRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddPetAsync(string name, int age, int breedId, int locationId, int categoryId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var id = await _petRepository.AddPetAsync(name, age, breedId, locationId, categoryId);
            _loggerService.LogInformation($"Created pet with Id = {id}");
            return id;
        });
    }

    public async Task<bool> DeletePetById(int id)
    {
        var pet = await _petRepository.GetPetById(id);

        if (pet == null)
        {
            _loggerService.LogWarning($"Not founded pet with Id = {id}");
            return false;
        }

        await _petRepository.DeletePetById(pet.Id);
        return true;
    }

    public async Task<Pet> GetPetById(int id)
    {
        var pet = await _petRepository.GetPetById(id);

        if (pet == null)
        {
            _loggerService.LogWarning($"Not founded pet with Id = {id}");
            return null!;
        }

        return new Pet()
        {
            Id = pet.Id,
            Name = pet.Name,
            Age = pet.Age,
            Breed = new Breed()
            {
                Id = pet.BreedId,
                BreedName = pet.Breed.BreedName
            },
            Category = new Category()
            {
                Id = pet.CategoryId,
                CategoryName = pet.Category.CategoryName
            },
            Location = new Location()
            {
                Id = pet.LocationId,
                LocationName = pet.Location.LocationName
            }
        };
    }

    public async Task<int> UpdatePet(int id, string name, int age)
    {
        var pet = await _petRepository.GetPetById(id);

        if (pet == null)
        {
            _loggerService.LogWarning($"Not founded pet with Id = {id}");
            return 0;
        }

        await _petRepository.UpdatePet(id, name, age);
        return pet.Id;
    }
    public async Task<IList<PetGroupResult>> GetGroupedPetsAsync(int minAge, string locationName)
    {
        return await _petRepository.GetGroupedPetsAsync(minAge, locationName);
    }
}
