using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Convert given square foot value to acres
Input:          sqft
Output:         acres
Written By:     Adam Pumphrey
Last Modified:  Sept. 15, 2020
*/

namespace AcreConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 acre = 43560 sq ft
            const int ConversionRatio = 43560;

            double sqft,
                   acres;

            Console.Write("Enter Square Footage: ");
            sqft = double.Parse(Console.ReadLine());

            acres = sqft / ConversionRatio;

            Console.WriteLine("{0} square feet = {1:0.00} acres", sqft, acres);

            Console.ReadLine();
        }
    }
}
