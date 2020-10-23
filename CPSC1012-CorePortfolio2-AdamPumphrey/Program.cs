using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            To code a program which creates an invoice for a bicycle sale
Input:              name, greenAmount | method-specific input: brand choice, tire size, metal choice
Output:             name, brand, BasePrice, tirePremium, metalPremium, subTotal, tax, greenAmount, total
Written By:         Adam Pumphrey
Last Modified:      Oct. 22, 2020
*/

namespace CPSC1012_CorePortfolio2_AdamPumphrey
{
    class Program
    {
        // class-level constants so they can be used in methods
        const double BasePrice = 500,
                     TirePrice = 17.50,
                     SteelPrice = 0,
                     AluminumPrice = 175,
                     TitaniumPrice = 425,
                     CarbonPrice = 615,
                     GST = 0.05;

        static void Main(string[] args)
        {
            Console.Title = "Core2";
            Console.Clear();

            string name = "",
                   brand = "Trek";

            int tireSize = 20,
                menuOption;

            double greenAmount = 0,
                   // default metalPremium is 0 since lowest premium is $0 (steel)
                   metalPremium = 0;

            menuOption = 0;
            do
            {
                // display menu and user select option
                DisplayMenu();
                // GetMenuOption validates input for data type and range
                menuOption = GetMenuOption();
                // if option other than quit
                if (menuOption >= 1 && menuOption <= 7)
                {
                    switch(menuOption)
                    {
                        // 1. Enter Name
                        case 1:
                            Console.Write("\nEnter your name: ");
                            name = Console.ReadLine();
                            break;

                        // 2. Enter Brand
                        case 2:
                            brand = ChooseBrand();
                            break;

                        // 3. Select Tire Size
                        case 3:
                            tireSize = GetTireSize();
                            break;

                        // 4. Select Metal Composite
                        case 4:
                            metalPremium = ChooseCompositeValue();
                            break;

                        // 5. Add Donation
                        case 5:
                            greenAmount = GetDonationAmount();
                            break;

                        // 6. Display Packing Slip / Invoice
                        case 6:
                            DisplayInvoice(tireSize, metalPremium, greenAmount, name, brand);
                            break;

                        // 7. Clear
                        default:
                            // reset stored values to defaults
                            name = "";
                            brand = "Trek";
                            metalPremium = 0;
                            tireSize = 20;
                            greenAmount = 0;
                            Console.WriteLine("\nData cleared.");
                            break;
                    }
                }
            // run until '8. Exit' is chosen
            } while (menuOption != 8);

            Console.WriteLine("\nClosing program...");

            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            // Display menu
            string asterisks = new String('*', 25);
            Console.WriteLine("\nThe Right Speed Bike Shop");
            Console.WriteLine("{0}", asterisks);
            Console.WriteLine("\t1. Enter Name");
            Console.WriteLine("\t2. Enter Brand");
            Console.WriteLine("\t3. Select Tire Size");
            Console.WriteLine("\t4. Select Metal Composite");
            Console.WriteLine("\t5. Add Donation");
            Console.WriteLine("\t6. Display Packing Slip / Invoice");
            Console.WriteLine("\t7. Clear");
            Console.WriteLine("\t8. Exit");
        }

        static int GetMenuOption()
        {
            bool isValid = false;
            int number;
            do
            {
                // Get menu option from user - int from 1-8
                number = GetSafeInt("\nEnter menu choice: ");
                // if valid int is within range
                if (number >= 1 && number <= 8)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return menu option choice
            return number;
        }

        static string ChooseBrand()
        {
            // obtain validated char input from user
            char choice = GetBrandChoice();
            string brand;

            // assign brand name that corresponds to char input
            switch (choice)
            {
                case 'A':
                    brand = "Trek";
                    break;

                case 'B':
                    brand = "Giant";
                    break;

                case 'C':
                    brand = "Specialized";
                    break;

                default:
                    brand = "Raleigh";
                    break;
            }

            // return brand name chosen
            return brand;
        }

        static char GetBrandChoice()
        {
            char choice;
            bool isValid = false;
            // char list of valid options to choose from
            List<char> validOptions = new List<char> { 'A', 'B', 'C', 'D' };
            do
            {
                // display brand submenu
                DisplayBrandMenu();
                // validate char input
                choice = GetSafeChar("Make a selection [a,b,c,d]: ", true);
                // check if validated char input is a valid option
                if (validOptions.Contains(choice))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            // return brand menu option
            return choice;
        }

        static void DisplayBrandMenu()
        {
            // display brand submenu
            Console.WriteLine("\nBrand");
            Console.WriteLine("       a) Trek");
            Console.WriteLine("       b) Giant");
            Console.WriteLine("       c) Specialized");
            Console.WriteLine("       d) Raleigh");
        }

        /* Optional param brand to indicate call of DisplayBrandMenu.
           Not really necessary since this function is only being called for the brand selection,
           but would allow the function to be called for other uses if this code was expanded upon 
           in the future rather than having it hard coded for the brand choice.
        */
        static char GetSafeChar(string prompt, bool brand = false)
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
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                    if (brand)
                    {
                        DisplayBrandMenu();
                    }
                }
            } while (!isValid);

