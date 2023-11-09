
namespace HomeworkModule2Lesson4.Models
{
    internal class GreenPea : Ingridient
    {
        public string TypeOfMachining { get; set; }
        public GreenPea(int quantity, string typeOfMachining)
        {
            Name = "GreenPea";
            Type = "Vegetable";
            Quantity = quantity;
            Color = "Green";
            CaloriesPerKilo = 730;
            TypeOfMachining = typeOfMachining;
        }
        
    }
}
