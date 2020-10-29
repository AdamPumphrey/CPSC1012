using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate the following array algorithms:
                1. Searching an array:
                    a. return location
                    b. return count
                    c. return if found
                2. Sorting an array using the SelectionSort algorithm
                3. Parallel arrays
                4. Display array contents
Input:			user input for array data: name and grade	
Output:			1a. Location of first item found
                1b. How many?
                1c. is the value in the array?
Written By: 	Adam Pumphrey
Last Modified:	Oct. 29, 2020
*/

namespace ArrayDemo2
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
            int firstLocation;
            bool found;
            int count;

            //Load the arrays
            int[] grades = { 42, 50, 36, 50, 88 };

            //Search the array for a mark using each of the search algorithms
            //1. First location
            firstLocation = SearchArrayIndex(grades, grades.Length, 50);
            if (firstLocation >= 0)
            {
                Console.WriteLine("First location is at index = {0}", firstLocation);
            }
            else
            {
                Console.WriteLine("Not found");
            }

            //1.b Count search
            count = SearchArrayCount(grades, grades.Length, 50);
            Console.WriteLine("The item appears {0} times", count);

            //1.c Boolean search
            found = SearchArrayBoolean(grades, grades.Length, 50);
            Console.WriteLine(found);


            //Search the array for a name using each of the search algorithms


            //Sort the array(s)


            //Display the array(s)
            DisplayArray(grades, grades.Length);

            Console.ReadLine();
        }//eom

        #region User defined & modified methods
        //This search algorithm returns a true if the search item is found anywhere in the array, else false
        static bool SearchArrayBoolean(int[] grades, int size, int searchValue)
        {
            bool found = false;
            for(int index = 0; index < size; index++)
            {
                if (searchValue == grades[index])
                {
                    found = true;
                    index = size;
                }
            }
            return found;
        }//end of SearchArrayBoolean

        //This search algorith return the index location of the first location in the array of the search item
        static int SearchArrayIndex(int[] grades, int size, int searchValue)
        {
            int location = -1; // -1 is not a valid index in C#
            for(int index = 0; index < size; index++)
            {
                if (grades[index] == searchValue)
                {
                    location = index;
                    index = size;
                }
            }
            return location;
        }//end of SearchArrayIndex

        //This search algorith returns the count of all search items, or can be modified to return
        //  a count of a specific range of values inn the array
        static int SearchArrayCount(int[] grades, int size, int searchValue)
        {
            int count = 0;
            for(int index = 0; index < size; index++)
            {
                if (searchValue == grades[index])
                {
                    count++;
                }
            }
            return count;
        }//end of SearchArrayCount

        //This method displays a formatted output of the array data
        static void DisplayArray(int[] grades, int size)
        {
            for(int index = 0; index < size; index++)
            {
                Console.WriteLine("Index[{0}] has a grade of {1}", index, grades[index]);
            }
        }//end of DisplayArray

        //This method will need to be modified for this example
        static void SelectionSort(int[] numbers, int size)
        {
            int minIndex, 
                minValue;
            int temp;
            for (int startScan = 0; startScan < size - 1; startScan++)
            {
                //assume, for now, the first element has the smallest value
                minIndex = startScan;
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

        #region Provided Methods - DO NOT MODIFY!
        static void Setup()
        {
            Console.Title = "Array Demo 2";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

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
                    if (grade >= MinGrade - 1 && grade <= MaxGrade)
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

        static string GetSafeString(string prompt)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write("Enter yourn name: ");
                name = Console.ReadLine();
                if (name.Length > 0) //the 0 represents 1 value less than the minuimum required for the length
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Nothing inputted ... try again");
                }
            } while (!isValid);
            return name;
        }//end of GetSafeString

        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char option = ' ';
            do
            {
                try
                {
                    Console.Write(prompt);
                    option = char.Parse(Console.ReadLine().ToUpper());
                    if(option == 'Y' || option == 'N')
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invlaid option ... please try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invlaid option ... please try again");
                }
            } while (!isValid);
            return option;
        }//end of GetSafeChar
        #endregion
    }//eoc
}//eon
