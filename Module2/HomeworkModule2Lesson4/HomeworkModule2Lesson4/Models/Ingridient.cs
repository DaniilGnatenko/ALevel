
namespace HomeworkModule2Lesson4.Models
{
    internal abstract class Ingridient 
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CaloriesPerKilo { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}
