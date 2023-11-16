using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Repositories.Abstractions;
using System.Numerics;

namespace HomeworkModule2Lesson6.Repositories
{
    internal class House : IHouse
    {
        private readonly int _maximumWatt = 5000;
        private  int _totalConsumption = 0;
        private ElectricalApplianceEntity[] _plugedInAppliances = new ElectricalApplianceEntity[0];
        private int _plugedInIndex = 0;
        public int CalculateConsumption()
        {
            for (int i = 0; i < _plugedInAppliances.Length; i++)
            {
                _totalConsumption += _plugedInAppliances[i].Consumption;
            }
            return _totalConsumption;
        }
        public void ShowPlugedInAppliances()
        {
            Console.WriteLine("Plugged in electrical appliances:");
            for (int i = 0; i < _plugedInAppliances.Length; i++)
            {
                Console.WriteLine($"ID: {_plugedInAppliances[i].Id}. {_plugedInAppliances[i].Name} in {_plugedInAppliances[i].Room}");
            }
        }
        public ElectricalAppliance[] FindAppliance(string name)
        {
            ElectricalAppliance[] plugged = new ElectricalAppliance[0];
            int pluggedLength = 0;
            foreach (var item in _plugedInAppliances)
            {
                if (item.Name == name)
                {
                    pluggedLength++;
                    Array.Resize(ref plugged, pluggedLength);
                    ElectricalAppliance electricalAppliance = new ElectricalAppliance()
                    {
                        Name = item.Name,
                        Id = item.Id,
                        Room = item.Room,
                        Consumption = item.Consumption,
                        Connection = item.Connection,
                    };
                    plugged[pluggedLength - 1] = electricalAppliance;
                }
            }
            return plugged;
        }

        public void PlugIn(ElectricalAppliance electricalAppliance)
        {
            ElectricalApplianceEntity electricalApplianceEntity = new ElectricalApplianceEntity()
            {
                Name = electricalAppliance.Name,
                Room = electricalAppliance.Room,
                Connection = electricalAppliance.Connection,
                Consumption = electricalAppliance.Consumption,
                Id = electricalAppliance.Id

            };
            _totalConsumption += electricalApplianceEntity.Consumption;
            if (_totalConsumption < _maximumWatt)
            {
                int arrayLength = _plugedInAppliances.Length + 1;
                Array.Resize(ref _plugedInAppliances, arrayLength);
                _plugedInAppliances[_plugedInIndex] = electricalApplianceEntity;
                _plugedInIndex++;
                Console.WriteLine("Succesfully pluged in {0}! Total Consumption: {1}", electricalApplianceEntity.Name, _totalConsumption);

            }
            else
            {
                Console.WriteLine("You have exceeded the power limit! Total consumprion with this appliance: {0}", _totalConsumption);
                _totalConsumption -= electricalApplianceEntity.Consumption;
            }
        }

        public ElectricalAppliance PlugOut(int id)
        {
            ElectricalApplianceEntity[] tempArray = new ElectricalApplianceEntity[_plugedInAppliances.Length - 1];
            int index = 0;
            ElectricalAppliance electricalAppliance = new ElectricalAppliance();
            if (Array.Exists(_plugedInAppliances, element => element.Id == id))
            {
                for (int i = 0; i < _plugedInAppliances.Length; i++)
                {
                    if (_plugedInAppliances[i].Id == id)
                    {
                        _totalConsumption -= _plugedInAppliances[i].Consumption;
                        electricalAppliance = new ElectricalAppliance()
                        {
                            Name = _plugedInAppliances[i].Name,
                            Id = _plugedInAppliances[i].Id,
                            Connection = _plugedInAppliances[i].Connection,
                            Consumption = _plugedInAppliances[i].Consumption,
                            Room = _plugedInAppliances[i].Room
                        };
                        Console.WriteLine("Succesfully pluged out {0}! Total Consumption: {1}", _plugedInAppliances[i].Name, _totalConsumption);
                    }
                    else
                    {
                        tempArray[index] = _plugedInAppliances[i];
                        index++;
                    }
                }
            }
            
            _plugedInAppliances = tempArray;
            return electricalAppliance;
        }

        public void SortAppliancesByConnection()
        {
            _plugedInAppliances = _plugedInAppliances.OrderBy(x => x.Connection).ToArray();
        }
    }
}
