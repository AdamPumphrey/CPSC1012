using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceDemo.Classes;

/*

    +---------------------------------------------------------------------------------------------+
    | Student                                                                                     |
    +---------------------------------------------------------------------------------------------+
    | - program : String                                                                          |
    | - semester : Integer                                                                        |
    | + Program : String                                                                          |
    | + Semester : Integer                                                                        |
    +---------------------------------------------------------------------------------------------+
    | + Student(IDNumber : Integer, LastName : String, FirstName : String, Contact : ContactInfo, |
    |           Program : String, Semester : Integer)                                             |
    | + ToString() : String                                                                       |
    +---------------------------------------------------------------------------------------------+

 */
namespace InheritanceDemo.Classes
{
    public class Student : Person
    {
        string _program;

        int _semester;

        public string Program
        {
            get { return _program; }
            set
            {
                if (value.Length > 0)
                {
                    _program = value;
                }
                else
                {
                    throw new Exception("Program must be at least 1 character");
                }
            }
        }

        public int Semester
        {
            get { return _semester; }
            set
            {
                if (value > 0)
                {
                    _semester = value;
                }
                else
                {
                    throw new Exception("Semester must be at least 1");
                }
            }
        }

        public Student(int idnumber, string lastname, string firstname, ContactInfo contact, string program, int semester) : base(idnumber, lastname, firstname, contact)
        {
            Program = program;
            Semester = semester;
        }

        public override string ToString()
        {
            return string.Format("IDNumber: {0}, Last Name: {1}, First Name: {2}, Contact: {3}, Program: {4}, Semester: {5}", IDNumber, LastName, FirstName, Contact, Program, Semester);
        }
    }//eoc
}//eon
