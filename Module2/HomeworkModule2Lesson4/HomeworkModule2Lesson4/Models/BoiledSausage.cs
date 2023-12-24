
namespace HomeworkModule2Lesson4.Models
{
    internal class BoiledSausage : Sausage
    {

        public string TypeOfMachining { get; set; }
        public string CuttingType { get; set; }

        public BoiledSausage(int quantity, string machiningType, string cuttingType)
        {
            Name = "Boiled Sausage";
            Type = "Meat";
            Quantity = quantity;
            Color = "Pink";
            CaloriesPerKilo = 2570;
            TypeOfMachining = machiningType;
            CuttingType = cuttingType;
            MeatType = "Pork";
            percentOfMeat = 75;

        }

       
    }
}
