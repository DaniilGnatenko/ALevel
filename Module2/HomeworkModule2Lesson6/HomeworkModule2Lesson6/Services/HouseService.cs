using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Repositories.Abstractions;
using HomeworkModule2Lesson6.Services.Abstractions;

namespace HomeworkModule2Lesson6.Services
{
    internal class HouseService : IHouseService
    {
        private readonly IHouse _house;

        public HouseService(IHouse house)
        {
            _house = house;
        }
        public void CalculateConsumption()
        {
            _house.CalculateConsumption();
        }
        public void ShowPlugedInAppliances()
        {
            _house.ShowPlugedInAppliances();
        }

        public ElectricalAppliance[] FindAppliance(string name)
        {
            return _house.FindAppliance(name);
        }

        public void PlugIn(ElectricalAppliance electricalAppliance)
        {
            _house.PlugIn(electricalAppliance);
        }

        public ElectricalAppliance PlugOut(int id)
        {
            return _house.PlugOut(id);
        }

        public void SortAppliances()
        {
            _house.SortAppliancesByConnection();
        }
    }
}
