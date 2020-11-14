using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate how to create and process a List<T> using a simple data type using the following methods:
                1. AddName()
                2. DisplayNames()
                3. SearchName()
                4. SortNames()
                5. RemoveName()
Input:			names entered and validated with GetSafeString()
Output:			data stored in the List<T> 
Written By: 	Allan Anderson 
Last Modified:	Nov. 13, 2020
*/

namespace List_T_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            //variables
            List<string> names = new List<string>();
            char addAnother = 'Y';

            do
            {
                AddName(names);
                addAnother = GetSafeChar("Add another name (Y), exit (N): ");
            } while (addAnother == 'Y');

            DisplayNames(names);

            SortNames(names);

            DisplayNames(names);

            Console.ReadLine();
        }//eom

        //1. Add a name to the List<T>
        static void AddName(List<string> names)
        {
            string name = GetSafeString("Enter a name: ");
            names.Add(name);
        }//end of AddName

        //2. Display the names that are stored in the List<T>
        static void DisplayNames(List<string> names)
        {
            // similar to looping thru an array
            for (int index = 0; index < names.Count; index++)
            {
                Console.WriteLine(names[index]);
            }

            // better list-specific loop
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }//end of DisplayNames

        //3. Search for a name in the List<T>
        static int SearchNames(List<string> names, string searchName)
        {
            int index = -1;

           

            return index;
        }//end of SearchNames

        
        //4. Sort the names in the List<T> alphabetically
        static void SortNames(List<string> names)
        {
            names.Sort();
        }//end of SortNames

        //5. Remove an "element" from the List<T>
        static void RemoveName()
        {

        }//end of RemoveName

        #region Provided Methods - DO NOT MODIFY
        static void Setup()
        {
            Console.Title = "List<T> Demo";
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
                Console.Write(prompt);
                name = Console.ReadLine();
                if (name.Length > 0) 
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

        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                // validate char input
                try
                {
                    Console.Write(prompt);
                    character = char.Parse(Console.ReadLine().ToUpper());
                    if (character == 'Y' || character == 'N')
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

            // return valid char input
            return character;
        }
    }//eoc
}//eon
