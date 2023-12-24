using System;

namespace HomeworkModule2Lesson4.Models
{
    internal class Potato : Ingridient
    {
        public string TypeOfMachining { get; set; }
        public string CuttingType { get; set; }
        public Potato(int quantity, string typeOfMachining, string cuttingType)
        {
            Name = "Potato";
            Type = "Vegetable";
            Quantity = quantity;
            Color = "Yellow";
            CaloriesPerKilo = 820;
            TypeOfMachining = typeOfMachining;
            CuttingType = cuttingType;
        }
    }
}
