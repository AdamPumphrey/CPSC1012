using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_AdamPumphrey_Exercise7.Classes
{
    public class Product
    {
        private string _name,
                       _description;

        private double _price;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 3)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Name of product must be at least 3 characters.");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length >= 3)
                {
                    _description = value;
                }
                else
                {
                    throw new Exception("Description of product must be at least 3 characters.");
                }
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Price must be greater than 0.");
                }
            }
        }

        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0,-15} {1,-50} {2:c}", Name, Description, Price);
        }
    }
}
