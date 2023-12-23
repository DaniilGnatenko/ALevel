using NewYearGift.Models;
using NewYearGift.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace NewYearGift.Services
{
    internal class UserAction
    {
        private GiftBox giftBox = GiftBox.GetInstance;
        private SortSweets sortSweets = new SortSweets();
        private FindSweet findSweet = new FindSweet();
        private Sweet sweet = new Sweet();
        static void UserCommands()
        {

            Console.WriteLine("Write \"show box\" - to show your New Year Gift box.");
            Console.WriteLine("Write \"sort\" - to sort your New Year Gift box by mass.");
            Console.WriteLine("Write \"show sorted\" - to show sorted by mass New Year Gift box.");
            Console.WriteLine("Write \"find\" - if you want to find some sweet by name.");
            Console.WriteLine("Write \"show finded\" - to show finded sweets.");
            Console.WriteLine("Write \"exit\" - if you want to leave.");
        }

        public void Start()
        {
            UserCommands();
            giftBox.CreateChildrenGiftBox();
            while (true)
            {

                Console.Write("Enter a command: ");
                string userChoiseVariable = Console.ReadLine().ToLower();
                switch (userChoiseVariable)
                {
                    case "show box":
                        giftBox.ShowGiftBox();
                        break;
                    case "sort":
                        sortSweets.SortSweetsByMass();
                        break;
                    case "show sorted":
                        sortSweets.ShowSortedBox();
                        break;
                    case "show finded":
                        findSweet.ShowFindedSweets();
                        break;
                    case "find":
                        for (int i = 0; i < sweet.names.Length; i++)
                        {
                            Console.WriteLine("Possible name: {0}", sweet.names[i]);
                        }
                        Console.Write("Please, write sweet name that you want to find:");
                        string userChoice = Console.ReadLine();
                        while (!sweet.names.Contains(userChoice))
                        {
                            Console.WriteLine("Wrong sweet name!");
                            Console.Write("Please, write sweet name, that you want to find:");
                            userChoice = Console.ReadLine();
                        }
                        findSweet.FindSweetsByName(userChoice);
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
