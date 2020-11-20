using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSC1012_AdamPumphrey_Exercise7.Classes;

/*
Purpose:        Create program that lets user add products and display once finished
Input:          product name, product description, product price
Output:         product name, product description, product price
Written By:     Adam Pumphrey
Last Modified:  Nov. 20, 2020
*/

namespace CPSC1012_AdamPumphrey_Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            // not sure why AddProduct needed to return the amount of items added
            int count = AddProduct(products);

            DisplayProducts(products);

            Console.ReadLine();
        }

        static int AddProduct(List<Product> products)
        {
            char stop;
            bool isValid = false;

            do
            {
                products.Add(new Product(GetSafeString("Enter name of a product: "), GetSafeString(" Product's Description: "), GetSafeDouble("\tProduct's price: ")));

                stop = GetSafeChar("\nAdd another product (y/n): ");
                if (stop == 'N')
                {
                    isValid = true;
                }
            } while (!isValid);

            return products.Count;
        }

        static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("\nProducts\n" + new string('=', 8) + "\n{0,-15} {1,-50} {2}", "Name", "Description", "Price");
            foreach (Product item in products)
            {
                Console.WriteLine(item);
            }
        }

        static string GetSafeString(string prompt)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
                if (name.Length > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);
            return name;
        }

        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                // validate char input
                try
                {
                    Console.Write(prompt);
                    character = char.Parse(Console.ReadLine().ToUpper());
                    if (character == 'Y' || character == 'N')
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return valid char input
            return character;
        }

        static double GetSafeDouble(string prompt)
        {
            double number = 1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,20}", prompt);
                    number = double.Parse(Console.ReadLine());
                    if (number > 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid number ... try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid number ... try again");
                }
            } while (!isValid);
            return number;
        }
    }
}
