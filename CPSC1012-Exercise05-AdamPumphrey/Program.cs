using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Write a program to display a square box on the screen of a length specified by the user
Input:              fillChar, boxLength
Output:             empty box & filled box displayed in console
Written By:         Adam Pumphrey
Last Modified:      Oct. 30, 2020
*/

namespace CPSC1012_Exercise05_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            char fillChar = ' ';

            bool validChar = false;

            int boxLength = GetBoxSize("\nLength of sides: ");

            /* 
               I would put the validation steps into their own methods, 
               but the assignment specifically says to only use the methods outlined
            */
            // validate char input - GetSafeChar
            do
            {
                try
                {
                    Console.Write("\nFill box with: ");
                    fillChar = char.Parse(Console.ReadLine());
                    validChar = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!validChar);

            // display empty box
            DrawBox(boxLength);

            // display filled box
            DrawBox(boxLength, fillChar);

            Console.ReadLine();
        }

        static void DrawBox(int length)
        {
            int count = 0;
            Console.WriteLine("\nEmpty box");
            // create top and bottom sides of box
            string topAndBottom = new string('-', length);
            // create left and right sides of box
            string sides = new string('|', 1) + new string(' ', length - 2) + new string('|', 1);

            // display box
            Console.WriteLine(topAndBottom);
            while (count < (length - 2))
            {
                Console.WriteLine(sides);
                count++;
            }
            Console.WriteLine(topAndBottom);
        }

        static void DrawBox(int sides, char fillCharacter)
        {
            int count = 0;
            Console.WriteLine("\nFilled box");
            // create top and bottom sides of box
            string topAndBottom = new string('-', sides);
            // create left and right sides of box with fill character inside
            string sideStr = new string('|', 1) + new string(fillCharacter, sides - 2) + new string('|', 1);

            // display box
            Console.WriteLine(topAndBottom);
            while (count < (sides - 2))
            {
                Console.WriteLine(sideStr);
                count++;
            }
            Console.WriteLine(topAndBottom);
        }

        static int GetBoxSize(string message)
        {
            bool isValid = false;
            int number = -99;

            // validate int input - GetSafeInt
            do
            {
                try
                {
                    Console.Write(message);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again");
                }
            } while (!isValid);

            return number;
        }
    }
}
