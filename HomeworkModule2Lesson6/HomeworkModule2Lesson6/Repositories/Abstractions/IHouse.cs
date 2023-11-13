using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;

namespace HomeworkModule2Lesson6.Repositories.Abstractions
{
    internal interface IHouse
    {
        void PlugIn(ElectricalAppliance electricalAppliance);
        ElectricalAppliance PlugOut(int id);
        void ShowPlugedInAppliances();
        ElectricalAppliance[] FindAppliance(string name);
        void SortAppliancesByConnection();
        int CalculateConsumption();
    }
}
