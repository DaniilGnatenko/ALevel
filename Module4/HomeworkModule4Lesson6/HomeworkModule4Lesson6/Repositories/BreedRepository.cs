using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeworkModule4Lesson6.Repositories;

public class BreedRepository : IBreedRepository
{
    private readonly PetDBContext _dbContext;

    public BreedRepository(
        IDbContextWrapper<PetDBContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    public async Task<int> AddBreedAsync(string breedName, int categoryId)
    {
        var breed = new BreedEntity()
        {
            BreedName = breedName,
            CategoryId = categoryId
        };

        var result = await _dbContext.Breeds.AddAsync(breed);
        await _dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<bool> DeleteBreedById(int id)
    {
        var result = await _dbContext.Breeds.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return false;
        }

        _dbContext.Breeds.Remove(result);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<BreedEntity?> GetBreedById(int id)
    {
        return await _dbContext.Breeds.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<int> UpdateBreed(int id, string breedName)
    {
        var result = await _dbContext.Breeds.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return 0;
        }

        result.BreedName = breedName;
        await _dbContext.SaveChangesAsync();

        return result.Id;
    }
}
