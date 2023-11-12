
namespace HomeworkModule2Lesson4.Models
{
    internal class Pickle : Ingridient
    {
        public string TypeOfMachining { get; set; }
        public string CuttingType { get; set; }
        public Pickle(int quantity, string typeOfMachining, string cuttingType)
        {
            Name = "Pickle";
            Type = "Vegetable";
            Quantity = quantity;
            Color = "Green";
            CaloriesPerKilo = 105;
            TypeOfMachining = typeOfMachining;
            CuttingType = cuttingType;
        }
        
    }
}
