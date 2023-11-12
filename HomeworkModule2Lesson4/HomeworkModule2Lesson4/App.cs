using HomeworkModule2Lesson4.Models;
using HomeworkModule2Lesson4.Services.Abstractions;

namespace HomeworkModule2Lesson4
{
    internal class App
    {
        private readonly ISaladService _saladService;
        public App(ISaladService saladService)
        {
            _saladService = saladService;
        }

        public void Start()
        {
            Console.WriteLine("Hello! Making new salad!");

            _saladService.AddNewIngridient(new BoiledSausage(300, "boiled", "diced"));

            _saladService.AddNewIngridient(new Carrot(80, "boiled", "diced"));

            _saladService.AddNewIngridient(new Pickle(300, "pickling", "diced"));

            _saladService.AddNewIngridient(new Egg(180, "boiled", "diced"));

            _saladService.AddNewIngridient(new Potato(450, "boiled", "diced"));

            _saladService.AddNewIngridient(new GreenPea(150, "canned"));

            _saladService.AddNewIngridient(new Mayonnaise(75));

            _saladService.AddNewIngridient(new Salt(10));

            Console.WriteLine("Now I'll count calories in salad!");
            Console.WriteLine("Calories in Salad : {0}", _saladService.CalculateCaloriesInSalad());

            Console.WriteLine("Now I'll find vegetables in salad!");
            _saladService.FindIngridientbyType();

            Console.WriteLine("Now I'll sort ingridients in salad by quantity!");
            _saladService.SortSalad();

        }
    }
}
