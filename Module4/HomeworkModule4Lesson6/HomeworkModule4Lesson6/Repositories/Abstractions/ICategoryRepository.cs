using HomeworkModule4Lesson6.Data.Entities;

namespace HomeworkModule4Lesson6.Repositories.Abstractions;

public interface ICategoryRepository
{
    Task<int> AddCategoryAsync(string categoryName);
    Task<CategoryEntity?> GetCategory(int id);
    Task<int> UpdateCategory(int id, string categoryName);
    Task<bool> DeleteCategory(int id);
}
