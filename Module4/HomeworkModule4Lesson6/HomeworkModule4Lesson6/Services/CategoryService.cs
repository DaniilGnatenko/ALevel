using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Models;
using HomeworkModule4Lesson6.Repositories;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace HomeworkModule4Lesson6.Services;

public class CategoryService : BaseDataService<PetDBContext>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<PetService> _loggerService;
    public CategoryService(
        IDbContextWrapper<PetDBContext> dbContextWrapper,
        ILogger<BaseDataService<PetDBContext>> logger,
        ICategoryRepository categoryRepository,
        ILogger<PetService> loggerService
        ) : base(dbContextWrapper, logger)
    {
        _categoryRepository = categoryRepository;
        _loggerService = loggerService;
    }
    public async Task<int> AddCategoryAsync(string categoryName)
    {
        var id = await _categoryRepository.AddCategoryAsync(categoryName);
        _loggerService.LogInformation($"Created category with Id = {id}");
        return id;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var result = await _categoryRepository.GetCategory(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded category with Id = {id}");
            return false;
        }

        await _categoryRepository.DeleteCategory(result.Id);
        _loggerService.LogInformation($"Deleted category with Id = {result.Id}");
        return true;
    }

    public async Task<Category> GetCategory(int id)
    {
        var result = await _categoryRepository.GetCategory(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded category with Id = {id}");
            return null!;
        }

        return new Category()
        {
            Id = result.Id,
            CategoryName = result.CategoryName
        };
    }

    public async Task<int> UpdateCategory(int id, string categoryName)
    {
        var result = await _categoryRepository.GetCategory(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded category with Id = {id}");
            return 0;
        }

        await _categoryRepository.UpdateCategory(result.Id, categoryName);
        _loggerService.LogInformation($"Updated category with Id = {result.Id}");
        return result.Id;
    }
}
