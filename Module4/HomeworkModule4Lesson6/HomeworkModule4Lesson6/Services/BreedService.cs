using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Models;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HomeworkModule4Lesson6.Services;

public class BreedService : BaseDataService<PetDBContext>, IBreedService
{
    private readonly IBreedRepository _breedRepository;
    private readonly ILogger<PetService> _loggerService;
    public BreedService(
        IDbContextWrapper<PetDBContext> dbContextWrapper,
        ILogger<BaseDataService<PetDBContext>> logger,
        IBreedRepository breedRepository,
        ILogger<PetService> loggerService
        ) : base(dbContextWrapper, logger)
    {
        _breedRepository = breedRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddBreedAsync(string breedName, int categoryId)
    {
        var id = await _breedRepository.AddBreedAsync(breedName, categoryId);
        _loggerService.LogInformation($"Created breed with Id = {id}");
        return id;
    }

    public async Task<bool> DeleteBreedById(int id)
    {
        var result = await _breedRepository.GetBreedById(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded breed with Id = {id}");
            return false;
        }

        await _breedRepository.DeleteBreedById(result.Id);
        _loggerService.LogInformation($"Deleted breed with Id = {result.Id}");
        return true;
    }

    public async Task<Breed> GetBreedById(int id)
    {
        var result = await _breedRepository.GetBreedById(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded breed with Id = {id}");
            return null!;
        }

        return new Breed()
        {
            Id = result.Id,
            BreedName = result.BreedName
        };
    }

    public async Task<int> UpdateBreed(int id, string breedName)
    {
        var result = await _breedRepository.GetBreedById(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded breed with Id = {id}");
            return 0;
        }

        await _breedRepository.UpdateBreed(result.Id, breedName);
        _loggerService.LogInformation($"Updated breed with Id = {result.Id}");
        return result.Id;
    }
}
