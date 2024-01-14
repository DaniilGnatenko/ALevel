using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeworkModule4Lesson6.Repositories;

public class LocationRepository : ILocationRepository
{

    private readonly PetDBContext _dbContext;

    public LocationRepository(
        IDbContextWrapper<PetDBContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    public async Task<int> AddLocationAsync(string locationName)
    {
        var location = new LocationEntity()
        {
            LocationName = locationName
        };

        var result = await _dbContext.Locations.AddAsync(location);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        var result = await _dbContext.Locations.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return false;
        }

        _dbContext.Locations.Remove(result);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<LocationEntity?> GetLocation(int id)
    {
        return await _dbContext.Locations.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<int> UpdateLocation(int id, string locationName)
    {
        var result = await _dbContext.Locations.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return 0;
        }

        result.LocationName = locationName;
        await _dbContext.SaveChangesAsync();
        return result.Id;
    }
}
