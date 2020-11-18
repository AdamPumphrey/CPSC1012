using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Create a program that will allow an instructor to enter the quiz marks for a class
Input:          total, weight, name, mark
Output:         total, weight, name, mark, mark percentage, average mark, average percantage
Written By:     Adam Pumphrey
Last Modified:  Nov. 18, 2020
*/

namespace ObjectPracticeProblem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int total,
                weight,
                mark;

            double sum = 0,
                   avgPercent,
                   avg;

            string name;

            bool isValid = false;

            List<Quiz> quizzes = new List<Quiz>();

            Console.WriteLine("Worksheet 11");
            total = GetSafeInt("Enter Quiz Total: ");
            weight = GetSafeInt("Enter Quiz Weight: ");
            Console.WriteLine();

            do
            {
                name = GetSafeString("Enter student's name (zzz to quit): ");
                if (name.ToLower().Equals("zzz"))
                {
                    isValid = true;
                }
                else
                {
                    mark = GetSafeInt("Enter student's mark: ");
                    sum += mark;
                    Quiz quiz = new Quiz(mark, total, weight, name);
                    quizzes.Add(quiz);
                }
            } while (!isValid);

            Console.WriteLine("\nClass Marks");
            Console.WriteLine("Quiz Total: {0}\tQuiz Weight: {1}", total, weight);
            Console.WriteLine("Name\tMark\t%");
            foreach (Quiz item in quizzes)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.StudentName, item.Mark, item.GetPercentage());
            }

            avg = sum / quizzes.Count();

            avgPercent = (avg / total) * 100;

            Console.WriteLine("\nClass Average: {0:0.00} = {1:0.00}%", avg, avgPercent);

            Console.ReadLine();
        }

        static int GetSafeInt(string prompt)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    // validate int input
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        static string GetSafeString(string prompt)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
                if (name.Length > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);
            return name;
        }
    }
}
