using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkOnlineStore.Models;

namespace HomeworkOnlineStore.Repositories
{
    internal class ProductsList
    {
        public Product[] productsList = new Product[10];
        private readonly string[] productNames = new string[10] { "bread", "milk", "ice cream",
            "beer", "eggs", "ham",
            "Coca Cola", "cucumber", "tomato",
            "Snikers" };
        private int[] _amountInStore = new int[10];
        private static ProductsList instance;

        public int[] AmountInStore {  get { return _amountInStore; } }
        private ProductsList()
        {
            for (int i = 0; i < productsList.Length; i++)
            {
                productsList[i] = new Product();
                _amountInStore[i] = new Random().Next(3,16);
            }
        }

        public static ProductsList GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsList();
                }
                return instance;
            }
        }

        public void ShowProductsList()
        {
            for (int i = 0; i < productsList.Length; i++)
            {
                productsList[i].ProductID = i + 1;
                productsList[i].Name = productNames[i];
                
                Console.WriteLine("ProductID: {0} Product: {1}, price: {2:N2}, amount {3}", productsList[i].ProductID, productsList[i].Name, productsList[i].Price, _amountInStore[i]);
            }
        }

        public void TakeProductFromList(int productIndex)
        {
            if (_amountInStore[productIndex - 1] > 0)
            {
                _amountInStore[productIndex - 1] -= 1;
            }
            else
            {
                Console.WriteLine("This product is out of stock.");
            }
        }

        public void ReturnProductToList(int productIndex)
        {
            _amountInStore[productIndex - 1] += 1;
        }
    }
}
