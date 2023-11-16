using HomeworkModule2Lesson6.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson6.Entities
{
    internal class ElectricalApplianceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
        public int Consumption { get; set; }
        public ConnectionType Connection { get; set; }
    }
}
