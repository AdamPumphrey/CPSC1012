using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Purpose: String.Compare() demo
Input: string1, string2
Output: compare
Written By: Adam Pumphrey
Last Modified: Sept. 24, 2020
*/

namespace StringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1,
                   string2,
                   first,
                   second;

            Console.Write("Enter string1: ");
            string1 = Console.ReadLine();
            Console.Write("Enter string2: ");
            string2 = Console.ReadLine();

            if (string.Compare(string1, string2) < 0)
            {
                first = string1;
                second = string2;
            }
            else if (string.Compare(string1, string2) > 0)
            {
                first = string2;
                second = string1;
            }
            else
            {
                first = "Same string";
                second = first;
            }

            Console.WriteLine("First = {0}\t\tSecond = {1}", first, second);

            Console.ReadLine();
        }
    }
}
