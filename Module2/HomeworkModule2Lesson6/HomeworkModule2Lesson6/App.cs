using HomeworkModule2Lesson6.Models;
using HomeworkModule2Lesson6.Services;
using HomeworkModule2Lesson6.Services.Abstractions;

namespace HomeworkModule2Lesson6
{
    internal class App
    {
        private readonly IElectricalAppliancesService _electricalApplianceService;
        private readonly IHouseService _houseService;
        private readonly IUserService _userService;


        public App(IElectricalAppliancesService electricalApplianceService, IHouseService houseService, IUserService userService)
        {
            _electricalApplianceService = electricalApplianceService;
            _houseService = houseService;
            _userService = userService;
        }
        public void Run()
        {
            _electricalApplianceService.AddAppliances(GetMockElectricalAppliance());
            _electricalApplianceService.AddAppliance(new ElectricalAppliance()
            {
                Name = "XBox Series X",
                Id = 14,
                Room = Common.Room.Hall,
                Consumption = 500,
                Connection = Common.ConnectionType.Socket
            });
            Console.WriteLine("Hello! You returned home! What do you want to do?");
            UserCommands();

            _electricalApplianceService.ShowAppliances();
            UserActivities();

            Console.ReadLine();
        }
        private List<ElectricalAppliance> GetMockElectricalAppliance()
        {
            var electricalAppliances = new List<ElectricalAppliance>
            {
                new ElectricalAppliance()
                {
                    Name = "Microwave",
                    Id = 1,
                    Room = Common.Room.Kitchen,
                    Consumption = 700,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Refrigerator",
                    Id = 2,
                    Room = Common.Room.Kitchen,
                    Consumption = 500,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Electric kettle",
                    Id = 3,
                    Room = Common.Room.Kitchen,
                    Consumption = 1000,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Electric grill",
                    Id = 4,
                    Room = Common.Room.Kitchen,
                    Consumption = 1500,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Computer",
                    Id = 5,
                    Room = Common.Room.Hall,
                    Consumption = 800,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "TV",
                    Id = 6,
                    Room = Common.Room.Hall,
                    Consumption = 500,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Table lamp",
                    Id = 7,
                    Room = Common.Room.Bedroom,
                    Consumption = 200,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Vacuum cleaner",
                    Id = 8,
                    Room = Common.Room.Hallway,
                    Consumption = 450,
                    Connection = Common.ConnectionType.Socket
                },

                new ElectricalAppliance()
                {
                    Name = "Chandelier",
                    Id = 9,
                    Room = Common.Room.Hallway,
                    Consumption = 120,
                    Connection = Common.ConnectionType.Wiring
                },

                new ElectricalAppliance()
                {
                    Name = "Chandelier",
                    Id = 10,
                    Room = Common.Room.Hall,
                    Consumption = 150,
                    Connection = Common.ConnectionType.Wiring
                },

                new ElectricalAppliance()
                {
                    Name = "Chandelier",
                    Id = 11,
                    Room = Common.Room.Kitchen,
                    Consumption = 120,
                    Connection = Common.ConnectionType.Wiring
                },

                new ElectricalAppliance()
                {
                    Name = "Chandelier",
                    Id = 12,
                    Room = Common.Room.Bedroom,
                    Consumption = 180,
                    Connection = Common.ConnectionType.Wiring
                },

                new ElectricalAppliance()
                {
                    Name = "Christmas lights",
                    Id = 13,
                    Room = Common.Room.Bedroom,
                    Consumption = 0,
                    Connection = Common.ConnectionType.BatteryPowered
                }
            };

            return electricalAppliances;
        }

        static void UserCommands()
        {
            Console.WriteLine("Write \"plug\" - if you want to plug in electrical appliance.");
            Console.WriteLine("Write \"unplug\" - if you want to unplug electrical appliance.");
            Console.WriteLine("Write \"find\" - if you want to find electrical appliance.");
            Console.WriteLine("Write \"show plugged\" - if you want to show plugged electrical appliances.");
            Console.WriteLine("Write \"show commands\" - if you want to show commands.");
            Console.WriteLine("Write \"show unplugged\" - if you want to show unplugged electrical appliances.");
            Console.WriteLine("Write \"sort\" - if you want to sort electrical appliances.");
            Console.WriteLine("Write \"exit\" - if you want to leave.");
        }

        public void UserActivities()
        {
            while (true)
            {
                Console.Write("Enter a command: ");
                string userChoiseVariable = Console.ReadLine().ToLower();
                switch (userChoiseVariable)
                {
                    case "plug":
                        string userProductID = string.Empty;
                        do
                        {
                            Console.WriteLine("Please, enter ID of electrical appliance:");
                            userProductID = Console.ReadLine();
                            int.TryParse(userProductID, out int result);
                            if (result >= 0 && result <= 14)
                            {
                                int productID = result;
                                _userService.PlugIn(productID);
                            }
                            else
                            {
                                Console.WriteLine("Wrong ID!");
                                break;
                            }
                            
                        } while (!int.TryParse(userProductID, out int id));
                        break;

                    case "unplug":

                        do
                        {
                            Console.WriteLine("Please, enter ID of electrical appliance:");
                            userProductID = Console.ReadLine();
                            int.TryParse(userProductID, out int result);
                            if (result >= 0 && result <= 14)
                            {
                                int productID = result;
                                _userService.PlugOut(productID);
                            }
                            else
                            {
                                Console.WriteLine("Wrong ID!");
                                break;
                            }

                        } while (!int.TryParse(userProductID, out int id));
                        break;
                    case "find":
                        Console.WriteLine("Please, enter Name of electrical appliance:");
                        userProductID = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(userProductID))
                        {
                            Console.Write("Please, enter Name of electrical appliance:");
                            userProductID = Console.ReadLine();
                        }
                        _userService.FindAppliance(userProductID);
                        break;
                    case "show commands":
                        UserCommands();
                        break;
                    case "show plugged":
                        _houseService.SortAppliances();
                        _houseService.ShowPlugedInAppliances();
                        break;
                    case "show unplugged":
                        _electricalApplianceService.SortAppliancesByID();
                        _electricalApplianceService.ShowAppliances();
                        break;
                    case "exit":
                        Console.Clear();
                        Console.WriteLine("Press <Enter> only to exit");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }


            }
        }
    }
}

