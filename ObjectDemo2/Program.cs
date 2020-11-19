using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		This demonstrates how to fully utilize class-level methods.
                1. Create & add Product instances
                2. Create & add Store instances
                3. Add Product instances to a Store instance
                4. Display Product and Store totals for Price and Cost

                This demo also utilizes the Generic List, List<T>, for the collection Products

                For future versions, we can:
                1. Input Product data from a file, or
                2. Output our Store data, or Product data to a file

Input:			Product.cs
                +-------------------------------------------------------------------------------+
                | Product                                                                       |
                +-------------------------------------------------------------------------------+
                | - name: String                                                                |
                | - price : Double                                                              |
                | - cost: Double                                                                |
                | - quantityOnHand: Integer                                                     |
                | + Name: String                                                                |
                | + Price: Double                                                               |
                | + Cost: Double                                                                |
                | + QuantityOnHand: Integer                                                     |
                +-------------------------------------------------------------------------------+
                | + Product(Name: String, Price: Double, Cost: Double, QuantityOnHand: Integer) |
                | + InventoryPrice() : Double                                                   |
                | + InventoryCost() : Double                                                    |
                | + ToString() : String                                                         |
                +-------------------------------------------------------------------------------+

                Store.cs
                +-------------------------------------------------------------------------------+
                | Store                                                                         |
                +-------------------------------------------------------------------------------+
                | - storeName : String                                                          |
                | - products : Product[]                                                        |
                | + StoreName : String                                                          |
                | + Products : Product[]                                                        |
                +-------------------------------------------------------------------------------+
                | + Store(StoreName : String, Products: Product[]                               |
                | + TotalInventoryCost() : Double                                               |
                | + TotalInventoryPrice() : Double                                              |
                | + DisplayStore()                                                              |
                +-------------------------------------------------------------------------------+

Output:			Data from both classes
Written By: 	Allan Anderson 
Last Modified:	 
*/

namespace ObjectDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            string name;
            double price,
                   cost;
            int quantityOnHand;

            //variables and class instances
            //1. As the Product class may throw an exception when we try to create an instance of the class,
            //   we will need to create the instance in a try-catch structure
            //try
            //{
            //    //attempt to create an instance
            //    name = GetSafeString("Enter product's name: ");
            //    price = GetSafeDouble("Enter product's price: ");
            //    cost = GetSafeDouble("Enter product's cost: ");
            //    quantityOnHand = GetSafeInt("Enter product's QOH: ");

            //    Product product = new Product(name, price, cost, quantityOnHand);

            //    Console.WriteLine(product);
            //    Console.WriteLine("Inventory cost: {0:0.00}", product.InventoryCost());
            //    Console.WriteLine("Inventory price: {0:0.00}", product.InventoryPrice());

            //    Console.WriteLine();

            //    product.Name = "Banana";
            //    product.Price = 3;
            //    product.Cost = 1.4;
            //    product.QuantityOnHand = 10;
            //    Console.WriteLine(product);
            //    Console.WriteLine("Inventory cost: {0:0.00}", product.InventoryCost());
            //    Console.WriteLine("Inventory price: {0:0.00}", product.InventoryPrice());

            //}//end try
            //catch (Exception ex)
            //{
            //    //display the exception thrown from the class
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("ERROR: {0}", ex.Message);
            //    Console.ForegroundColor = ConsoleColor.Black;
            //}//end catch

            //2. Create a Store instance and add Product instances to it. Once again, there may be an exception
            //   thrown, thus we need a try-catch structure
            try
            {
                //2.a Get a name for the store
                name = GetSafeString("Enter the name of the store: ");
                //2b. Create a collection for the Products
                List<Product> products = new List<Product>();
                //2c. Call the AddProducts() method to add Product instances to the collection
                AddProducts(products);
                //2d. Create a Store instance and add the collection of Product instances
                Store store = new Store(name, products);
                //Console.Clear();
                //2e. Call the DisplayStore() method of the Store class to display the store
                Console.WriteLine(store.DisplayStore());
            }//end try
            catch (Exception ex)
            {
                //display the exception thrown from the class(es)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: {0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }//end catch

            Console.ReadLine();
        }//eom

        #region User Defined Methods
        static void AddProducts(List<Product> products)
        {
            //method scope variables
            char addAnother = 'Y';
            string name;
            double price,
                cost;
            int quantityOnHand;
            //1. Create a "null" Product; this is used a "place holder" for a Product instance that
            //   will be added to the Products collection
            Product product;
            //2. Loop to add products. Remember there may be an exception, so we need a try-catch
            do
            {
                try
                {
                    //3a. Get all the values for the properties of the Product class
                    name = GetSafeString("Product name: ");
                    price = GetSafeDouble("Product price: ");
                    cost = GetSafeDouble("Product cost: ");
                    quantityOnHand = GetSafeInt("Quantity on hand: ");
                    //3.b Create an instance of Product
                    product = new Product(name, price, cost, quantityOnHand);
                    //3c. Add the Product instance to the collection Products
                    products.Add(product);
                    //3d. Prompt to add another Product
                    addAnother = GetSafeChar("Add another product (Y): ");
                }//end try
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Input is not valid");
                    Console.ForegroundColor = ConsoleColor.Black;
                }//end catch
            } while (addAnother=='Y');
        }//end of AddProducts

        #endregion

        #region Provided Methods
        static void Setup()
        {
            Console.Title = "Object Demo 2";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

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
        }//end of GetSafeDouble

        static int GetSafeInt(string prompt)
        {
            int number = 1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,20}", prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= 0)
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
        }//end of getSafeInt

        static string GetSafeString(string prompt)
        {
            string name;
            bool isValid = false;
            do
            {
                Console.Write("{0,20}", prompt);
                name = Console.ReadLine();
                if (name.Length >= 2)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Name is not valid");
                }
            } while (!isValid);
            return name;
        }//end of GetSafeString

        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char option = ' ';
            do
            {
                try
                {
                    Console.Write(prompt);
                    option = char.Parse(Console.ReadLine().ToUpper());
                    if(option =='Y' || option == 'N')
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid option ... please try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid option ... please try again");
                }
            } while (!isValid);
            return option;
        }//end of GetSafeChar
        #endregion
    }//eoc
}//eon
