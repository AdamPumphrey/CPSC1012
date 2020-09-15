using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Calculate West Coast sales based on total sales
Input:          N/A
Output:         sales
Written By:     Adam Pumphrey
Last Modified:  Sept. 15, 2020
*/ 

namespace WestCoastSales
{
    class Program
    {
        static void Main(string[] args)
        {
            const double Percentage = 0.43,
                TotalSales = 5300000;

            double sales;

            sales = TotalSales * Percentage;

            // :c displays value as currency
            Console.WriteLine("West Coast sales is {0:c}", sales);

            // :0.00 displays value with specified number of decimal places (rounded)
            Console.WriteLine("West Coast sales is {0:0.00}", sales);

            Console.ReadLine();
        }
    }
}
