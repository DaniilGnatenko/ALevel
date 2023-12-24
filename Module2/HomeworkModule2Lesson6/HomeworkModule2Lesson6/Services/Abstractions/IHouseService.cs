using HomeworkModule2Lesson6.Models;

namespace HomeworkModule2Lesson6.Services.Abstractions
{
    internal interface IHouseService
    {
        void PlugIn(ElectricalAppliance electricalAppliance);
        void ShowPlugedInAppliances();
        ElectricalAppliance PlugOut(int id);
        ElectricalAppliance[] FindAppliance(string name);
        void SortAppliances();
        void CalculateConsumption();
    }
}
