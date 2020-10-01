﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:        Demonstrate the different types of loops in calculating the sum of squares:
                Find the sum of the squares of the integers from 1 to mySquare, 
                where mySquare is input by the user, e.g. user enters 4 then return
                1x1 + 2x2 + 3x3 + 4x4 = 30.
                
                1) Pre-test using while
                2) Pre-test using for (replace the existing while loop with the for loop)
                3) Post-test using do to do:
                    a. input validation
                    b. continue loop
Input:            mySquare    
Output:            sumOfSquares
Written By:     Adam Pumphrey 
Last Modified:    Oct 1, 2020 
*/

namespace LoopProblem1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Loop Problem 1 Q1";
            Console.Clear();

            int mySquare,
                    sumOfSquares,
                    start = 1;

            char doAgain;

            do
            {
                sumOfSquares = 0;
                Console.Write("Enter the maximum value for the sum of squares: ");
                mySquare = int.Parse(Console.ReadLine());

                //pre-test using while structure
                //while (start <= mySquare)
                //{
                //    sumOfSquares += start * start;
                //    start++;
                //}

                //pre-test using for loop structure
                for (int startValue = 1; startValue <= mySquare; startValue++)
                {
                    sumOfSquares += startValue * startValue;
                }

                Console.WriteLine("Sum of squares to {0} is {1}", mySquare, sumOfSquares);

                Console.Write("\nStop (Y)? ");
                doAgain = char.Parse(Console.ReadLine().ToLower());

            } while (doAgain != 'y');

            Console.ReadLine();
        }
    }
}