            // return valid char input
            return character;
        }

        static int GetTireSize()
        {
            bool isValid = false;
            int number;
            do
            {
                // validate int input
                number = GetSafeInt("\nEnter a tire size [20-26] @ 17.50 per inch: ");
                // check if valid int input within range
                if (number <= 26 && number >= 20)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return user-inputted tire size
            return number;
        }


        /*
          Optional param metal to indicate metal menu should be displayed on exception.
          Necessary here since GetSafeInt is used in GetTireSize.
          I could have overloaded this method instead and achieved the same goal (I think).
          eg) GetSafeInt(string prompt) and GetSafeInt(string prompt, bool metal) or something like that
        */
        static int GetSafeInt(string prompt, bool metal = false)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    // validate int input
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                    if (metal)
                    {
                        DisplayMetalMenu();
                    }
                }
            } while (!isValid);

            return number;
        }

        static double ChooseCompositeValue()
        {
            // obtain validated int input from user
            int metalChoice = GetMetalChoice();
            double metalPremium;

            // assign metal premium corresponding to user input
            switch (metalChoice)
            {
                case 1:
                    metalPremium = SteelPrice;
                    break;

                case 2:
                    metalPremium = AluminumPrice;
                    break;

                case 3:
                    metalPremium = TitaniumPrice;
                    break;

                default:
                    metalPremium = CarbonPrice;
                    break;
            }

            // return metal premium chosen by user
            return metalPremium;
        }

        static int GetMetalChoice()
        {
            bool isValid = false;
            int number;
            do
            {
                // display metal choice submenu
                DisplayMetalMenu();
                // validate int input
                number = GetSafeInt("Choice [1-4]: ", true);
                // check if valid int input is within range
                if (number >= 1 && number <= 4)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return metal type chosen by user
            return number;
        }

        static void DisplayMetalMenu()
        {
            Console.WriteLine("\nEnter the number of your corresponding choice of metal.");
            Console.WriteLine("       1. Steel [$0]");
            Console.WriteLine("       2. Aluminum [$175]");
            Console.WriteLine("       3. Titanium [$425]");
            Console.WriteLine("       4. Carbon Fiber [$615]");
        }

        static double GetDonationAmount()
        {
            bool isValid = false;
            double number;
            do
            {
                // validate double input
                number = GetSafeDouble("\nEnter donation amount: ");
                // donations can't be negative - check for positive amount
                if (number >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return donation amount
            return number;
        }

        // did not add optional menu display param since there is no menu to display
        static double GetSafeDouble(string prompt)
        {
            bool isValid = false;
            double number = -99.99;
            do
            {
                try
                {
                    // validate double input
                    Console.Write(prompt);
                    number = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return valid double input
            return number;
        }

        static void DisplayInvoice(int tireSize, double metalPremium, double greenAmount, string name, string brand)
        {
            /* https://stackoverflow.com/a/411762 
             Creating lines of -'s and ='s here using method from link above.
             'new String('-', 25)' creates a new string instance with - repeated 25 times.
             Probably not faster & definitely uses more memory than just typing 25 -'s but its cleaner.
            */
            string dashes = new String('-', 9);
            string equals = new String('=', 9);

            // Calculate tirePremium
            double tirePremium = tireSize * TirePrice;

            // Calculate total
            double subTotal = BasePrice + tirePremium + metalPremium;
            double tax = subTotal * GST;
            double total = subTotal + tax + greenAmount;

            /* 
            https://www.leniel.net/2012/08/string.format-composite-formatting-with-dynamic-length-aligned-text-in-csharp.html
            Dynamic string alignment method found in link above
            */
            int nameLen = 16 + name.Length;
            int brandLen = 19 + brand.Length;

            // display formatted invoice
            Console.WriteLine("\nInvoice and Packing Slip");
            Console.WriteLine("\n Customer:{0," + nameLen + "}", name);
            Console.WriteLine(" Brand:{0," + brandLen + "}", brand);
            Console.WriteLine(" Base Price:              {0,20:0.00}", BasePrice);
            Console.WriteLine(" Tire Size Premium:       {0,20:0.00}", tirePremium);
            Console.WriteLine(" Metal Selection Premium: {0,20:0.00}", metalPremium);
            Console.WriteLine("                          {0,20}", dashes);
            Console.WriteLine(" Sub Total:               {0,20:0.00}", subTotal);
            Console.WriteLine(" GST:                     {0,20:0.00}", tax);
            Console.WriteLine("                          {0,20}", equals);
            Console.WriteLine(" Donation to Green Earth  {0,20:0.00}", greenAmount);
            Console.WriteLine(" Total:                   {0,20:0.00}", total);
        }
        
    }
}
