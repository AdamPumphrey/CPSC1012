using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceDemo.Classes;

/* 
Purpose:		This demonstrates Object inheritance	 
Input:			data for each of the classes	
Output:			data from each of the classes 
Written By: 	Adam Pumphrey
Last Modified:	 Nov. 26, 2020
*/

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            List<Person> people = new List<Person>();


            Console.ReadLine();
        }//eom

        static void LoadPersons(List<Person> people)
        {

        }//end of LoadPersons

        static void DisplayPersons(List<Person> people)
        {

        }//end of DisplayPersons

        static void DisplayStudents(List<Person> people)
        {

        }//end of DisplayStudents

        static void Displayinstructors(List<Person> people)
        {

        }//end of Displayinstructors

        static void Setup()
        {
            Console.Title = "Inheritance Demo";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        #region Methods You Can Add

        #endregion
    }//eoc
}//eon
