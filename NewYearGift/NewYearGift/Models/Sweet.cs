using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearGift.Models
{
    interface IShowSweet
    {
        void ShowSweet()
        {
            
        }
    }
   
    internal class Sweet : IShowSweet
    {
        public int length;
        public int height;
        public int width;
        public int volume;
        public double density;
        public double mass;
        public string[] names = new string[10] { "Snikers", "Mars", "Bounty", "Roshen", "AVK", "Konti", "Milky Way", "Twix", "Milka", "Nestle" };
        public string name;
        
        public Sweet()
        {
            length = new Random().Next(1, 8);
            height = new Random().Next(1, 6);
            width = new Random().Next(1, 4);
            volume = length * height * width;
            density = new Random().NextDouble();
            mass = density * volume;
            name = names[new Random().Next(0, 10)];
        }

        public void ShowSweet()
        {
            Console.WriteLine("This is {0} sweet", name);
        }

    }
    internal class Candy : Sweet, IShowSweet 
    {
        private string[] _wrapperTypes = new string[3] { "paper", "plastic", "without" };
        public string wrapper;

        public Candy()
        {
            wrapper = _wrapperTypes[new Random().Next(0, 3)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is candy {0} in {1} wrapper", name, wrapper);
        }
    }
    internal class ChocolateBar : Sweet, IShowSweet
    {
        private string[] _chocolateTypes = new string[3] { "milk", "dessert", "bitter" };
        public string chocolateType;
        public ChocolateBar()
        {
            chocolateType = _chocolateTypes[new Random().Next(0, 3)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is chocolate bar {0} with {1} chocolate", name, chocolateType);
        }
    }
    internal class Cookie : Sweet, IShowSweet
    {
        private string[] _chocolateTypes = new string[3] { "milk", "dessert", "bitter" };
        public string chocolateType;
        public Cookie()
        {
            chocolateType = _chocolateTypes[new Random().Next(0, 3)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is cookie {0} with {1} chocolate", name, chocolateType);
        }
    }

    internal class ChocolateCandy : Candy, IShowSweet
    {
        private string[] _chocolateTypes = new string[3] { "milk", "dessert", "bitter" };
        public string chocolateType;
        public ChocolateCandy()
        {
            chocolateType = _chocolateTypes[new Random().Next(0, 3)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is candy {0} in {1} wrapper with {2} chocolate", name, wrapper, chocolateType);
        }
    }
    internal class MarmaladeCandy : Candy, IShowSweet
    {
        private string[] _fruitFlavors = new string[3] { "apple", "juice", "watermelon" };
        public string flavor;
        public MarmaladeCandy()
        {
            flavor = _fruitFlavors[new Random().Next(0, 3)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is marmalade candy {0} in {1} wrapper with {2} flavor", name, wrapper, flavor);
        }
    }
    internal class ChocolateCandyWithFilling : ChocolateCandy, IShowSweet
    {
        private string[] _fillingTypes = new string[4] { "ganache", "truffle", "praline", "nougat" };
        public string filling;
        public ChocolateCandyWithFilling()
        {
            filling = _fillingTypes[new Random().Next(0, 4)];
        }
        public void ShowSweet()
        {
            Console.WriteLine("This is candy {0} in {1} wrapper with {2} chocolate and {3} filling", name, wrapper, chocolateType, filling);
        }
    }




}
