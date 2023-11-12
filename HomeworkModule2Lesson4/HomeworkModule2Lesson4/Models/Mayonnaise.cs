
namespace HomeworkModule2Lesson4.Models
{
    internal class Mayonnaise : Ingridient
    {
        public Mayonnaise(int quantity)
        {
            Name = "Mayonnaise";
            Type = "Sauce";
            Quantity = quantity;
            Color = "White with yellow";
            CaloriesPerKilo = 6790;
        }
       
    }
}
