using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using CPSC1012_AdvPortfolio_AdamPumphrey.Classes;
using System.Windows.Forms;

/*
Purpose:        to code a program which creates an invoice for a bicycle sale
Input:          menu choice, name, brand choice, tire size, metal choice, donation, filename (read from/write to)
Output:         invoice display, all invoices display
Written By:     Adam Pumphrey
Last Modified:  Nov. 30, 2020
*/

namespace CPSC1012_AdvPortfolio_AdamPumphrey
{
    class Program
    {
        const double BasePrice = 500,
                     TirePrice = 17.50,
                     SteelPrice = 0,
                     AluminumPrice = 175,
                     TitaniumPrice = 425,
                     CarbonPrice = 615,
                     GST = 0.05;

        // encountered exception when trying to run OpenFileDialog, adding [STAThread] to Main declaration fixed it
        [STAThread] static void Main(string[] args)
        {
            bool isValid = false;
            int choice;

            Console.Title = "Advanced Portfolio";

            /* 
             * setup list of invoices, add blank (default) invoice (to be used first) to list
             * an invoice is immediately created as a default behaviour
             * default invoice will be removed if data is loaded in from file
             * using List.Count property to keep track of active invoice
            */
            List<Invoice> invoices = new List<Invoice>();
            CreateInvoice(invoices);

            do
            {
                DisplayMenu();
                choice = GetSafeInt("\nEnter menu choice: ");
                if (choice == 11)
                {
                    isValid = true;
                }
                else
                {
                    MenuFunctions(choice, invoices);
                }
            } while (!isValid);

            Console.WriteLine("Exiting program...");
            Console.ReadLine();
        }

        static void CreateInvoice(List<Invoice> invoices)
        {
            Invoice invoice = new Invoice();
            invoices.Add(invoice);
        }

        static void DisplayMenu()
        {
            string asterisks = new String('*', 25);
            Console.WriteLine("\n\tThe Right Speed Bike Shop");
            Console.WriteLine("\t{0}", asterisks);
            Console.WriteLine();
            Console.WriteLine("\t 1. Enter Name");
            Console.WriteLine("\t 2. Enter Brand");
            Console.WriteLine("\t 3. Select Tire Size");
            Console.WriteLine("\t 4. Select Metal Composite");
            Console.WriteLine("\t 5. Add Donation");
            Console.WriteLine("\t 6. Display Packing Slip / Invoice");
            Console.WriteLine("\t 7. Save Invoice (Clear)");
            Console.WriteLine("\t 8. Read Invoices from File");
            Console.WriteLine("\t 9. Write Invoices to File");
            Console.WriteLine("\t 10. Display All Invoices");
            Console.WriteLine("\t 11. Exit");
        }

        // accessing current invoice with invoices.Count - 1
        static void MenuFunctions(int menuOption, List<Invoice> invoices)
        {
            char option;
            switch (menuOption)
            {
                // set name
                case 1:
                    invoices[invoices.Count - 1].Name = GetSafeString("Enter name: ");
                    break;

                case 2:
                    invoices[invoices.Count - 1].Brand = ChooseBrand();
                    break;

                case 3:
                    invoices[invoices.Count - 1].Tire = GetTireSize();
                    break;

                case 4:
                    invoices[invoices.Count - 1].Metal = ChooseCompositeValue();
                    break;

                case 5:
                    invoices[invoices.Count - 1].Donation = GetSafeDouble("\nEnter donation amount: ");
                    break;

                // displays most recent invoice added
                case 6:
                    DisplayInvoice(invoices[invoices.Count - 1].Tire, invoices[invoices.Count - 1].Metal, 
                        invoices[invoices.Count - 1].Donation, invoices[invoices.Count - 1].Name, invoices[invoices.Count - 1].Brand);
                    break;

                case 7:
                    option = GetSafeChar("\nAre you sure you want to clear the current invoice? [Y/N]: ", false, true);
                    if (option == 'Y')
                    {
                        CreateInvoice(invoices);
                    }
                    Console.WriteLine("New blank invoice created");
                    break;

                case 8:
                    option = GetSafeChar("\nLoading from file will clear current invoices! Continue? [Y/N]: ");
                    if (option == 'Y')
                    {
                        LoadFromFile(invoices);
                        // creates new invoice for user to work on
                        CreateInvoice(invoices);
                    }
                    break;

                case 9:
                    WriteToFile(invoices);
                    break;

                default:
                    DisplayInvoices(invoices);
                    break;
            }
        }

