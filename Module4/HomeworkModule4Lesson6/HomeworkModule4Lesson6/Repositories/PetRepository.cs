using Microsoft.EntityFrameworkCore;
using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using HomeworkModule4Lesson6.Models;


namespace HomeworkModule4Lesson6.Repositories;

public class PetRepository : IPetRepository
{
    private readonly PetDBContext _dbContext;

    public PetRepository(
        IDbContextWrapper<PetDBContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddPetAsync(string name, int age, int breedId, int locationId, int categoryId)
    {
        var petEntity = new PetEntity()
        {
            Name = name,
            Age = age,
            Breed = _dbContext.Breeds.FirstOrDefault(f => f.Id == breedId),
            Category = _dbContext.Categories.FirstOrDefault(f => f.Id == categoryId),
            Location = _dbContext.Locations.FirstOrDefault(f => f.Id == locationId)
        };
        await _dbContext.Pets.AddAsync(petEntity);
        await _dbContext.SaveChangesAsync();

        return petEntity.Id;
    }

    public async Task<PetEntity?> GetPetById(int id)
    {
        return await _dbContext.Pets.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<bool> DeletePetById(int id)
    {
        var petEntity = await _dbContext.Pets.FirstOrDefaultAsync(f => f.Id == id);

        if (petEntity == null)
        {
            return false;
        }

        _dbContext.Pets.Remove(petEntity);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<int> UpdatePet(int id, string name, int age)
    {
        var petEntity = await _dbContext.Pets.FirstOrDefaultAsync(f => f.Id == id);

        var newPetEntity = new PetEntity()
        {
            Name = name,
            Age = age
        };
        petEntity = newPetEntity;
        await _dbContext.SaveChangesAsync();
        return petEntity.Id;
    }

    public async Task<IList<PetGroupResult>> GetGroupedPetsAsync(int minAge, string locationName)
    {
        var query = from pet in _dbContext.Pets
                    where pet.Age > minAge && pet.Location.LocationName == locationName
                    group pet by new { pet.Category.CategoryName } into groupedPets
                    select new PetGroupResult
                    {
                        CategoryName = groupedPets.Key.CategoryName,
                        BreedCount = groupedPets.Select(p => p.Breed.BreedName).Distinct().Count()
                    };

        return await query.ToListAsync();
    }
}
