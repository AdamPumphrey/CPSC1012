using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Demo conditional operator for highest of 3 numbers
Input:              number1, number2, number3
Output:             highest
Written By:         Adam Pumphrey
Last Modified:      Sept. 29, 2020
*/

namespace ConditionalOperatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Conditional Operator Demo";
            Console.Clear();

            int number1,
                number2,
                number3,
                highest;

            Console.Write("Enter number1: ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number2: ");
            number2 = int.Parse(Console.ReadLine());
            Console.Write("Enter number3: ");
            number3 = int.Parse(Console.ReadLine());

            // is this condition true ? yes : no
            highest = number1 > number2 ? number1 : number2;
            highest = number3 > highest ? number3 : highest;

            Console.WriteLine("Out of the numbers {0}, {1}, {2}, the highest is {3}", number1, number2, number3, highest);

            Console.ReadLine();
        }
    }
}
