
namespace HomeworkModule2Lesson4.Models
{
    internal class Egg : Ingridient
    {
        public string TypeOfMachining { get; set; }
        public string CuttingType { get; set; }
        public Egg(int quantity, string typeOfMachining, string cuttingType)
        {
            Name = "Egg";
            Type = "Product of animal origin";
            Quantity = quantity;
            Color = "White";
            CaloriesPerKilo = 1400;
            TypeOfMachining = typeOfMachining;
            CuttingType = cuttingType;
        }
       
    }
}
