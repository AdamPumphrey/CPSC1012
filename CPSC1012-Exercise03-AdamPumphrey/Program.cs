using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Show various litre conversions
Input: option, pints, quarts, gallons
Output: pints, quarts, gallons, litres
Written By: Adam Pumphrey
Last Modified: Sept. 29, 2020
*/

namespace CPSC1012_Exercise03_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            const double PintToLitre = 1.75975, QuartToLitre = 0.879877, GallonToLitre = 0.219969;

            int option;

            double pints,
                   quarts,
                   gallons,
                   litres;

            Console.WriteLine("Choose your conversion:");
            Console.WriteLine("\t1. Pints to Litres");
            Console.WriteLine("\t2. Quarts to Litres");
            Console.WriteLine("\t3. Gallons to Litres");
            Console.Write("Option: ");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("\nEnter number of Pints: ");
                    pints = double.Parse(Console.ReadLine());

                    litres = pints / PintToLitre;
                    Console.WriteLine("{0:0.00} pints = {1:0.00} litres", pints, litres);
                    break;

                case 2:
                    Console.Write("\nEnter number of Quarts: ");
                    quarts = double.Parse(Console.ReadLine());

                    litres = quarts / QuartToLitre;
                    Console.WriteLine("{0:0.00} quarts = {1:0.00} litres", quarts, litres);
                    break;

                case 3:
                    Console.Write("\nEnter number of Gallons: ");
                    gallons = double.Parse(Console.ReadLine());

                    litres = gallons / GallonToLitre;
                    Console.WriteLine("{0:0.00} gallons = {1:0.00} litres", gallons, litres);
                    break;

                default:
                    Console.WriteLine("\nInvalid option.");
                    break;
            }

            Console.ReadLine();
        }
    }
}
