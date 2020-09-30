using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            To create a costed Packing Slip reflecting the choices made in purchasing a new bike
Input:              name, option1, tireSize, option2, greenOption, greenAmount
Output:             name, brand, BasePrice, tirePremium, metalPremium, subTotal, tax, greenAmount, total
Written By:         Adam Pumphrey
Last Modified:      Sept. 29, 2020
*/

namespace CPSC1012_CorePortfolio1_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Core1";
            Console.Clear();

            const double BasePrice = 500, TirePrice = 17.50, SteelPrice = 0, AluminumPrice = 175, TitaniumPrice = 425, CarbonPrice = 615, GST = 0.05;

            string asterisks,
                   dashes,
                   equals,
                   name,
                   brand;

            char option1,
                 greenOption;

            int tireSize,
                option2,
                nameLen,
                brandLen;

            double greenAmount,
                   tirePremium,
                   metalPremium,
                   subTotal,
                   tax,
                   total;

            // Initialize greenAmount default as 0
            greenAmount = 0;

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

            // Enter name
            Console.Write("\nEnter your name: ");
            name = Console.ReadLine();

            // Choose brand
            Console.WriteLine("Brand");
            Console.WriteLine("       a) Trek");
            Console.WriteLine("       b) Giant");
            Console.WriteLine("       c) Specialized");
            Console.WriteLine("       d) Raleigh");
            Console.Write("Make a selection [a,b,c,d]: ");
            option1 = char.Parse(Console.ReadLine().ToUpper());

            /* 
            Validate menu input - I know it is not required, included because I wanted to.
            I would usually use a while loop to go back to the menu so the program doesn't just quit, 
            but we haven't gone over loops yet.
            */
            if (option1 != 'A' && option1 != 'B' && option1 != 'C' && option1 != 'D')
            {
                Console.WriteLine("Invalid option.");
            }
            else
            {
                // Enter tire size
                Console.Write("Enter a tire size [20-26] @ 17.50 per inch: ");
                tireSize = int.Parse(Console.ReadLine());

                // Validate tire size input
                if (tireSize > 26 || tireSize < 20)
                {
                    Console.WriteLine("Invalid tire size.");
                }
                else
                {
                    // Choose metal
                    Console.WriteLine("Enter the number of your corresponding choice of metal.");
                    Console.WriteLine("       1. Steel [$0]");
                    Console.WriteLine("       2. Aluminum [$175]");
                    Console.WriteLine("       3. Titanium [$425]");
                    Console.WriteLine("       4. Carbon Fiber [$615]");
                    Console.Write("Choice [1-4]: ");
                    option2 = int.Parse(Console.ReadLine());

                    // Validate menu input - doesn't cover entering data types other than expected, would need to do that before Parse I think
                    if (option2 > 4 || option2 < 1)
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    else
                    {
                        // Donation decision
                        Console.Write("Would you like to make a donation to the Green Earth Fund [y/n]: ");
                        greenOption = char.Parse(Console.ReadLine().ToLower());

                        // Validate y/n input
                        if (greenOption != 'y' && greenOption != 'n')
                        {
                            Console.WriteLine("Invalid option.");
                        }
                        else
                        {
                            // Check for y option
                            if (greenOption == 'y')
                            {
                                Console.Write("Amount: ");
                                greenAmount = double.Parse(Console.ReadLine());
                            }

                            // Determine brand
                            switch (option1)
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

                                case 'D':
                                    brand = "Raleigh";
                                    break;

                                default:
                                    brand = "error";
                                    break;
                            }

                            // Determine metal selection premium
                            switch (option2)
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

                                case 4:
                                    metalPremium = CarbonPrice;
                                    break;

                                default:
                                    metalPremium = 100000;
                                    break;
                            }

                            // Calculate tirePremium
                            tirePremium = tireSize * TirePrice;

                            // Calculate total
                            subTotal = BasePrice + tirePremium + metalPremium;
                            tax = subTotal * GST;
                            total = subTotal + tax + greenAmount;

                            /* 
                            https://www.leniel.net/2012/08/string.format-composite-formatting-with-dynamic-length-aligned-text-in-csharp.html
                            Dynamic string alignment method found in link above
                            */
                            nameLen = 16 + name.Length;
                            brandLen = 19 + brand.Length;


                            // Final formatting
                            Console.WriteLine("\nInvoice and Packing Slip");
                            Console.WriteLine("\n Customer:{0," + nameLen + "}", name);
                            Console.WriteLine(" Brand:{0," + brandLen + "}", brand);
                            Console.WriteLine(" Base Price: {0,33:0.00}", BasePrice);
                            Console.WriteLine(" Tire Size Premium: {0,26:0.00}", tirePremium);
                            Console.WriteLine(" Metal Selection Premium: {0,20:0.00}", metalPremium);
                            Console.WriteLine("{0,46}", dashes);
                            Console.WriteLine(" Sub Total: {0,34:0.00}", subTotal);
                            Console.WriteLine(" GST: {0,40:0.00}", tax);
                            Console.WriteLine("{0,46}", equals);
                            Console.WriteLine(" Donation to Green Earth {0,21:0.00}", greenAmount);
                            Console.WriteLine(" Total: {0,38:0.00}", total);
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
