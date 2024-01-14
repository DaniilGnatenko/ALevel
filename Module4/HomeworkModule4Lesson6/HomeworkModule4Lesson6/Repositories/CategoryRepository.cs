using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HomeworkModule4Lesson6.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly PetDBContext _dbContext;

    public CategoryRepository(
        IDbContextWrapper<PetDBContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    public async Task<int> AddCategoryAsync(string categoryName)
    {
        var category = new CategoryEntity()
        {
            CategoryName = categoryName
        };

        var result = await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return false;
        }

        _dbContext.Categories.Remove(result);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CategoryEntity?> GetCategory(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<int> UpdateCategory(int id, string categoryName)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return 0;
        }

        result.CategoryName = categoryName;
        await _dbContext.SaveChangesAsync();

        return result.Id;
    }
}
