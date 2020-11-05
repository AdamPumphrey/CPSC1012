using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Create a program for a user to enter up to 25 names until they enter 'zzz', and allow user to search list
Input:              name, searchOption, searchItem, restartSearch
Output:             indices[index]
Written By:         Adam Pumphrey
Last Modified:      Nov. 4, 2020
*/

namespace ArrayProblem2
{
    class Program
    {
        const int PhysicalSize = 25;

        static void Main(string[] args)
        {
            string[] names = new string[PhysicalSize];

            string searchItem;

            char searchOption;

            List<int> indices = new List<int> { };

            fillArray(names);

            searchOption = GetSafeChar("\nEnter 'y' to search, 'n' to exit: ");

            if (searchOption == 'Y')
            {
                do
                {
                    searchItem = GetSafeString("\nEnter a name to search for: ");
                    // StringComparison.CurrentCultureIgnoreCase performs case insensitive comparison
                    if (!searchItem.Equals("done", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // obtain indices where item is found in names array
                        searchArray(names, searchItem, indices);

                        // if item is found more than once
                        if (indices.Count > 1)
                        {
                            Console.WriteLine("\n" + searchItem.ToLower() + " is found at indices:");
                            Console.WriteLine();
                            for (int i = 0; i < indices.Count; i++)
                            {
                                Console.WriteLine("{0}", indices[i]);
                            }
                        }
                        // item occurs only once
                        else if (indices.Count == 1)
                        {
                            Console.WriteLine("\n" + searchItem.ToLower() + " is found at index {0}", indices[0]);
                        }
                        // item not found
                        else
                        {
                            Console.WriteLine("\n" + searchItem.ToLower() + " is not found in the names list");
                        }

                        Console.WriteLine("\nRestarting search...");
                    }
                } while (!searchItem.Equals("done", StringComparison.CurrentCultureIgnoreCase));
            }

            Console.WriteLine("\nProgram complete.");

            Console.ReadLine();
        }

        static void fillArray(string[] names)
        {
            int currentSize = 0;
            string name;
            do
            {
                name = GetSafeString("\nEnter a name: ");
                // StringComparison.CurrentCultureIgnoreCase performs case insensitive comparison
                if (!name.Equals("zzz", StringComparison.CurrentCultureIgnoreCase))
                {
                    names[currentSize] = name;
                    currentSize++;
                }
            // exit if size hits 25 or if 'zzz' is entered (case insensitive)
            } while (currentSize < PhysicalSize && !name.Equals("zzz", StringComparison.CurrentCultureIgnoreCase));
        }

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
                    Console.WriteLine("\nNothing inputted ... try again");
                }
            } while (!isValid);
            return name;
        }

        static void searchArray(string[] names, string searchItem, List<int> indices)
        {
            for (int index = 0; index < names.Length; index++)
            {
                if (searchItem.Equals(names[index], StringComparison.CurrentCultureIgnoreCase))
                {
                    // add index of found item to list
                    indices.Add(index);
                }
            }
        }

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
                    // modified to only accept y or n for this problem
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
            return character;
        }
    }
}
