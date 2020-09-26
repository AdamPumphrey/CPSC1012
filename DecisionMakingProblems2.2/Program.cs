using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Decision Making Problemset 2 - Question 2
Input: option, kg, lb, l, oz, cm, inches, C, F
Output: kg, lb, l, oz, cm, inches, C, F
Written By: Adam Pumphrey
Last Modified: Sept. 26, 2020
*/

namespace DecisionMakingProblems2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            const double KgLB = 2.20462, LOz = 33.8140226, CmIn = 0.393701, CFRatio = 1.8, CFConst = 32;

            int option;

            double kg,
                   lb,
                   l,
                   oz,
                   cm,
                   inches,
                   C,
                   F;
            
            Console.WriteLine("Choose your conversion:");
            Console.WriteLine("\t1. lb to kg");
            Console.WriteLine("\t2. kg to lb");
            Console.WriteLine("\t3. oz to l");
            Console.WriteLine("\t4. l to oz");
            Console.WriteLine("\t5. in to cm");
            Console.WriteLine("\t6. cm to in");
            Console.WriteLine("\t7. F to C");
            Console.WriteLine("\t8. C to F");
            Console.Write("Option: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("\nEnter lb: ");
                    lb = double.Parse(Console.ReadLine());

                    kg = lb / KgLB;
                    Console.WriteLine("\n{0:0.00} lb = {1:0.00} kg", lb, kg);
                    break;

                case 2:
                    Console.Write("\nEnter kg: ");
                    kg = double.Parse(Console.ReadLine());

                    lb = kg * KgLB;
                    Console.WriteLine("\n{0:0.00} kg = {1:0.00} lb", kg, lb);
                    break;

                case 3:
                    Console.Write("\nEnter oz: ");
                    oz = double.Parse(Console.ReadLine());

                    l = oz / LOz;
                    Console.WriteLine("\n{0:0.00} oz = {1:0.00} l", oz, l);
                    break;

                case 4:
                    Console.Write("\nEnter l: ");
                    l = double.Parse(Console.ReadLine());

                    oz = l * LOz;
                    Console.WriteLine("\n{0:0.00} l = {1:0.00} oz", l, oz);
                    break;

                case 5:
                    Console.Write("\nEnter inches: ");
                    inches = double.Parse(Console.ReadLine());

                    cm = inches / CmIn;
                    Console.WriteLine("\n{0:0.00} in = {1:0.00} cm", inches, cm);
                    break;

                case 6:
                    Console.Write("\nEnter cm: ");
                    cm = double.Parse(Console.ReadLine());

                    inches = cm * CmIn;
                    Console.WriteLine("\n{0:0.00} cm = {1:0.00} in", cm, inches);
                    break;

                case 7:
                    Console.Write("\nEnter degrees in F: ");
                    F = double.Parse(Console.ReadLine());

                    C = (F - CFConst) / CFRatio;
                    Console.WriteLine("\n{0:0.0} F = {1:0.0} C", F, C);
                    break;

                case 8:
                    Console.Write("\nEnter degrees in C: ");
                    C = double.Parse(Console.ReadLine());

                    F = (C * CFRatio) + CFConst;
                    Console.WriteLine("\n{0:0.0} C = {1:0.0} F", C, F);
                    break;

                default:
                    Console.WriteLine("\nInvalid option");
                    break;
            }

            Console.ReadLine();
        }
    }
}
