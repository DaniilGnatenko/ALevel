using HomeworkOnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnlineStore.Services
{
    internal class UserActions
    {
        private ProductsList productsList = ProductsList.GetInstance;
        private ShoppingCart shoppingCart = ShoppingCart.GetInstance;
        private Order order = Order.GetInstance;

        static void UserCommands()
        {
            Console.WriteLine("Write \"add\" - if you want to add product to your cart.");
            Console.WriteLine("Write \"remove\" - if you want to remove product from your cart.");
            Console.WriteLine("Write \"create\" - if you want to create order.");
            Console.WriteLine("Write \"show cart\" - if you want to show your cart.");
            Console.WriteLine("Write \"show commands\" - if you want to show commands.");
            Console.WriteLine("Write \"show list\" - if you want to show your products list.");
            Console.WriteLine("Write \"exit\" - if you want to leave.");
        }

        public void Start()
        {
            Console.WriteLine("Hello! Welcome to our store!");
            Console.WriteLine("We have this products:");
            productsList.ShowProductsList();
            UserCommands();
            while (true)
            {

                Console.Write("Enter a command: ");
                string userChoiseVariable = Console.ReadLine().ToLower();
                switch (userChoiseVariable)
                {
                    case "add":
                        Console.Write("Please, write Product ID that you want to add:");
                        string userProductID = Console.ReadLine();
                        int productID;
                        while (!int.TryParse(userProductID, out productID) && productID > 10)
                        {
                            Console.WriteLine("Wrong Product ID!");
                            Console.Write("Please, write Product ID that you want to add:");
                            userProductID = Console.ReadLine();
                        }
                        if (productsList.AmountInStore[productID - 1] >= 1)
                        {
                            shoppingCart.AddToCart(productID);
                            productsList.TakeProductFromList(productID);
                        }
                        else if (productsList.AmountInStore[productID -1] < 1)
                        {
                            productsList.TakeProductFromList(productID);
                        }
                        break;
                    case "remove":
                        Console.Write("Please, write Product ID that you want to remove:");
                        userProductID = Console.ReadLine();
                        while (!int.TryParse(userProductID, out productID) && productID > 10)
                        {
                            Console.WriteLine("Wrong Product ID!");
                            Console.Write("Please, write Product ID that you want to add:");
                            productID = Convert.ToInt32(Console.ReadLine());
                        }
                        shoppingCart.RemoveFromCart(productID);
                        productsList.ReturnProductToList(productID);
                        break;
                    case "create":
                        order.ShowCreatedOrder();
                        return;
                    case "show commands":
                        UserCommands();
                        break;
                    case "show cart":
                        if (shoppingCart.productsInCart.Count == 0)
                        {
                            Console.WriteLine("Your cart is empty!");
                        }
                        shoppingCart.ShowCart();
                        break;
                    case "show list":
                        productsList.ShowProductsList();
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
