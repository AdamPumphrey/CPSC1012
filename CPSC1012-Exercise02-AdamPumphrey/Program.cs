using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Find surface area and volume of regular cylinder
Input: radius, height
Output: radius, height, surfaceArea, volume
Written By: Adam Pumphrey
Last Modified: Sept. 18, 2020
*/

namespace CPSC1012_Exercise02_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pi = Math.PI;

            double radius,
                   height,
                   surfaceArea,
                   volume;

            Console.Write("Enter the radius of the cylinder: ");
            radius = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the cylinder: ");
            height = double.Parse(Console.ReadLine());

            surfaceArea = 2 * pi * radius * height;

            volume = pi * (Math.Pow(radius, 2)) * height;

            Console.WriteLine("The surface area of a cylinder with a radius of {0} and a height of {1} is {2}", radius, height, surfaceArea);
            Console.WriteLine();
            Console.WriteLine("The volume of a cylinder with a radius of {0} and a height of {1} is {2}", radius, height, volume);

            Console.ReadLine();
        }
    }
}
