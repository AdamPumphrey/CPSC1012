using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/*
Purpose: Practice looping
Input:
Output:
Written By: Adam Pumphrey
Last Modified: Oct. 4, 2020
*/

namespace LoopProblems2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Days = "Sun\tMon\tTue\tWed\tThu\tFri\tSat";

            int[] calendar = new int[38];

            for (int i = 0; i < calendar.Length; i++)
            {
                calendar[i] = 0;
            }

            int numberOfDays,
                index = 0,
                day = 1;

            string firstDay;

            bool newline = false;

            //Problem 1
            Console.Write("Enter number of days: ");
            numberOfDays = int.Parse(Console.ReadLine());

            Console.Write("Enter first day of the month: ");
            firstDay = Console.ReadLine();

            if (firstDay == "Mon")
            {
                index = 1;
            }
            else if (firstDay == "Tue")
            {
                index = 2;
            }
            else if (firstDay == "Wed")
            {
                index = 3;
            }
            else if (firstDay == "Thu")
            {
                index = 4;
            }
            else if (firstDay == "Fri")
            {
                index = 5;
            }
            else if (firstDay == "Sat")
            {
                index = 6;
            }

            while (day <= numberOfDays)
            {
                calendar[index] = day;
                index++;
                day++;
            }

            Console.WriteLine("\n{0}", Days);

            for (int i = 0; i < calendar.Length; i++)
            {
                if (((i+1) % 7) == 0)
                {
                    newline = true;
                }

                if (calendar[i] != 0 && newline)
                {
                    Console.Write(" {0}\n", calendar[i]);
                }
                else if (calendar[i] != 0)
                {
                    Console.Write(" {0}\t", calendar[i]);
                }
                else
                {
                    Console.Write("\t");
                }

                newline = false;
            }

            //Problem 2


            Console.ReadLine();
        }
    }
}
