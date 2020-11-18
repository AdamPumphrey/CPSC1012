using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDemo2
{
    public class Product
    {
        //private member fields
        private string _name;
        private double _price;
        private double _cost;
        private int _quantityOnHand;

        //public accessors & mutators
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 2)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Name must be at least 2 characters");
                }
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Price must be at least 0");
                }
            }
        }

        public double Cost
        {
            get { return _cost; }
            set
            {
                if (value >= 0)
                {
                    _cost = value;
                }
                else
                {
                    throw new Exception("Cost must be at least 0");
                }
            }
        }

        public int QuantityOnHand
        {
            get { return _quantityOnHand; }
            set
            {
                if (value >= 0)
                {
                    _quantityOnHand = value;
                }
                else
                {
                    throw new Exception("Quantity on hand must be at least 0");
                }
            }
        }

        //constructor(s)
        public Product(string name, double price, double cost, int quantityOnHand)
        {
            Name = name;
            Price = price;
            Cost = cost;
            QuantityOnHand = quantityOnHand;
        }

        //class methods
        public double InventoryPrice()
        {
            return Price * QuantityOnHand;
        }

        public double InventoryCost()
        {
            return Cost * QuantityOnHand;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1:0.00}, Cost: {2:0.00}, QOH: {3}", Name, Price, Cost, 
                QuantityOnHand);
        }

    }//eoc
}//eon