        #region Brand
        // re-used from core portfolio 2
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

        // modified from core portfolio 2
        static char GetBrandChoice()
        {
            char choice;
            bool isValid = false;
            string pattern = "[ABCD]";
            do
            {
                // display brand submenu
                DisplayBrandMenu();
                // validate char input
                choice = GetSafeChar("Make a selection [A,B,C,D]: ", true);
                // using regex to check if input is one of A, B, C, or D
                // there will only ever be one match since we are using a char
                Match match = Regex.Match(choice.ToString(), pattern);
                // if regex returns a match
                if (match.Success)
                {
                    isValid = true;
                }
                // no match
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            // return brand menu option
            return choice;
        }

        // re-used from core portfolio 2
        static void DisplayBrandMenu()
        {
            // display brand submenu
            Console.WriteLine("\nBrand");
            Console.WriteLine("       a) Trek");
            Console.WriteLine("       b) Giant");
            Console.WriteLine("       c) Specialized");
            Console.WriteLine("       d) Raleigh");
        }
        #endregion

        #region Tire Size
        // re-used from core portfolio 2
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
        #endregion

        #region Metal Composite
        // re-used from core portfolio 2
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

        // re-used from core portfolio 2
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

        // re-used from core portfolio 2
        static void DisplayMetalMenu()
        {
            Console.WriteLine("\nEnter the number of your corresponding choice of metal.");
            Console.WriteLine("       1. Steel [$0]");
            Console.WriteLine("       2. Aluminum [$175]");
            Console.WriteLine("       3. Titanium [$425]");
            Console.WriteLine("       4. Carbon Fiber [$615]");
        }
        #endregion

        #region Display Single Invoice
        // modified from core portfolio 2
        static void DisplayInvoice(int tireSize, double metalPremium, double greenAmount, string name, string brand)
        {
            string dashes = new String('-', 9);
            string equals = new String('=', 9);

            // Calculate tirePremium
            double tirePremium = tireSize * TirePrice;

            // Calculate total
            double subTotal = BasePrice + tirePremium + metalPremium;
            double tax = subTotal * GST;
            double total = subTotal + tax + greenAmount;

            // display formatted invoice
            Console.WriteLine("\nInvoice and Packing Slip");
            Console.WriteLine();
            Console.WriteLine(" Customer:                {0,20}", name);
            Console.WriteLine(" Brand:                   {0,20}", brand);
            Console.WriteLine("                          {0,20}", dashes);
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
        #endregion

        #region File Operations
        // modified from core portfolio 3
        static void LoadFromFile(List<Invoice> invoices)
        {
            invoices.Clear();

            string input,
                   filepath= "";

            bool selection = false;

            do
            {
                // use gui to avoid hard-coding file path and make it easier for the user vs. typing in full path
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"c:\";
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filepath = openFileDialog.FileName;
                        selection = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: No file selected");
                        char option = GetSafeChar("Press any letter to retry, or N to return to menu: ");
                        if (option == 'N')
                        {
                            return;
                        }
                    }
                }
            } while (!selection);
            

            if (File.Exists(filepath))
            {
                StreamReader reader;

                try
                {
                    reader = File.OpenText(filepath);

                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] items = input.Split(',');
                        // check to make sure each line has 5 pieces of data - avoid out of range errors
                        if (items.Length != 5)
                        {
                            /* 
                               throws exception to jump to catch so method can restart - not sure if best/good practice,
                               or what the 'proper' way of doing this is 
                            */
                            throw new InvalidOperationException("File must contain exactly 5 items of data per line");
                        }
                        CreateInvoice(invoices);
                        // don't want to write a blank invoice to a file
                        if (items[0] != "")
                        {
                            invoices[invoices.Count - 1].Name = items[0];
                        }
                        // data validation
                        if (VerifyBrand(items[1]))
                        {
                            invoices[invoices.Count - 1].Brand = items[1];
                        }
                        else
                        {
                            throw new Exception("Invalid brand. Must be one of Trek, Giant, Specialized, or Raleigh. Case sensitive.");
                        }

                        if (VerifyTireSize(int.Parse(items[2])))
                        {
                            invoices[invoices.Count - 1].Tire = int.Parse(items[2]);
                        }
                        else
                        {
                            throw new Exception("Invalid tire size. Must be between 20 and 26 inclusive.");
                        }

                        if (VerifyMetal(double.Parse(items[3])))
                        {
                            invoices[invoices.Count - 1].Metal = double.Parse(items[3]);
                        }
                        else
                        {
                            throw new Exception("Invalid metal premium. Must be one of 0.00, 175.00, 425.00, or 615.00.");
                        }
                        if (double.Parse(items[4]) > 0)
                        {
                            invoices[invoices.Count - 1].Donation = double.Parse(items[4]);
                        }
                        else
                        {
                            throw new Exception("Invalid donation amount. Must be a positive value.");
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! See message below:");
                    Console.WriteLine(ex.Message);
                    // restart method on error
                    LoadFromFile(invoices);
                    // exit method
                    return;
                }

                reader.Close();

                Console.WriteLine("\tProcess complete.");
            }
            else
            {
                Console.WriteLine("File does not exist. Try again.");
                LoadFromFile(invoices);
            }
        }

