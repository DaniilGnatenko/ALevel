using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnlineStore.Models
{
    internal class Product
    {
        private double _price;
        private string _name;
        private int _productID;

        public Product()
        {
            _price = new Random().NextDouble() * 10;
        }

        public double Price { get { return _price; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int ProductID { get { return _productID; } set { _productID = value; } }


    }

    internal class CartProducts : Product
    {
        private int _amount;

        public int Amount { get { return _amount; } set { _amount = value; } }
    }
}
