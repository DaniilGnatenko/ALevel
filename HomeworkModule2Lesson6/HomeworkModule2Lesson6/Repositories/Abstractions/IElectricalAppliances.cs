using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;

namespace HomeworkModule2Lesson6.Repositories.Abstractions
{
    internal interface IElectricalAppliances
    {
        void AddAppliance(ElectricalAppliance electricalAppliance);
        void AddAppliances(List<ElectricalAppliance> electricalAppliances);
        void ShowAppliances();
        void SortAppliancesByID();
        ElectricalAppliance[] FindAppliance(string name);
        ElectricalAppliance PlugInAppliance(int id);
        void PlugOutAppliance(ElectricalAppliance electricalAppliance);
    }
}
