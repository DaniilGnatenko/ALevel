
using HomeworkModule2Lesson4.Models;

namespace HomeworkModule2Lesson4.Services.Abstractions
{
    internal interface ISaladService
    {
        void AddNewIngridient(Ingridient ingridient);
        decimal CalculateCaloriesInSalad();
        void FindIngridientbyType();
        void SortSalad();

    }
}
