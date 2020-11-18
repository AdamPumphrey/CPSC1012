using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDemo2
{
    public class Store
    {
        //private member fields
        private string _storeName;
        //public accessors & mutators
        public string StoreName
        {
            get { return _storeName; }
            set
            {
                if (value.Length >= 2)
                {
                    _storeName = value;
                }
                else
                {
                    throw new Exception("Store name must be at least 2 characters");
                }
            }
        }

        public List<Product> Products
        {
            get { return Products; }
            set { Products = value; }
        }
        //constructor(s)
        public Store(string storeName, List<Product> products)
        {
            StoreName = storeName;
            Products = products;
        }
        //class methods
        public double TotalInventoryCost()
        {
            double total = 0;
            foreach (Product item in Products)
            {
                total += item.InventoryCost();
            }

            return total;
        }

        public double TotalInventoryPrice()
        {
            double total = 0;
            foreach (Product item in Products)
            {
                total += item.InventoryPrice();
            }

            return total;
        }

        public string DisplayStore()
        {
            string output;
            output = string.Format("Store Name: {0}\n", StoreName);
            foreach (Product item in Products)
            {
                output += string.Format("{0}\n", item.ToString());
            }
            return output;
        }
    }//eoc
}//eon
