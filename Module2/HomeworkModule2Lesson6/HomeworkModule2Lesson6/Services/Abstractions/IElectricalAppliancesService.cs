using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson6.Services.Abstractions
{
    internal interface IElectricalAppliancesService
    {
        void SortAppliancesByID();
        void ShowAppliances();
        ElectricalAppliance[] FindAppliance(string name);
        void AddAppliance(ElectricalAppliance electricalAppliance);
        void AddAppliances(List<ElectricalAppliance> electricalAppliances);
        ElectricalAppliance PlugInAppliance(int id);
        void PlugOutAppliance(ElectricalAppliance electricalAppliance);
    }
}
