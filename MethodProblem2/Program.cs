using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Method practice 2
Input:              first, second, choice, restart
Output:             MathOperations.result
Written By:         Adam Pumphrey
Last Modified:      Oct. 22, 2020
*/

namespace MethodProblem2
{
    class Program
    {


        static void Main(string[] args)
        {
            Tuple<int, int> firstAndSecond;

            int first,
                second;

            char choice,
                 restart;

            char[] options = { 's', 'd', 'p', 'q', 'x' };

            bool complete = false;

            // store value of first and second
            firstAndSecond = GetFirstAndSecond();

            do
            {
                // assign values of first and second
                first = firstAndSecond.Item1;
                second = firstAndSecond.Item2;
                DisplayMenu();
                choice = GetSafeChar("Choice: ");
                // https://stackoverflow.com/questions/35023031/c-sharp-if-item-is-not-in-array
                // if choice is a valid option
                if (options.Contains(choice) == true)
                {
                    // if choice is not exit
                   if (choice != 'x')
                    {
                        MathOperations(choice, first, second);
                        // program has completed
                        complete = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input .. please try again");
                }
                // if program has completed
                if (complete)
                {
                    // prompt for restart
                    restart = GetSafeChar("\nWould you like to restart? Y or N: ");
                    if (restart == 'y')
                    {
                        // ask for values for first and second
                        firstAndSecond = GetFirstAndSecond();
                        // reset completion status
                        complete = false;
                    }
                    else
                    {
                        // exit program
                        choice = 'x';
                    }
                }
            } while (choice != 'x');

            Console.WriteLine("Exiting program...");
            Console.ReadLine();
        }

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

        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                try
                {
                    Console.Write(prompt);
                    character = char.Parse(Console.ReadLine().ToLower());
                    isValid = true;
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input .. please try again.");
                }
            } while (!isValid);

            return character;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nChoose from one of the following options:");
            Console.WriteLine("S - Sum of the two numbers");
            Console.WriteLine("D - Difference of the two numbers");
            Console.WriteLine("P - Product of the two numbers");
            Console.WriteLine("Q - Division of the two numbers");
            Console.WriteLine("X - Exit program");
        }

        static void MathOperations(char choice, int first, int second)
        {
            int result;

            switch (choice)
            {
                case 's':
                    result = first + second;
                    Console.WriteLine("{0} + {1} = {2}", first, second, result);
                    break;

                case 'd':
                    result = first - second;
                    Console.WriteLine("{0} - {1} = {2}", first, second, result);
                    break;

                case 'p':
                    result = first * second;
                    Console.WriteLine("{0} * {1} = {2}", first, second, result);
                    break;

                default:
                    if (second == 0)
                    {
                        Console.WriteLine("Error: cannot divide by zero");
                    }
                    else
                    {
                        result = first / second;
                        Console.WriteLine("{0} / {1} = {2}", first, second, result);
                    }
                    break;
            }
        }

        static Tuple<int, int> GetFirstAndSecond()
        {
            int first,
                second;

            first = GetSafeInt("\nEnter 1st number: ");
            second = GetSafeInt("Enter 2nd number: ");

            return Tuple.Create(first, second);
        }
    }
}
