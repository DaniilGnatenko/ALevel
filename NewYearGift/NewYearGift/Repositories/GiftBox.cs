using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NewYearGift.Models;

namespace NewYearGift.Repositories
{
    internal class GiftBox
    {
        public int maxMass = 1000;
        private static GiftBox instance;

        public GiftBox()
        {

        }
        public static GiftBox GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GiftBox();
                }
                return instance;
            }
        }

        public Sweet[] sweetsInBox = new Sweet[0];
        double massInBox = 0;
        public void CreateChildrenGiftBox()
        {
            
            int sweetsAmount = 0;
            int sweetIndex = 0;
            while (massInBox <= maxMass)
            {
                sweetsAmount++;
                Array.Resize(ref sweetsInBox, sweetsAmount);
                int typeOfSweet = new Random().Next(1, 8);
                switch (typeOfSweet)
                {
                    case 1:
                        Sweet sweet = new Sweet();
                        sweetsInBox[sweetIndex] = sweet;
                        massInBox += sweet.mass;
                        sweetIndex++;
                        break;
                    case 2:
                        Cookie cookie = new Cookie();
                        sweetsInBox[sweetIndex] = cookie;
                        massInBox += cookie.mass;
                        sweetIndex++;
                        break;
                    case 3:
                        ChocolateBar chocolateBar = new ChocolateBar();
                        sweetsInBox[sweetIndex] = chocolateBar;
                        massInBox += chocolateBar.mass;
                        sweetIndex++;
                        break;
                    case 4:
                        Candy candy = new Candy();
                        sweetsInBox[sweetIndex] = candy;
                        massInBox += candy.mass;
                        sweetIndex++;
                        break;
                    case 5:
                        ChocolateCandy chocolateCandy = new ChocolateCandy();
                        sweetsInBox[sweetIndex] = chocolateCandy;
                        massInBox += chocolateCandy.mass;
                        sweetIndex++;
                        break;
                    case 6:
                        ChocolateCandyWithFilling chocolateCandyWithFilling = new ChocolateCandyWithFilling();
                        sweetsInBox[sweetIndex] = chocolateCandyWithFilling;
                        massInBox += chocolateCandyWithFilling.mass;
                        sweetIndex++;
                        break;
                    case 7:
                        MarmaladeCandy marmaladeCandy = new MarmaladeCandy();
                        sweetsInBox[sweetIndex] = marmaladeCandy;
                        massInBox += marmaladeCandy.mass;
                        sweetIndex++;
                        break;
                }
            }
        }
        public void ShowGiftBox()
        {
            Console.WriteLine("Your Gift Box weight: {0}", massInBox);
            for (int i = 0; i < sweetsInBox.Length; i++)
            {
                Console.WriteLine("In your gift box: {0}",sweetsInBox[i].name);
            }
        }

    }
}
