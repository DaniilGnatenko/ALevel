using NewYearGift.Models;
using NewYearGift.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearGift.Services
{
    internal class SortSweets
    {
        private GiftBox giftBox = GiftBox.GetInstance;
        public Sweet[] sortedSweetBox = Array.Empty<Sweet>();
        public void SortSweetsByMass()
        {
            int sortedSweetBoxLength = giftBox.sweetsInBox.Length;
            Array.Resize(ref sortedSweetBox, sortedSweetBoxLength);
            for (int i = 0; i < sortedSweetBoxLength; i++)
            {
                sortedSweetBox[i] = giftBox.sweetsInBox[i];
            }
            
            Array.Sort(sortedSweetBox, CompareByMass);
        }

        public void ShowSortedBox()
        {
            for (int i = 0; i < sortedSweetBox.Length; i++)
            {
                Console.WriteLine("Sweets in your box {0:N2} weight", sortedSweetBox[i].mass);
            }
        }
        public static int CompareByMass(Sweet sweet1, Sweet sweet2)
        {
            return sweet2.mass.CompareTo(sweet1.mass);
        }

    }
}

