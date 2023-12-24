
namespace HomeworkModule2Lesson4.Models
{
    internal class Carrot : Ingridient
    {
        public string TypeOfMachining { get; set; }
        public string CuttingType { get; set; }
        public Carrot(int quantity, string typeOfMachining, string cuttingType)
        {
            Name = "Carrot";
            Type = "Vegetable";
            Quantity = quantity;
            Color = "Orange";
            CaloriesPerKilo = 400;
            TypeOfMachining = typeOfMachining;
            CuttingType = cuttingType;
        }
       
    }
}

