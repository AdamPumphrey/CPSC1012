using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Display test scores and average of all scores
Input:          score1, score2, score3
Output:         score1, score2, score3, averageScore
Written By:     Adam Pumphrey
Last Modified:  Sept. 15, 2020
*/

namespace TestScoreAvg
{
    class Program
    {
        static void Main(string[] args)
        {
            double score1,
                   score2,
                   score3,
                   averageScore;

            Console.Write("Enter Test Score 1: ");
            score1 = double.Parse(Console.ReadLine());

            Console.Write("Enter Test Score 2: ");
            score2 = double.Parse(Console.ReadLine());

            Console.Write("Enter Test Score 3: ");
            score3 = double.Parse(Console.ReadLine());

            averageScore = (score1 + score2 + score3) / 3;

            Console.WriteLine();

            Console.WriteLine("Score #1 is {0}", score1);
            Console.WriteLine("Score #2 is {0}", score2);
            Console.WriteLine("Score #3 is {0}", score3);
            Console.WriteLine("The average of the scores is {0:0.0}", averageScore);

            Console.ReadLine();
        }
    }
}
