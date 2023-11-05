using HomeworkOnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnlineStore.Services
{
    internal class Order
    {
        private ProductsList productsList = ProductsList.GetInstance;
        private ShoppingCart shoppingCart = ShoppingCart.GetInstance;
        private int _orderId = new Random().Next(200,5000);
        private DateTime _created = DateTime.Now;
        private string[] productsInOrder = new string[0];

        private static Order instance;
        private Order()
        {

        }

        public static Order GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Order();
                }
                return instance;
            }
        }
        public void ShowCreatedOrder()
        {
            if (shoppingCart.productsInCart.Count == 0) 
            {
                Console.WriteLine("You don't have products in your cart!");
            }
            else if (shoppingCart.productsInCart.Count >= 1)
            {
                double totalPrice = 0;
                int orderLength = shoppingCart.productsInCart.Count;
                Array.Resize(ref productsInOrder, orderLength);
                for (int i = 0; i < shoppingCart.productsInCart.Count; i++)
                {
                    productsInOrder[i] = shoppingCart.productsInCart[i].Name;
                    totalPrice += shoppingCart.amountProductInCart[i] * shoppingCart.productsInCart[i].Price;
                }
                Console.WriteLine("Creating new order...");
                Console.WriteLine("Your order created!");
                Console.WriteLine("{0}\n Order Number: {1}\n Products: {2}.\n Total Price: {3:N2}", _created, _orderId, string.Join(',', productsInOrder), totalPrice);
            }
            
        }
    }
}
