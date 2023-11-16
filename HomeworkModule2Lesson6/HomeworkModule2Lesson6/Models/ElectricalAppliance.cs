using HomeworkModule2Lesson6.Common;

namespace HomeworkModule2Lesson6.Models
{
    internal class ElectricalAppliance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
        public int Consumption { get; set; }
        public ConnectionType Connection { get; set; }
    }
}
