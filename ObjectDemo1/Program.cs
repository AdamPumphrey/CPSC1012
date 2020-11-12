using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Purpose:		Demonstrate the creation and use of a simple class	 
Input:			Die class
				+-----------------------+
				|          Die          |
				+-----------------------+
				| - sides: Integer      |
				| - faceValue: Integer  |
				| + Sides: Integer      |
				| + FaceValue: Integer  |
				+-----------------------+
				| + Die()               |
				| + Die(Sides: Integer) |
				| + Roll()              |
				+-----------------------+
				
Output:			values of the instances of the Die class 
Written By: 	 
Last Modified:	 
*/

namespace DieClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            //Create and display a default instance of the class
            Die sixSidedDie = new Die();
            Console.WriteLine("Sides = {0}, FaceValue = {1}", sixSidedDie.Sides, sixSidedDie.FaceValue);

            //Display the instance of the class using a class method


            //Create and display a non-default instance of the class
            Die someDie = new Die(20);
            Console.WriteLine("Sides = {0}, FaceValue = {1}", someDie.Sides, someDie.FaceValue);

            //Change the values(s) of the instances of the class
            sixSidedDie.Roll();
            someDie.Roll();
            Console.WriteLine("Sides = {0}, FaceValue = {1}", sixSidedDie.Sides, sixSidedDie.FaceValue);
            Console.WriteLine("Sides = {0}, FaceValue = {1}", someDie.Sides, someDie.FaceValue);

            //Exceptions
            try
            {
                sixSidedDie.FaceValue = 7;
                someDie.Sides = 1;
            }
            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ReadLine();
        }//eom

        #region Provided methods
        static void Setup()
        {
            Console.Title = "Die Class Demo";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup
        #endregion
    }//eoc
}//eon
