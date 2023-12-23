using HomeworkModule2Lesson6.Common;
using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Repositories;
using HomeworkModule2Lesson6.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson6.Services
{
    internal class UserService : IUserService
    {
        private readonly IElectricalAppliancesService _iElectricalAppliancesService;
        private readonly IHouseService _iHouseService;

        public UserService(IElectricalAppliancesService iElectricalAppliancesService, IHouseService iHouseService)
        {
            _iElectricalAppliancesService = iElectricalAppliancesService;
            _iHouseService = iHouseService;
        }
        public void FindAppliance(string name)
        {
            ElectricalAppliance[] plugged = _iHouseService.FindAppliance(name);
            ElectricalAppliance[] unplugged = _iElectricalAppliancesService.FindAppliance(name);
            if (plugged.Length > 0)
            {
                foreach (var item in plugged)
                {
                    Console.WriteLine("{0} plugged in {1}", item.Name, item.Room);
                }
            }
            if (unplugged.Length > 0)
            {
                foreach (var item in unplugged)
                {
                    Console.WriteLine("{0} in {1} unplugged!", item.Name, item.Room);
                }
            }

        }

        public void PlugIn(int id)
        {
            
            _iHouseService.PlugIn(_iElectricalAppliancesService.PlugInAppliance(id));
        }

        public void PlugOut(int id)
        {
            _iElectricalAppliancesService.PlugOutAppliance(_iHouseService.PlugOut(id));
        }
    }
}
