using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Program to keep track of revenue for your one-person taxi company
Input:              choice, tip amount, distance travelled, trip time, flat rate
Output:             total
Written By:         Adam Pumphrey
Last Modified:      Oct. 23, 2020
*/

namespace MethodProblem3
{
    class Program
    {
        const double airportCharge = 25.00,
                         perKM = 1.10,
                         perMin = 0.20;

        static void Main(string[] args)
        {
            char choice;

            double total = 0;

            List<char> menuOptions = new List<char> { 'A', 'R', 'F', 'X' };

            do
            {
                DisplayMenu();
                choice = GetSafeChar("Enter a selection: ", menuOptions, true);
                if (choice != 'X')
                {
                    switch (choice)
                    {
                        case 'A':
                            total += airportCharge;
                            total += TipAmount();
                            break;

                        case 'R':
                            total += CalculateFare();
                            break;

                        default:
                            total += GetRate();
                            break;
                    }
                }
            } while (choice != 'X');

            Console.WriteLine("\nTotal for the day is: {0:c}", total);

            Console.WriteLine("\nExiting program...");

            Console.ReadLine();
        }

        static char GetSafeChar(string prompt, List<char> options, bool menu = false)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                try
                {
                    Console.Write(prompt);
                    character = char.Parse(Console.ReadLine().ToUpper());
                    if (options.Contains(character))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again");
                        if (menu)
                        {
                            DisplayMenu();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                    if (menu)
                    {
                        DisplayMenu();
                    }
                }
            } while (!isValid);

            return character;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("\tA. Airport trip");
            Console.WriteLine("\tR. Regular Fare");
            Console.WriteLine("\tF. Flat rate");
            Console.WriteLine("\tX. Exit program");
        }

        static double TipAmount()
        {
            double amount;
            bool isValid = false;

            do
            {
                amount = GetSafeDouble("Enter tip amount: ");
                if (amount >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            return amount;
        }

        static double GetSafeDouble(string prompt)
        {
            bool isValid = false;
            double number = 0;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                    
                }
            } while (!isValid);

            return number;
        }

        static double GetDistance()
        {
            double distance;
            bool isValid = false;

            do
            {
                distance = GetSafeDouble("Enter distance travelled in km: ");
                if (distance >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            return distance;
        }

        static double GetTime()
        {
            double time;
            bool isValid = false;

            do
            {
                time = GetSafeDouble("Enter total time of trip in minutes: ");
                if (time >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            return time;
        }

        static double CalculateFare()
        {
            double distanceCost,
                   timeCost;

            distanceCost = GetDistance() * perKM;
            timeCost = GetTime() * perMin;

            return (distanceCost + timeCost) + TipAmount();
        }

        static double GetRate()
        {
            double rate;
            bool isValid = false;

            do
            {
                rate = GetSafeDouble("Enter agreed-upon amount: ");
                if (rate >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            return rate + TipAmount();
        }
    }
}
