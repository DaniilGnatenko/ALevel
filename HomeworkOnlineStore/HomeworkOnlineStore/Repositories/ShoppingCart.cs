using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkOnlineStore.Models;

namespace HomeworkOnlineStore.Repositories
{
    internal class ShoppingCart
    {
        private ProductsList productList = ProductsList.GetInstance;
        private static ShoppingCart instance;
        private ShoppingCart()
        {
            
        }

        public static ShoppingCart GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingCart();
                }
                return instance;
            }
        }
        public List<Product> productsInCart = new List<Product>();
        public List<int> amountProductInCart = new List<int>();

        public void AddToCart(int productID)
        {
            
            if (!productsInCart.Contains(productList.productsList[productID - 1]))
            {
                productsInCart.Add(productList.productsList[productID - 1]);
                amountProductInCart.Add(1);
                Console.WriteLine("You added {0}", productList.productsList[productID - 1].Name);
                
            }
            else if (productsInCart.Contains(productList.productsList[productID - 1]))
            {
                int productIndex = productsInCart.IndexOf(productList.productsList[productID - 1]);
                amountProductInCart.Insert(productIndex, amountProductInCart[productIndex] + 1);
                amountProductInCart.RemoveAt(productIndex + 1);
                Console.WriteLine("You added {0}", productList.productsList[productID - 1].Name);
            }
        }

        public void RemoveFromCart(int productID)
        {
            int productIndex = productsInCart.IndexOf(productList.productsList[productID - 1]);
            if (productsInCart.Contains(productList.productsList[productID - 1]) && amountProductInCart[productIndex] > 1)
            {
                amountProductInCart.Insert(productIndex, amountProductInCart[productIndex] - 1);
                amountProductInCart.RemoveAt(productIndex + 1);
                Console.WriteLine("You removed {0}", productList.productsList[productID - 1].Name);
            }
            else if (productsInCart.Contains(productList.productsList[productID - 1]) && amountProductInCart[productIndex] == 1)
            {
                productsInCart.RemoveAt(productIndex);
                amountProductInCart.RemoveAt(productIndex);
                Console.WriteLine("You removed {0}", productList.productsList[productID - 1].Name);
            }
            else if (!productsInCart.Contains(productList.productsList[productID - 1]))
            {
                
                Console.WriteLine("You don't have this in your cart!");
            }
        }
        public void ShowCart()
        {
            for (int i = 0;  i < productsInCart.Count; i++)
            {
                Console.WriteLine("Products in your cart: {0} amount {1} price per one {2:N2}", productsInCart[i].Name, amountProductInCart[i], productsInCart[i].Price);
                
            }
        }
    }
}


