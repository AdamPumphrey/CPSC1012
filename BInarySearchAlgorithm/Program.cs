using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate the BinarySearch algoritm for arrays	 
Input:				
Output:			 
Written By: 	Allan Anderson 
Last Modified:	Nov 5, 2020 
*/
    
namespace BInarySearchAlgorithm
{
    class Program
    {
        const int MinValue = 1,
            MaxValue = 100;
        static void Main(string[] args)
        {
            Setup();

            //variables and constants
            const int PhysicalSize = 25;
            int[] numbers = new int[PhysicalSize];
            int searchNumber,
                location;

            //1. Load the array with random numbers
            LoadArray(numbers, PhysicalSize);
            //2. Sort the array
            SelectionSort(numbers, PhysicalSize);
            //3. Get a number to search for
            searchNumber = GetSafeInt("Enter a number between " + MinValue + " and " + MaxValue + " inclusive: ");
            //4. Now do the Binary Search
            location = BinarySearch(numbers, PhysicalSize, searchNumber);
            if(location >= 0)
            {
                Console.WriteLine("The number {0} was found at [{1}]", searchNumber, location);
            }
            else
            {
                Console.WriteLine("The number {0} was not found in the array", searchNumber);
            }

            Console.ReadLine();
        }//eom

        static int BinarySearch(int[] numbers, int size, int searchNumber)
        {
            //1. Ensure array is sorted
            SelectionSort(numbers, size);
            //2. local scope variables
            int first = 0,
                last = size - 1,
                middle = (first + last + 1) / 2,
                location = -1;
            //3. loop
            while (first <= last && location == -1)
            {
                if (searchNumber > numbers[middle])
                {
                    first = middle + 1;
                }
                else if (searchNumber < numbers[middle])
                {
                    last = middle - 1;
                }
                else
                {
                    location = middle;
                }
                middle = (first + last + 1) / 2;
            }
            return location;
        }//end of BinarySearch

        #region Provided Methods - DO NOT MODIFY
        static void Setup()
        {
            Console.Title = "BinarySearch Algorithm Demo";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        static int GetSafeInt(string prompt)
        {
            int number = 0;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,25}", prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= MinValue && number <= MaxValue)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: not a valid number ... please try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: not a valid number ... please try again");
                }
            } while (!isValid);
            return number;
        }//end of GetSafeInt

        static void LoadArray(int[] numbers, int size)
        {
            Random rnd = new Random();
            //loop to load the array
            for (int index = 0; index < size; index++)
            {
                numbers[index] = rnd.Next(MinValue, MaxValue + 1);
            }//end for  
        }//end of LoadArray

        static void SelectionSort(int[] numbers, int size)
        {
            int minIndex, minValue;
            int temp;
            for (int startScan = 0; startScan < size - 1; startScan++)
            {
                //assume, for now, the first element has the smallest value
                minValue = numbers[startScan];
                //now look at the rest of the array
                for (int index = startScan; index < size; index++)
                {
                    if (numbers[index] < minValue)
                    {
                        minValue = numbers[index];
                        minIndex = index;
                        //now swap
                        temp = numbers[minIndex];
                        numbers[minIndex] = numbers[startScan];
                        numbers[startScan] = temp;
                    }//end if
                }//end inner for
            }//end outer for
        }//end of SelectionSort

        #endregion
    }//eoc
}//eon