        #region Data Validation Methods
        static bool VerifyBrand(string brand)
        {
            List<string> brands = new List<string> { "Trek", "Giant", "Specialized", "Raleigh" };

            bool isValid = brands.Contains(brand);

            return isValid;
        }

        static bool VerifyTireSize(int size)
        {
            bool isValid = false;

            if (size <= 26 && size>= 20)
            {
                isValid = true;
            }

            return isValid;
        }

        static bool VerifyMetal(double premium)
        {
            List<double> premiums = new List<double> { 0.00, 175.00, 425.00, 615.00 };

            bool isValid = premiums.Contains(premium);

            return isValid;

        }
        #endregion

        // modified from core portfolio 3
        static void WriteToFile(List<Invoice> invoices)
        {
            string output;

            bool selection = false;

            string filepath = "";

            do
            {
                // use gui to avoid hard-coding file path and make it easier for the user vs. typing in full path
                Console.WriteLine("Saving...");
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "csv files (*.csv)|*.csv";
                    // no need for overwrite warning since we are appending data
                    saveFileDialog.OverwritePrompt = false;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filepath = saveFileDialog.FileName;
                        selection = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: No file selected");
                        char option = GetSafeChar("Press any key to retry, or N to return to menu: ");
                        if (option == 'N')
                        {
                            return;
                        }
                    }
                }
            } while (!selection);

            StreamWriter writer;

            try
            {
                if (File.Exists(filepath))
                {
                    writer = File.AppendText(filepath);
                }
                else
                {
                    writer = File.CreateText(filepath);
                }

                foreach (Invoice invoice in invoices)
                {
                    if (invoice.Name != "")
                    {
                        output = invoice.Name + ',' + invoice.Brand + ',' + invoice.Tire + ',' + invoice.Metal + ',' + invoice.Donation;
                        writer.WriteLine(output);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! See message below:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Restarting filewrite process");
                // call function again so user doesn't have to restart entire program because of a typo
                WriteToFile(invoices);
                // exit method
                return;
            }

            writer.Close();

            Console.WriteLine("\tProcess complete.");
        }
        #endregion

        #region Display All Invoices
        static void DisplayInvoices(List<Invoice> invoices)
        {
            string dashes = new string('-', 69);
            Console.WriteLine();
            Console.WriteLine("\t{0,-25} {1,-13} {2,-9} {3,-10} {4,8}", "Client", "Brand", "Tires", "Metal", "Donation");
            Console.WriteLine("\t" + dashes);
            foreach (Invoice invoice in invoices)
            {
                if (invoice.Name != "")
                {
                    Console.WriteLine("\t" + invoice);
                }
            }
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }
        #endregion

        #region Input Validation
        static string GetSafeString(string prompt, bool file = false)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                if (!file)
                {
                    name = Console.ReadLine();
                }
                else
                {
                    name = @"" + Console.ReadLine();
                }
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

        static int GetSafeInt(string prompt, bool menu = false)
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
                    if (menu)
                    {
                        if (number >= 1 && number <= 11)
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nSelection must be between 1 and 11 .. please try again.");
                        }
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        static char GetSafeChar(string prompt, bool brand = false, bool yesno = false)
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
                    if (yesno)
                    {
                        if (character == 'Y' || character == 'N')
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input .. must be Y or N");
                        }
                    }
                    else
                    {
                        isValid = true;
                    }
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
                    if (number >= 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. cannot donate negative values");
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return valid double input
            return number;
        }
        #endregion
    }
}
