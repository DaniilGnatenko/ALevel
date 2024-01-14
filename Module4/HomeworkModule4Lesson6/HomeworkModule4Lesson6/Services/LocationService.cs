using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Models;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace HomeworkModule4Lesson6.Services;

public class LocationService : BaseDataService<PetDBContext>, ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<PetService> _loggerService;
    public LocationService(
        IDbContextWrapper<PetDBContext> dbContextWrapper,
        ILogger<BaseDataService<PetDBContext>> logger,
        ILocationRepository locationRepository,
        ILogger<PetService> loggerService
        ) : base(dbContextWrapper, logger)
    {
        _locationRepository = locationRepository;
        _loggerService = loggerService;
    }
    public async Task<int> AddLocationAsync(string locationName)
    {
        var id = await _locationRepository.AddLocationAsync(locationName);
        _loggerService.LogInformation($"Created location with Id = {id}");
        return id;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        var result = await _locationRepository.GetLocation(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded location with Id = {id}");
            return false;
        }

        await _locationRepository.DeleteLocation(result.Id);
        _loggerService.LogInformation($"Deleted location with Id = {result.Id}");
        return true;
    }

    public async Task<Location> GetLocation(int id)
    {
        var result = await _locationRepository.GetLocation(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded location with Id = {id}");
            return null!;
        }

        return new Location()
        {
            Id = result.Id,
            LocationName = result.LocationName
        };
    }

    public async Task<int> UpdateLocation(int id, string locationName)
    {
        var result = await _locationRepository.GetLocation(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded location with Id = {id}");
            return 0;
        }

        await _locationRepository.UpdateLocation(result.Id, locationName);
        _loggerService.LogInformation($"Updated location with Id = {result.Id}");
        return result.Id;
    }
}
