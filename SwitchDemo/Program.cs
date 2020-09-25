using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Demonstrate use of switch() with int and char data types
Input:          intOption, charOption
Output:         message
Written By:     Adam Pumphrey
Last Modified:  Sept. 25, 2020
*/

namespace SwitchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Switch Demos";

            int intOption;

            char charOption;

            string message;

            Console.WriteLine("Select from one of the following options:");
            Console.WriteLine("\t1. First int item");
            Console.WriteLine("\t2. Second int item");
            Console.WriteLine("\t3. Third int item");
            Console.Write("Option: ");

            intOption = int.Parse(Console.ReadLine());

            switch (intOption)
            {
                case 1:
                    message = "First int item";
                    break;

                case 2:
                    message = "Second int item";
                    break;

                case 3:
                    message = "Third int item";
                    break;

                default:
                    message = "Invalid option";
                    break;
            }

            Console.WriteLine("\nInt menu output:");
            Console.WriteLine("{0}\n", message);

            Console.WriteLine("Select from one of the following options:");
            Console.WriteLine("\tA. First char item");
            Console.WriteLine("\tB. Second char item");
            Console.WriteLine("\tC. Third char item");
            Console.Write("Option: ");

            charOption = char.Parse(Console.ReadLine().ToUpper());

            switch (charOption)
            {
                case 'A':
                    message = "First char item";
                    break;

                case 'B':
                    message = "Second char item";
                    break;

                case 'C':
                    message = "Third char item";
                    break;

                default:
                    message = "Invalid option";
                    break;
            }

            Console.WriteLine("\nChar menu output:");
            Console.WriteLine("{0}\n", message);

            Console.ReadLine();
        }
    }
}
