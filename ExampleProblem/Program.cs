using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Do some simple math
Inputs: number1, number2
Output: addition, subtraction, multiplication, division
Author: Adam Pumphrey
Date Modified: Sept. 10, 2020
*/
namespace ExampleProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            double number1, 
                number2, 
                sum, 
                difference, 
                product, 
                quotient;
            //inputs
            Console.Write("Enter number 1: ");
            number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            number2 = double.Parse(Console.ReadLine());
            //processes
            sum = number1 + number2;
            difference = number1 - number2;
            product = number1 * number2;
            quotient = number1 / number2;
            //output
            Console.WriteLine("Addition = " + sum);
            Console.WriteLine("Subtraction = {0}", difference);
            Console.WriteLine("Multiplication: {0} * {1} = {2}", number1, number2, product);
            Console.WriteLine("Division: " + number1 + " / " + number2 + " = " + quotient);

            //keep the console window open
            Console.ReadLine();
        }
    }
}
