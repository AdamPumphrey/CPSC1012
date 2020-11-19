using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
                +-----------------------------------------------------------------------------------+
                | Student                                                                           |
                +-----------------------------------------------------------------------------------+
                | - firstName: String                                                               |
                | - lastName: String                                                                |
                | - studentID: String                                                               |
                | - grade: Integer                                                                  |
                | + FirstName: String                                                               |
                | + LastName: String                                                                |
                | + StudentID: String                                                               |
                | + Grade: Integer                                                                  |
                +-----------------------------------------------------------------------------------+
                | + Student(FirstName: String, LastName: String, StudentID: String, Grade: Integer) |
                | + ToString() : String                                                             |
                +-----------------------------------------------------------------------------------+
*/
namespace ObjectDemo3.Classes
{
    public class Student
    {
        // private member fields
        private string _firstName;
        private string _lastName;
        private string _studentID;
        private int _grade;

        // public accessors and mutators
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length >= 2)
                {
                    _firstName = value;
                }
                else
                {
                    throw new Exception("First name is too short");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length >= 2)
                {
                    _lastName = value;
                }
                else
                {
                    throw new Exception("Last name is too short");
                }
            }
        }

        public string StudentID
        {
            get { return _studentID; }
            set
            {
                if (value.Length >= 4)
                {
                    _studentID = value;
                }
                else
                {
                    throw new Exception("Invalid Student ID");
                }
            }
        }

        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _grade = value;
                }
                else
                {
                    throw new Exception("Invalid Grade");
                }
            }
        }

        // constructor
        public Student(string firstName, string lastName, string studentID, int grade)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentID = studentID;
            Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-15} {2,-15} {3,3}", StudentID, LastName, FirstName, Grade);
        }
    }
}
