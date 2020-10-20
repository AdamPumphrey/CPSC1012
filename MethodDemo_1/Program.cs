using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate some simple methods:
                    GetSafeInt(string prompt)
                    GetSafeInt(string prompt, int minValue, int maxValue)
                    GetSafeChar(string prompt)
                    DisplayMenu()
                    ProcessMenu(int menuOption, int first, int second)
                    DisplayResults(int menuOption, int result)
                    ConsoleSetup() [optional]
Input:			two validiated numbers, menu option (exit on 0)
Output:			calcualtion based on the menu option:
                1. first^second
                2. second^first
                3. first^2 + second^2
Written By: 	 
Last Modified:	Oct 20,2020
*/

namespace MethodDemo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare constants
            const int MinValue = 0,
                      MaxValue = 3;

            //declare variables
            int first,
                second,
                menuItem,
                answer;

            char doAgain = 'Y';

            bool validMenuOption = false;

            //main program loop
            do
            {
                do
                {
                    DisplayMenu();
                    menuItem = GetSafeInt("Enter your selection:", 0, 3);
                    first = GetSafeInt("Enter a value for x:");
                    second = GetSafeInt("Enter a value for y:");
                } while (!validMenuOption);
            } while (doAgain == 'Y');

            //program ends
            Console.WriteLine("\nGoodbye ...");
            Console.ReadLine();
        }//eom

        static int GetSafeInt(string prompt)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        // overloading GetSafeInt method
        static int GetSafeInt(string prompt, int minValue, int maxValue)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= minValue && number <= maxValue)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("The value entered is outside of the range of {0} to {1} inclusive", minValue, maxValue);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nSelect from the following options:");
            Console.WriteLine("\t1. x^y");
            Console.WriteLine("\t2. y^x");
            Console.WriteLine("\t3. x^2 + y^2");
            Console.WriteLine("\t0. Exit");
        }

        static int ProcessMenu(int menuOption, int first, int second)
        {
            int result;
            switch (menuOption)
            {
                case 1:
                    result = (int)Math.Pow(first, second);
                    break;

                case 2:
                    result = (int)Math.Pow(second, first);
                    break;

                case 3:
                    result = ((first * first) + (second * second));
                    break;

                default:
                    break;
                
            }

            return result;
        }
    }//eoc
}//eon
