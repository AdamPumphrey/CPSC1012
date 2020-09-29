using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:
Input:
Output:
Written By: Adam Pumphrey
Last Modified: Sept. 29, 2020
*/

namespace CPSC1012_CorePortfolio1_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            string asterisks,
                   dashes,
                   equals,
                   name;

            char option1,
                 greenOption;

            int tireSize,
                option2;

            double greenAmount;

            /* 
            https://stackoverflow.com/a/411762
            Creating lines of *'s, -'s and ='s here using method from link above.
            'new String('*', 25)' creates a new string instance with * repeated 25 times.
            Probably not faster & definitely uses more memory than just typing 25 *'s but its cleaner.
            */
            asterisks = new String('*', 25);
            dashes = new String('-', 9);
            equals = new String('=', 9);

            Console.WriteLine("    The Right Speed Bike Shop");
            Console.WriteLine("    {0}", asterisks);

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.WriteLine("Brand");
            Console.WriteLine("       a) Trek");
            Console.WriteLine("       b) Giant");
            Console.WriteLine("       c) Specialized");
            Console.WriteLine("       d) Raleigh");
            Console.Write("Make a selection [a,b,c,d]: ");
            option1 = char.Parse(Console.ReadLine().ToUpper());

            /* 
            Validate menu input - I know it is not required, included because I wanted to.
            I would usually use a loop to go back to the menu so the program doesn't just quit, 
            but we haven't gone over loops yet.
            */
            if (option1 != 'A' && option1 != 'B' && option1 != 'C' && option1 != 'D')
            {
                Console.WriteLine("Invalid option.");
            }
            else
            {
                Console.Write("Enter a tire size [20-26] @ 17.50 per inch: ");
                tireSize = int.Parse(Console.ReadLine());

                // Validate tire size input
                if (tireSize > 26 || tireSize < 20)
                {
                    Console.WriteLine("Invalid tire size.");
                }
                else
                {
                    Console.WriteLine("Enter the number of your corresponding choice of metal.");
                    Console.WriteLine("       1. Steel [$0]");
                    Console.WriteLine("       2. Aluminum [$175]");
                    Console.WriteLine("       3. Titanium [$425]");
                    Console.WriteLine("       4. Carbon Fiber [$615]");
                    Console.Write("Choice [1-4]: ");
                    option2 = int.Parse(Console.ReadLine());

                    // Validate menu input
                    if (option2 > 4 || option2 < 1)
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    else
                    {
                        Console.Write("Would you like to make a donation to the Green Earth Fund [y/n]: ");
                        greenOption = char.Parse(Console.ReadLine().ToLower());

                        // Validate y/n input

                        if (greenOption != 'y' && greenOption != 'n')
                        {
                            Console.WriteLine("Invalid option.");
                        }
                        else if (greenOption == 'y')
                        {
                            Console.Write("Amount: ");
                            greenAmount = double.Parse(Console.ReadLine());
                        }
                        else
                        {
                            
                        }
                    }
                }
            }


            Console.ReadLine();
        }
    }
}
