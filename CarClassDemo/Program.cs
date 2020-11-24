using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarClassDemo.Classes;

/* 
Purpose:		To demonstrate a class with multiple class properties, and using enumerations	
                CarClassDemo.Classes.EngineType.cs
                CarClassDemo.Classes.TransmissionType.cs
                CarClassDemo.Classes.Car.cs
Input:			data to build a car	
Output:			car data 
Written By: 	Adam Pumphrey
Last Modified:	Nov. 24, 2020
*/

namespace CarClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

        }//eom

        #region Your Methods Go Here
        static Car CreateCar()
        {
            return null;
        }//end of Createcar

        static int GetTransmissionType()
        {
            return 0;
        }//end of GetTransmissionType
        #endregion

        #region Provided Methods
        static void Setup()
        {
            Console.Title = "Car Class Demo with Enum";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        static int GetSafeInt(string prompt)
        {
            int number = 1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,20}", prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid number ... try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid number ... try again");
                }
            } while (!isValid);
            return number;
        }//end of getSafeInt

        static double GetSafeDouble(string prompt)
        {
            double number = 1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,20}", prompt);
                    number = double.Parse(Console.ReadLine());
                    if (number >= 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid number ... try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid number ... try again");
                }
            } while (!isValid);
            return number;
        }//end of getSafeDouble

        static string GetSafeString(string prompt)
        {
            string name;
            bool isValid = false;
            do
            {
                Console.Write("{0,20}", prompt);
                name = Console.ReadLine();
                if (name.Length >= 3)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Name is not valid");
                }
            } while (!isValid);
            return name;
        }//end of GetSafeString
        #endregion
    }//eoc
}//eon
