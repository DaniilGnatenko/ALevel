using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Repositories.Abstractions;
using HomeworkModule2Lesson6.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson6.Services
{
    internal class ElectricalAppliancesService : IElectricalAppliancesService
    {
        private readonly IElectricalAppliances _electricalAppliances;

        public ElectricalAppliancesService(IElectricalAppliances electricalAppliances) 
        {
            _electricalAppliances = electricalAppliances;
        }
        public void AddAppliance(ElectricalAppliance electricalAppliance)
        {
            _electricalAppliances.AddAppliance(electricalAppliance);
        }
        public void AddAppliances(List<ElectricalAppliance> electricalAppliance)
        {
            _electricalAppliances.AddAppliances(electricalAppliance);
        }

        public ElectricalAppliance PlugInAppliance(int id)
        {
            return _electricalAppliances.PlugInAppliance(id);
        }

        public void PlugOutAppliance(ElectricalAppliance electricalAppliance)
        {
            _electricalAppliances.PlugOutAppliance(electricalAppliance);
        }

        public ElectricalAppliance[] FindAppliance(string name)
        {
            return _electricalAppliances.FindAppliance(name);
        }
        public void ShowAppliances()
        {
            _electricalAppliances.ShowAppliances();
        }

        public void SortAppliancesByID()
        {
            _electricalAppliances.SortAppliancesByID();
        }
    }
}
