
namespace HomeworkModule2Lesson4.Models
{
    internal class Salt : Ingridient
    {
        public Salt(int quantity)
        {
            Name = "Salt";
            Type = "Spice";
            Quantity = quantity;
            Color = "White";
            CaloriesPerKilo = 0;
        }
    }
}
