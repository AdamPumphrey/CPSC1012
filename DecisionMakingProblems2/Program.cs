using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Decision Making Problemset 2 - Problem 1
Input: package, hours
Output: package, totalBill
Written By: Adam Pumphrey
Last Modified: Sept. 26, 2020
*/

namespace DecisionMakingProblems2
{
    class Program
    {
        static void Main(string[] args)
        {
            const double PackageA = 9.95, PackageB = 13.95, PackageC = 19.95, AdditionalA = 2.00, AdditionalB = 1.00;

            char package;

            double hours,
                   monthlyBill,
                   additionalBill,
                   totalBill,
                   additionalHours;

            bool valid = true;

            // Initializing all to 0 since they are used in calulations
            monthlyBill = additionalBill = totalBill = hours = additionalHours = 0;

            Console.WriteLine("Select your plan:");
            Console.WriteLine("A. Package A");
            Console.WriteLine("B. Package B");
            Console.WriteLine("C. Package C");
            Console.Write("Option: ");
            package = char.Parse(Console.ReadLine().ToUpper());

            if (package == 'A' || package == 'B')
            {
                Console.Write("Enter the number of hours used: ");
                hours = double.Parse(Console.ReadLine());
            }

            switch (package)
            {
                case 'A':
                    if (hours > 10)
                    {
                        additionalHours = hours - 10;
                        hours = 10;
                    }
                    additionalBill = additionalHours * AdditionalA;
                    monthlyBill = hours * PackageA;
                    totalBill = additionalBill + monthlyBill;
                    break;

                case 'B':
                    if (hours > 20)
                    {
                        additionalHours = hours - 20;
                        hours = 20;
                    }
                    additionalBill = additionalHours * AdditionalB;
                    monthlyBill = hours * PackageB;
                    totalBill = additionalBill + monthlyBill;
                    break;

                case 'C':
                    totalBill = PackageC;
                    break;

                default:
                    valid = false;
                    break;
            }

            if (valid)
            {
                Console.WriteLine("You chose Package {0}. Your bill is {1:c}.", package, totalBill);
            }
            else
            {
                Console.WriteLine("\nInvalid option");
            }

            Console.ReadLine();
        }
    }
}
