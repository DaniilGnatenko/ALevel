using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewYearGift.Models;
using NewYearGift.Repositories;

namespace NewYearGift.Services
{
    internal class FindSweet
    {
        private GiftBox giftBox = GiftBox.GetInstance;
        public Sweet[] findedSweets = new Sweet[0];
        public void FindSweetsByName(string userCriteria)
        {
            int findedSweetsLength = 0;
            int findedSweetsIndex = 0;
            for (int i = 0; i < giftBox.sweetsInBox.Length; i++)
            {
                if (StringExtensions.CompareSweetsNames(userCriteria, giftBox.sweetsInBox[i]))
                {
                    findedSweetsLength++;
                    Array.Resize(ref findedSweets, findedSweetsLength);
                    findedSweets[findedSweetsIndex] = giftBox.sweetsInBox[i];
                    findedSweetsIndex++;
                }
            }
        }
        public void ShowFindedSweets()
        {
            for (int i = 0;i < findedSweets.Length;i++)
            {
                findedSweets[i].ShowSweet();
            }
        }

    }



    static class StringExtensions
    {
        public static bool CompareSweetsNames(string UserCriteria, Sweet sweet)
        {
            return sweet.name.Contains(UserCriteria);
        }
    }
}