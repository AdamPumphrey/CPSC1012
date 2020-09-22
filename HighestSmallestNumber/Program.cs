using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Determine the highest and smallest number from three inputted values
Input: number1, number2, number3
Output: highest, smallest
Written By: Adam Pumphrey
Last Modified: Sept. 22, 2020
*/

namespace HighestSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1,
                number2,
                number3,
                highest,
                smallest;

            Console.Write("Enter number1: ");
            number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter number2: ");
            number2 = int.Parse(Console.ReadLine());

            Console.Write("Enter number3: ");
            number3 = int.Parse(Console.ReadLine());

            highest = number1;
            smallest = number1;

            if (number2 > highest)
            {
                highest = number2;
            }
            else if (number2 < smallest)
            {
                smallest = number2;
            }

            if (number3 > highest)
            {
                highest = number3;
            }
            else if (number3 < smallest)
            {
                smallest = number3;
            }

            Console.WriteLine("The highest is {0} and the smallest is {1}", highest, smallest);

            Console.ReadLine();
        }
    }
}
