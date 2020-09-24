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
Last Modified: Sept. 24, 2020
*/

namespace MinMaxBoolean
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Minimum = 4, 
                      Maximum = 10;

            int number;
            string correctness;

            Console.Write("Enter a number between {0} and {1} inclusive: ", Minimum, Maximum);
            number = int.Parse(Console.ReadLine());

            if (number >= Minimum && number <= Maximum)
            {
                correctness = "within range";
            }
            else if (number < Minimum)
            {
                correctness = "too low";
            }
            else
            {
                correctness = "too high";
            }

            Console.WriteLine("The number you entered is {0}", correctness);

            Console.ReadLine();
        }
    }
}
