using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
Purpose:        Code a program which creates a daily sales record for a bicycle shop
Input:          menuOption, name, sale, filePath
Output:         each name and the sale made
Written By:     Adam Pumphrey
Last Modified:  Nov. 18, 2020
*/

namespace CPSC1012_CorePortfolio3_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Core Portfolio 3";

            int menuOption;

            bool running = true;

            List<string> names = new List<string>();

            List<double> sales = new List<double>();

            do
            {
                DisplayMenu();
                menuOption = GetSafeInt("\nMake a selection [1-5]: ");

                if (menuOption == 5)
                {
                    running = false;
                }
                else
                {
                    menuFunctions(menuOption, names, sales);
                }
            } while (running);

            Console.WriteLine("\nProgram ended.");


            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            string asterisks = new String('*', 25);
            Console.WriteLine("\n\tThe Right Speed Bike Shop");
            Console.WriteLine("\t{0}", asterisks);
            Console.WriteLine();
            Console.WriteLine("\t  1) Enter Name and Invoice Total");
            Console.WriteLine("\t  2) Display Daily Sales");
            Console.WriteLine("\t  3) Read Sales from file");
            Console.WriteLine("\t  4) Write Sales to file");
            Console.WriteLine("\t  5) Exit");
        }

        static void menuFunctions(int menuOption, List<string> names, List<double> sales)
        {
            switch (menuOption)
            {
                case 1:
                    AddEntries(names, sales);
                    break;

                case 2:
                    DisplaySales(names, sales);
                    break;

                case 3:
                    char userChoice = GetSafeChar("\nWarning, this will delete any unsaved records. Continue?[y/n]: ");
                    if (userChoice == 'Y')
                    {
                        LoadFromFile(names, sales);
                    }
                    else
                    {
                        Console.WriteLine("Load from file cancelled.");
                    }
                    break;

                default:
                    WriteToFile(names, sales);
                    return;
            }
        }

        static void AddEntries(List<string> names, List<double> sales)
        {
            string name = GetSafeString("\nEnter a name: ");
            double sale = GetSafeDouble("\nEnter the sale amount: ");

            names.Add(name);
            sales.Add(sale);
        }

        static void DisplaySales(List<string> names, List<double> sales)
        {
            if (names.Count < 1)
            {
                Console.WriteLine("\nNo sales entered.");
            }
            else
            {
                string asterisks = new String('*', 33);
                string spaces = new string(' ', 25);
                Console.WriteLine("\n\tThe Right Speed Bike Shop");
                Console.WriteLine("    {0}", asterisks);
                Console.WriteLine("\t     Daily Sales");
                Console.WriteLine();
                Console.WriteLine("{0,-10}" + spaces + "{1,10}", "Client", "Total Sale");
                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine("{0,-10:0.00}" + spaces + "{1,10:0.00}", names[i], sales[i]);
                }

                Console.WriteLine("\nAny key to continue...");
                Console.ReadKey();
            }
        }

        // from exercise 6
        static void LoadFromFile(List<string> names, List<double> sales)
        {
            names.Clear();
            sales.Clear();
            // ensure that a .csv file is being used
            string input,
                   filepath = VerifyFile();

            if (File.Exists(filepath))
            {
                StreamReader reader;

                try
                {
                    reader = File.OpenText(filepath);

                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] items = input.Split(',');
                        // check to make sure each line has 2 pieces of data - avoid out of range errors
                        if (items.Length != 2)
                        {
                            /* 
                               throws exception to jump to catch so method can restart - not sure if best/good practice,
                               or what the 'proper' way of doing this is 
                            */
                            throw new InvalidOperationException("File must contain exactly 2 items of data per line");
                        }
                        names.Add(items[0]);
                        sales.Add(double.Parse(items[1]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! See message below:");
                    Console.WriteLine(ex.Message);
                    // restart method on error
                    LoadFromFile(names, sales);
                    // exit method
                    return;
                }

                reader.Close();

                Console.WriteLine("Process complete.");
            }
            else
            {
                Console.WriteLine("File does not exist. Try again.");
                LoadFromFile(names, sales);
            }
        }

        // from exercise 6
        static void WriteToFile(List<string> names, List<double> sales)
        {
            string output;

            // ensure that a .csv file is being used/created
            string filepath = VerifyFile();

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

                for (int i = 0; i < names.Count; i++)
                {
                    output = names[i] + ',' + sales[i];
                    writer.WriteLine(output);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! See message below:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Restarting filewrite process");
                // call function again so user doesn't have to restart entire program because of a typo
                WriteToFile(names, sales);
                // exit method
                return;
            }

            writer.Close();

            Console.WriteLine("Process complete.");
        }

        // from exercise 6
        static string VerifyFile()
        {
            bool isValid = false;
            string filepath;

            // ensure that a .csv file is being used/created
            do
            {
                filepath = GetSafeString("Enter the file path eg) drive: slash folder slash file.csv: ", true);
                if (filepath.Length >= 4)
                {
                    string extension = filepath.Substring(filepath.Length - 4);
                    if (!extension.Equals(".csv"))
                    {
                        Console.WriteLine("Invalid file type. Please enter a valid file path for a .csv file");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid file path. Try again");
                }

            } while (!isValid);

            return filepath;
        }

        #region Input Validation Methods
        static int GetSafeInt(string prompt)
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
                    if (number >= 1 && number <= 5)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nSelection must be between 1-5 .. please try again.");
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        static double GetSafeDouble(string prompt)
        {
            bool isValid = false;
            double number = -99.00;
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
                        Console.WriteLine("\nInput must be more than 0.00 .. please try again.");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

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
        #endregion
    }
}
