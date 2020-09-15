using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Calculate number of calories based on number of cookies eaten
Input:          cookies
Output:         calories
Written By:     Adam Pumphrey
Last Modified:  Sept. 15, 2020
*/

namespace CookieCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            const double CookiesPerServing = 2.6, 
                         ServingCalories = 175;

            double cookies,
                   calories,
                   caloriesPerCookie;

            caloriesPerCookie = ServingCalories / CookiesPerServing;

            Console.Write("Enter number of cookies eaten: ");
            cookies = double.Parse(Console.ReadLine());

            calories = cookies * caloriesPerCookie;

            Console.WriteLine("Total calories consumed: {0:0.00}", calories);

            Console.ReadLine();
        }
    }
}
