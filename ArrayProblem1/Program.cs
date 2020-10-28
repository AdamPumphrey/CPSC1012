using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Create program that allows up to 25 int inputs to an array and display array
Input:          numberInput
Output:         values of array
Written By:     Adam Pumphrey
Last Modified:  Oct. 28, 2020
*/

namespace ArrayProblem1
{
    class Program
    {
        const int PhysicalSize = 25;

        static void Main(string[] args)
        {
            int[] numbers = new int[PhysicalSize];

            int currentSize;

            // load array with values and return size of array
            currentSize = loadArray(numbers);

            // display values in array
            displayArray(numbers, currentSize);

            Console.ReadLine();
        }

        // taken from my core portfolio 2, modified for this problem
        static int GetSafeInt(string prompt)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    // validate int input
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        static int loadArray(int[] numbers)
        {
            int numberInput,
                index = 0;
            do
            {
                numberInput = GetSafeInt("Enter a positive number to add to the array, or enter 0 to terminate: ");
                if (numberInput > 0)
                {
                    numbers[index] = numberInput;
                    index++;
                }

            } while (numberInput != 0 && index < PhysicalSize);

            if (index == PhysicalSize)
            {
                Console.WriteLine("\nMax array size reached");
            }

            return index;
        }

        static void displayArray(int[] numbers, int size)
        {
            if (size == 0)
            {
                Console.WriteLine("\nThe array is empty - no values entered");
            }
            else
            {
                Console.WriteLine("\nThe numbers entered into the array are, in order:");
                for (int index2 = 0; index2 < size; index2++)
                {
                    Console.WriteLine("\t{0}", numbers[index2]);
                }
            }
            
        }
    }
}
