using HomeworkModule2Lesson6.Common;
using HomeworkModule2Lesson6.Entities;
using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Repositories.Abstractions;
using System;

namespace HomeworkModule2Lesson6.Repositories
{
    internal class ElectricalAppliances : IElectricalAppliances
    {
        private ElectricalApplianceEntity[] _electricalAppliancesEntity = new ElectricalApplianceEntity[0];

        public void AddAppliance(ElectricalAppliance electricalAppliance)
        {
            var electricalApplianceEntity = new ElectricalApplianceEntity()
            {
                Name = electricalAppliance.Name,
                Id = electricalAppliance.Id,
                Room = electricalAppliance.Room,
                Consumption = electricalAppliance.Consumption,
                Connection = electricalAppliance.Connection
            };
            int arrayLength = _electricalAppliancesEntity.Length + 1;
            Array.Resize(ref _electricalAppliancesEntity, arrayLength);
            _electricalAppliancesEntity[arrayLength - 1] = electricalApplianceEntity;
        }
        public void AddAppliances(List<ElectricalAppliance> electricalAppliances)
        {
            int arrayLength = electricalAppliances.Count;
            Array.Resize(ref _electricalAppliancesEntity, arrayLength);
            int index = 0;
            foreach (var item in electricalAppliances)
            {
                var electricalApplianceEntity = new ElectricalApplianceEntity()
                {
                    Name = item.Name,
                    Id = item.Id,
                    Room = item.Room,
                    Consumption = item.Consumption,
                    Connection = item.Connection
                };
                _electricalAppliancesEntity[index] = electricalApplianceEntity;
                index += 1;
            }
        }

        public void ShowAppliances()
        {
            Console.WriteLine("Available electrical appliances to plug in:");
            for (int i = 0; i < _electricalAppliancesEntity.Length; i++)
            {
                Console.WriteLine($"ID: {_electricalAppliancesEntity[i].Id}. {_electricalAppliancesEntity[i].Name} in {_electricalAppliancesEntity[i].Room}.");
            }
        }
        public ElectricalAppliance PlugInAppliance(int id)
        {
            ElectricalApplianceEntity[] tempArray = new ElectricalApplianceEntity[_electricalAppliancesEntity.Length - 1];
            ElectricalAppliance electricalAppliance = new ElectricalAppliance();
            int index = 0;
            if ( Array.Exists(_electricalAppliancesEntity, i => i.Id == id))
            {
                for (int i = 0; i < _electricalAppliancesEntity.Length; i++)
                {
                    if (_electricalAppliancesEntity[i].Id == id)
                    {
                        electricalAppliance = new ElectricalAppliance()
                        {
                            Name = _electricalAppliancesEntity[i].Name,
                            Id = _electricalAppliancesEntity[i].Id,
                            Connection = _electricalAppliancesEntity[i].Connection,
                            Consumption = _electricalAppliancesEntity[i].Consumption,
                            Room = _electricalAppliancesEntity[i].Room
                        };
                    }
                    else
                    {
                        tempArray[index] = _electricalAppliancesEntity[i];
                        index++;
                    }
                }
            }
            
            _electricalAppliancesEntity = tempArray;
            return electricalAppliance;
        }
        public ElectricalAppliance[] FindAppliance(string name)
        {
            ElectricalAppliance[] unplugged = new ElectricalAppliance[0];
            int unpluggedLength = 0;
            foreach (var item in _electricalAppliancesEntity)
            {
                if (item.Name == name)
                {
                    unpluggedLength++;
                    Array.Resize(ref unplugged, unpluggedLength);
                    ElectricalAppliance electricalAppliance = new ElectricalAppliance()
                    {
                        Name = item.Name,
                        Id = item.Id,
                        Room = item.Room,
                        Consumption = item.Consumption,
                        Connection = item.Connection,
                    };
                    unplugged[unpluggedLength - 1] = electricalAppliance;
                }
            }
            return unplugged;
        }
        public void PlugOutAppliance(ElectricalAppliance electricalAppliance)
        {
            ElectricalApplianceEntity electricalApplianceEntity = new ElectricalApplianceEntity()
            {
                Name = electricalAppliance.Name,
                Room = electricalAppliance.Room,
                Connection = electricalAppliance.Connection,
                Consumption = electricalAppliance.Consumption,
                Id = electricalAppliance.Id

            };
            int arrayLength = _electricalAppliancesEntity.Length + 1;
            Array.Resize(ref _electricalAppliancesEntity, arrayLength);
            _electricalAppliancesEntity[_electricalAppliancesEntity.Length - 1] = electricalApplianceEntity;
        }

        public void SortAppliancesByID()
        {
            _electricalAppliancesEntity = _electricalAppliancesEntity.OrderBy(x => x.Id).ToArray();
        }
    }
}
