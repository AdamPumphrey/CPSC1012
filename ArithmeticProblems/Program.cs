using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Practice arithmetic problems
Input:          number1, number2, number3, triHeight, triBase, threeDigitNum
Output:         number1, number2, number3, numberAverage, triHeight, triBase, triHypotenuse, threeDigitNum, numSum
Written By:     Adam Pumphrey
Last Modified:  Sept. 17, 2020
*/

namespace ArithmeticProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialization
            double number1,
                   number2,
                   number3,
                   numberAverage,
                   triHeight,
                   triBase,
                   triHypotenuse;

            int threeDigitNum,
                temp,
                numSum = 0;


            //Problem 1
            Console.Write("Enter number 1: ");
            number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            number2 = double.Parse(Console.ReadLine());
            Console.Write("Enter number 3: ");
            number3 = double.Parse(Console.ReadLine());

            numberAverage = (number1 + number2 + number3) / 3;
            Console.WriteLine("The average of the three numbers is: {0}", numberAverage);

            Console.WriteLine();

            //Problem 2
            numberAverage = Math.Round(numberAverage, 2);

            Console.WriteLine("The average of the three numbers is: {0}", numberAverage);

            Console.WriteLine();

            //Problem 3
            Console.Write("Enter the height of the right triangle: ");
            triHeight = double.Parse(Console.ReadLine());
            Console.Write("Enter the base of the right triangle: ");
            triBase = double.Parse(Console.ReadLine());

            triHypotenuse = Math.Sqrt((Math.Pow(triHeight, 2)) + (Math.Pow(triBase, 2)));
            Console.WriteLine("The hypotenuse of the right triangle with a height of {0} and a base of {1} is {2}", triHeight, triBase, triHypotenuse);

            Console.WriteLine();

            //Problem 4
            Console.Write("Enter a three digit number: ");
            threeDigitNum = int.Parse(Console.ReadLine());
            temp = threeDigitNum;

            while (temp != 0)
            {
                numSum += temp % 10;
                temp /= 10;
            }

            Console.WriteLine("The digit sum of {0} is {1}", threeDigitNum, numSum);

            Console.ReadLine();
        }
    }
}
