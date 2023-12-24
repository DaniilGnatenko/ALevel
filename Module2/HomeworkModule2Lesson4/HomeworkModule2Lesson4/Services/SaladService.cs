using HomeworkModule2Lesson4.Models;
using HomeworkModule2Lesson4.Repositories.Abstractions;
using HomeworkModule2Lesson4.Services.Abstractions;

namespace HomeworkModule2Lesson4.Services
{
    internal class SaladService : ISaladService
    {
        private readonly ISalad _salad;

        public SaladService(ISalad salad)
        {
            _salad = salad;
        }
        public void AddNewIngridient(Ingridient ingridient)
        {
            Console.WriteLine("Added new ingridient: {0}, quantity {1}", ingridient.Name, ingridient.Quantity);
            _salad.AddNewIngridient(ingridient);
        }

        public decimal CalculateCaloriesInSalad()
        {
            decimal calories = _salad.CalculateCaloriesInSalad();
            return calories;
        }

        public void FindIngridientbyType()
        {
            List<Ingridient> foundTypes = _salad.FindIngridientbyType("Vegetable");
            Console.WriteLine($"Found {foundTypes.Count} {foundTypes[0].Type}s:");
            foreach (Ingridient foundType in foundTypes)
            {
                Console.WriteLine(foundType.Name);
            }
        }

        public void SortSalad()
        {
            List<Ingridient> sortedSalad = _salad.SortSalad();
            foreach (Ingridient sortedIngridient in sortedSalad)
            {
                Console.WriteLine("Ingridient: {0}, Quantity {1}", sortedIngridient.Name, sortedIngridient.Quantity);
            }

        }
    }
}
