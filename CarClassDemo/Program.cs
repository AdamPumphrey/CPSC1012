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
            //1. Set up a try-catch
            try
            {
                Car myCar = CreateCar();
                Console.WriteLine("\nCar Created");
                Console.WriteLine(myCar);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }//eom

        #region Your Methods Go Here
        static Car CreateCar()
        {
            //1. setup local scope variables
            string make,
                   model;

            double size;

            int cylinders,
                horsepower,
                gears;

            EngineType engine;
            TransmissionType transmission;
            TransmissionType.TypeName type;
            //2. use the GetSafeString for make and model
            make = GetSafeString("Enter the make of the car: ");
            model = GetSafeString("Enter the model of the car: ");

            //3. get values for engine
            size = GetSafeDouble("Enter the size of the engine in L: ");
            cylinders = GetSafeInt("Enter the number of cylinders in the engine: ");
            horsepower = GetSafeInt("Enter the engine's horsepower: ");

            //4. get values for transmission
            gears = GetSafeInt("Enter the number of gears in the transmission: ");
            int option = GetTransmissionType();
            switch (option)
            {
                case 1:
                    type = TransmissionType.TypeName.Automatic;
                    break;

                case 2:
                    type = TransmissionType.TypeName.Manual;
                    break;

                default:
                    type = TransmissionType.TypeName.CVT;
                    break;
            }

            //5. create the car
            engine = new EngineType(size, horsepower, cylinders);
            transmission = new TransmissionType(gears, type);
            Car myCar = new Car(make, model, engine, transmission);
            return myCar;
        }//end of Createcar

        static int GetTransmissionType()
        {
            //1. setup some local scope variables
            int option,
                enumCount;

            bool isValid = false;

            //2. do loop
            do
            {
                enumCount = 0;
                //3. create a menu from the enum values
                foreach (TransmissionType.TypeName type in Enum.GetValues(typeof(TransmissionType.TypeName)))
                {
                    enumCount++;
                    Console.WriteLine("\t{0}. {1}", enumCount, type);
                }

                //4. get the option using GetSafeInt
                option = GetSafeInt("Option: ");
                if (option >= 1 && option <= enumCount)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            } while (!isValid);
            return option;
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
