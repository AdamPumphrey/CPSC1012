using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		*Edited to use parallel arrays for loading and sorting*

                Demonstrate the following array algorithms:
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
Last Modified:	Nov. 6, 2020
*/

namespace ArrayDemo2
{
    class Program
    {
        //class level constants
        const int MaxGrade = 100,
                  MinGrade = 0,
                  PhysicalSize = 10;

        static void Main(string[] args)
        {
            Setup();

            //declare constants and variables
            int firstLocation,
                searchNumber,
                currentSize;
            bool found;
            int count;
            string searchName;

            // test data from demo
            //int[] grades = { 42, 50, 36, 50, 88, 36, 67, 53, 89, 19 };
            //string[] names = { "Allan", "Sally", "Doug", "George", "Stanley", "Zack", "Fred", "Betty", "Henry", "Donald" };

            //Load the  parallel arrays
            int[] grades = new int[PhysicalSize];
            string[] names = new string[PhysicalSize];

            currentSize = LoadArray(names, grades, PhysicalSize);

            searchNumber = GetSafeInt("\nEnter a number to search for: ");
            searchName = GetSafeString("Enter the name to search for: ");

            //Search the array for a mark using each of the search algorithms
            //1. First location
            firstLocation = SearchArrayIndex(grades, currentSize, searchNumber);
            if (firstLocation >= 0)
            {
                Console.WriteLine("\nFirst location of {0} is at index = {1}", searchNumber, firstLocation);
            }
            else
            {
                Console.WriteLine("{0} is not found", searchNumber);
            }
            // string search
            firstLocation = SearchArrayIndex(names, currentSize, searchName);
            if (firstLocation >= 0)
            {
                Console.WriteLine("First location of {0} is at index = {1}", searchName, firstLocation);
            }
            else
            {
                Console.WriteLine("{0} is not found", searchName);
            }

            //1.b Count search
            count = SearchArrayCount(grades, currentSize, searchNumber);
            Console.WriteLine("{0} appears {1} times", searchNumber, count);
            //string search
            count = SearchArrayCount(names, currentSize, searchName);
            Console.WriteLine("{0} appears {1} times", searchName, count);

            //1.c Boolean search
            found = SearchArrayBoolean(grades, currentSize, searchNumber);
            Console.WriteLine("{0}: " + found, searchNumber);
            //string search
            found = SearchArrayBoolean(names, currentSize, searchName);
            Console.WriteLine("{0}: " + found, searchName);

            //parallel array sorting:

            Console.WriteLine("\nUnsorted:");
            DisplayArray(names, grades, currentSize);
            // sort arrays
            SelectionSort(names, grades, currentSize);

            Console.WriteLine("\nSorted:");
            DisplayArray(names, grades, currentSize);

            Console.ReadLine();
        }//eom

        #region User defined & modified methods
        //This search algorithm returns a true if the search item is found anywhere in the array, else false
        static bool SearchArrayBoolean(int[] grades, int size, int searchValue)
        {
            bool found = false;
            for (int index = 0; index < size; index++)
            {
                if (searchValue == grades[index])
                {
                    found = true;
                    index = size;
                }
            }
            return found;
        }//end of SearchArrayBoolean

        static bool SearchArrayBoolean(string[] names, int size, string searchName)
        {
            bool found = false;
            for (int index = 0; index < size; index++)
            {
                if (searchName.ToLower().Equals(names[index].ToLower()))
                {
                    found = true;
                    index = size;
                }
            }
            return found;
        }

        //This search algorith return the index location of the first location in the array of the search item
        static int SearchArrayIndex(int[] grades, int size, int searchValue)
        {
            int location = -1; // -1 is not a valid index in C#
            for (int index = 0; index < size; index++)
            {
                if (grades[index] == searchValue)
                {
                    location = index;
                    index = size;
                }
            }
            return location;
        }//end of SearchArrayIndex

        //This search algorith return the index location of the first location in the array of the search item
        static int SearchArrayIndex(string[] names, int size, string searchName)
        {
            int location = -1; // -1 is not a valid index in C#
            for (int index = 0; index < size; index++)
            {
                if (searchName.ToLower().Equals(names[index].ToLower()))
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
            for (int index = 0; index < size; index++)
            {
                if (searchValue == grades[index])
                {
                    count++;
                }
            }
            return count;
        }//end of SearchArrayCount

        static int SearchArrayCount(string[] names, int size, string searchName)
        {
            int count = 0;
            for (int index = 0; index < size; index++)
            {
                if (searchName.ToLower().Equals(names[index].ToLower()))
                {
                    count++;
                }
            }
            return count;
        }//end of SearchArrayCount

        static void DisplayArray(string[] names, int[] grades, int size)
        {
            for (int index = 0; index < size; index++)
            {
                Console.WriteLine("{0} has a grade of {1}", names[index], grades[index]);
            }
        }

        // sorts grades array, moves items in names accordingly
        static void SelectionSort(string[] names, int[] grades, int size)
        {
            int minIndex,
                minGradeValue,
                tempGrade;

            string tempName;

            for (int startScan = 0; startScan < size - 1; startScan++)
            {
                //assume, for now, the first element has the smallest value
                //minIndex = startScan;
                minGradeValue = grades[startScan];
                //now look at the rest of the array
                for (int index = startScan; index < size; index++)
                {
                    if (grades[index] < minGradeValue)
                    {
                        minGradeValue = grades[index];
                        minIndex = index;
                        //now swap
                        tempGrade = grades[minIndex];
                        tempName = names[minIndex];
                        grades[minIndex] = grades[startScan];
                        names[minIndex] = names[startScan];
                        grades[startScan] = tempGrade;
                        names[startScan] = tempName;
                    }//end if
                }//end inner for
            }//end outer for
        }//end of SelectionSort

        static int LoadArray(string[] names, int[] grades, int size)
        {
            int index = 0;

            string name = "";

            bool isValid;

            while (index < size && !name.Equals("zzz"))
            {
                isValid = false;
                do
                {
                    name = GetSafeString("\nEnter the name of the student (zzz to stop): ").ToLower();
                    if (!names.Contains(name) && !name.Equals("zzz"))
                    {
                        names[index] = name;
                        grades[index] = GetSafeInt("\nEnter the grade the student received: ");
                        isValid = true;
                    }
                    else if (names.Contains(name))
                    {
                        Console.WriteLine("Name already exists. Please enter a different name.");
                    }
                } while (!isValid && !name.Equals("zzz"));
                
                if (!name.Equals("zzz"))
                {
                    index++;
                }
            }

            return index;
        }

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
                Console.Write(prompt);
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
                    if (option == 'Y' || option == 'N')
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
