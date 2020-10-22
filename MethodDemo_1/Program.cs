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

            //main program loop
            do
            {
                    DisplayMenu();
                    menuItem = GetSafeInt("Enter your selection:", MinValue, MaxValue);
                    if (menuItem != 0)
                    {
                        first = GetSafeInt("Enter a value for x:");
                        second = GetSafeInt("Enter a value for y:");
                        answer = ProcessMenu(menuItem, first, second);
                        DisplayResults(menuItem, answer, first, second);
                    } 
            } while (menuItem != 0);

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

                default:
                    result = ((first * first) + (second * second));
                    break;
                
            }

            return result;
        }

        static void DisplayResults(int menuOption, int result, int first, int second)
        {
            switch (menuOption)
            {
                case 1:
                    Console.WriteLine("{0}^{1} = {2}", first, second, result);
                    break;

                case 2:
                    Console.WriteLine("{0}^{1} = {2}", second, first, result);
                    break;

                default:
                    Console.WriteLine("{0}^2 + {1}^2 = {2}", first, second, result);
                    break;
            }
        }
    }//eoc
}//eon
