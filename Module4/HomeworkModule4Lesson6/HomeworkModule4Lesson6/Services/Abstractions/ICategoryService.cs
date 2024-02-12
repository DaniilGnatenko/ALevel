using HomeworkModule4Lesson6.Models;

namespace HomeworkModule4Lesson6.Services.Abstractions;

public interface ICategoryService
{
    Task<int> AddCategoryAsync(string categoryName);
    Task<Category> GetCategory(int id);
    Task<int> UpdateCategory(int id, string categoryName);
    Task<bool> DeleteCategory(int id);
}