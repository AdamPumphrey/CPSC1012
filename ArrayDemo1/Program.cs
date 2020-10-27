using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate how to:
                1. Create an array
                2. Pass an array as an argument to a method
                3. Process an array element, or elements
Input:			N/A	
Output:			data from an array 
Written By: 	Adam Pumphrey
Last Modified:	Oct. 27, 2020
*/

namespace ArrayDemo1
{
    class Program
    {
        //class level constants
        const int MaxGrade = 100,
                MinGrade = 0;

        static void Main(string[] args)
        {
            Setup();

            //declare constants and variables
            const int PhysicalSize = 10;

            int[] randomGrades = new int[PhysicalSize];
            int[] enteredGrades = new int[PhysicalSize];

            int highestGrade,
                lowestGrade,
                filledSize;

            double average;

            //load the array with 100 random grades
            LoadArrayRandom(randomGrades, PhysicalSize);

            //find the highest grade
            highestGrade = FindHighestNumber(randomGrades, randomGrades.Length);

            //find the lowest grade
            lowestGrade = FindLowestNumber(randomGrades, randomGrades.Length);

            //calculate the average grade
            average = CalculateAverage(randomGrades, randomGrades.Length);

            //display the results 
            Console.WriteLine("Randomly filled array results");
            Console.WriteLine("The highest grade is: {0:0.00}", highestGrade);
            Console.WriteLine(" The lowest grade is: {0:0.00}", lowestGrade);
            Console.WriteLine("The average grade is: {0:0.00}", average);


            Console.WriteLine();
            //load the array with entered grades
            filledSize = LoadArrayNonRandom(enteredGrades, PhysicalSize);

            //find the highest grade
            highestGrade = FindHighestNumber(enteredGrades, filledSize);

            //find the lowest grade
            lowestGrade = FindLowestNumber(enteredGrades, enteredGrades.Length);

            //calculate the average grade
            average = CalculateAverage(enteredGrades, enteredGrades.Length);

            Console.WriteLine("\nManually filled array results");
            Console.WriteLine("Randomly filled array results");
            Console.WriteLine("The highest grade is: {0:0.00}", highestGrade);
            Console.WriteLine(" The lowest grade is: {0:0.00}", lowestGrade);
            Console.WriteLine("The average grade is: {0:0.00}", average);

            Console.ReadLine();
        }//eom

        static void Setup()
        {
            Console.Title = "Array Demo 1";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        static void LoadArrayRandom(int[] numbers, int size)
        {
            //this array will be loaded with random numbers between 0 and 100 inclusive
            Random rnd = new Random();
            //loop to load the array
            for(int index = 0; index < size; index++)
            {
                numbers[index] = rnd.Next(MinGrade, MaxGrade + 1);
            }
            
            
        }//end of LoadArrayRandom

        static int FindHighestNumber(int[] numbers, int size)
        {
            //set highest number temporarily to the first array element
            int highest = numbers[0];
            //loop through array to set highest number
            for (int index = 1; index < size; index++)
            {
                if (numbers[index] > highest)
                {
                    highest = numbers[index];
                }
            }
            
            return highest;
        }//end of FindHighestNumber

        static int FindLowestNumber(int[] numbers, int size)
        {
            //set lowest number temporarily to the first array element
            int lowest = numbers[0];
           
            //loop through array to set highest number
            for (int index = 1; index < size; index++)
            {
                if (numbers[index] < lowest)
                {
                    lowest = numbers[index];
                }
            }

            return lowest;
        }//end of FindLowestNumber

        static double CalculateAverage(int[] numbers, int size)
        {
            double average = 0;
            
            //loop through the array and accumulate average (i.e. add up all grades)
            for (int index = 0; index < size; index++)
            {
                average += numbers[index];
            }

            average /= numbers.Length;
            
            return average;
        }//end of CalculateAverage

        static int GetSafeInt(string prompt)
        {
            int grade = -1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,25}", prompt);
                    grade = int.Parse(Console.ReadLine());
                    if (grade >= MinGrade  - 1 && grade <= MaxGrade)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: not a valid grade ... please try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: not a valid grade ... please try again");
                }
            } while (!isValid);
            return grade;
        }//end of GetSafeInt

        static int LoadArrayNonRandom(int[] numbers, int size)
        {
            int number,
                index = 0;

            do
            {
                number = GetSafeInt("Enter a grade between " + MinGrade + " and " + MaxGrade + " inclusive, or -1 to ext: ");
                if (number >= MinGrade)
                {
                    numbers[index] = number;
                    index++;
                }
            } while (number >= MinGrade && index < size);

            return index; // returns manually filled size of the array
        }//end of LoadArrayNonRandom
    }//eoc
}//eon
