using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Practice looping
Input:              input, number
Output:             average
Written By:         Adam Pumphrey
Last Modified:      Oct. 4, 2020
*/

namespace LoopProblems1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int input,
                totalNum,
                sum = 0,
                average;

            string number;

            //Problem 2
            Console.Write("Enter a number or enter 0 to stop: ");
            input = int.Parse(Console.ReadLine());

            if (input > 0)
            {
                while (input > 0)
                {
                    numbers.Add(input);
                    Console.Write("Enter a number or enter 0 to stop: ");
                    input = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                numbers.Add(0);
            }

            totalNum = numbers.Count;

            foreach (int num in numbers)
            {
                sum += num;
            }

            average = sum / totalNum;

            Console.WriteLine("\nThe average of the entered numbers is {0}", average);
            Console.WriteLine();

            //Problem 3

            Console.Write("Enter a number: ");
            number = Console.ReadLine();

            for (int i = (number.Length - 1); i >= 0; i--)
            {
                Console.WriteLine(number[i]);
            }

            Console.ReadLine();
        }
    }
}
