using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose: Decision making problems 1
Input: numberInput, age, name, mark, taxIncome
Output: grade, taxDue
Written By: Adam Pumphrey
Last Modified: Sept. 24, 2020
*/

namespace DecisionMakingProblems1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput,
                age,
                mark;

            string name,
                   grade;

            double taxIncome,
                   taxDue,
                   amountOver;

            const double MaxTax = 0.09, MedTax = 0.07, MinTax = 0.05;

            // 1.
            Console.Write("Enter a number: ");
            numberInput = int.Parse(Console.ReadLine());

            if (numberInput > 0)
            {
                Console.WriteLine("Positive");
            }
            else if (numberInput < 0)
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Zero");
            }

            // 2.
            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());
            if (age >= 55)
            {
                Console.WriteLine("$10.00");
            }
            else if (age >= 18)
            {
                Console.WriteLine("$11.35");
            }
            else if (age >= 7)
            {
                Console.WriteLine("$9.80");
            }
            else
            {
                Console.WriteLine("FREE ($0.00)");
            }

            // 3.
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your mark: ");
            mark = int.Parse(Console.ReadLine());

            if (mark >= 90)
            {
                grade = "A";
            }
            else if (mark >= 80)
            {
                grade = "B";
            }
            else if (mark >= 70)
            {
                grade = "C";
            }
            else if (mark >= 50)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }

            Console.WriteLine("{0}'s grade is {1}", name, grade);

            // 4.
            Console.Write("Enter taxable income: ");
            taxIncome = double.Parse(Console.ReadLine());

            if (taxIncome >= 100000)
            {
                amountOver = taxIncome - 100000;
                taxDue = 6000 + (amountOver * MaxTax);
            }
            else if (taxIncome >= 50000)
            {
                amountOver = taxIncome - 50000;
                taxDue = 2500 + (amountOver * MedTax);
            }
            else
            {
                taxDue = taxIncome * MinTax;
            }

            Console.WriteLine("Your income tax due is {0}", taxDue);

            Console.ReadLine();
        }
    }
}
