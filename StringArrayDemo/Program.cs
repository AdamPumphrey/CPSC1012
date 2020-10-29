using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate an alternative way to create an array. Additionally, this demo will use
                some new array algorithms.
Input:			initialized string array	
Output:			output from the array 
Written By: 	Adam Pumphrey 
Last Modified:	Oct. 29, 2020
*/

namespace StringArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            //declare variables
            int stringArrayLength;
            //create and initialize an array of strings
            string[] names = { "allan", "bob", "sally", "dave", "alfred", "fred", "Zack", "Albert" };
            int[] numbers = { 1, 43, 32, 34, 45, 43 };
            //What is the length (physical size) of the array?
            stringArrayLength = names.Length;
            //Create an array from the existing array
            string[] aNames = CreateArray(names, stringArrayLength);
            //Display the contents of the array
            DisplayArray(names, stringArrayLength);
            Console.WriteLine();
            DisplayArray(aNames, aNames.Length);

            Console.ReadLine();
        }//eom

        static void DisplayArray(string[] names, int size)
        {
            for (int index = 0; index < size; index++)
            {
                if (names[index] != null)
                {
                    Console.WriteLine(names[index]);
                }
            }
        }//end of DisplayArray

        static string[] CreateArray(string[] names, int size)
        {
            //need a string[] to return
            List<string> aNamesList = new List<string>();
            //int count = 0;
            //loop through the array
            for(int index = 0; index < size; index++)
            {
                if (names[index].ToLower().StartsWith("a"))
                {
                    aNamesList.Add(names[index]);
                    //count++;
                }
            }
            return aNamesList.ToArray();
        }//end of CreateArray

        #region Provided Methods
        static void Setup()
        {
            Console.Title = "String Array Demo";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

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
        #endregion
    }//eoc
}//eon
