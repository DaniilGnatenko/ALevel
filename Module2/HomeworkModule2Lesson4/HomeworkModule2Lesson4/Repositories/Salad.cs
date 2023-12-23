using HomeworkModule2Lesson4.Models;
using HomeworkModule2Lesson4.Repositories.Abstractions;
using HomeworkModule2Lesson4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson4.Repositories
{
    internal class Salad : ISalad
    {
        public decimal CalorieCount { get; set; }
        public int Weight { get; set; }
        public List<Ingridient> listOfIngridients = new List<Ingridient>();
        public List<Ingridient> sortedListOfIngridients = new List<Ingridient>();

        public Salad()
        {

        }

        public string AddNewIngridient(Ingridient ingridient)
        {
            listOfIngridients.Add(ingridient);
            return ingridient.Name;
        }

        public decimal CalculateCaloriesInSalad()
        {
            for (int i = 0; i < listOfIngridients.Count; i++)
            {
                int kilogramm = 1000;
                decimal calories = Decimal.Divide(listOfIngridients[i].Quantity, kilogramm) * listOfIngridients[i].CaloriesPerKilo;
                CalorieCount += calories;
            }
            return CalorieCount;
        }

        public List<Ingridient> FindIngridientbyType(string type)
        {
            List<Ingridient> foundTypes = listOfIngridients.FindAll(x => x.Type == type);

            return foundTypes;
        }

        public List<Ingridient> SortSalad()
        {
            sortedListOfIngridients = listOfIngridients.OrderByDescending(x => x.Quantity).ToList();

            return sortedListOfIngridients;
        }
    }
}
