using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
    +--------------------------------------------------------------------------------------------+
    | Person                                                                                     |
    +--------------------------------------------------------------------------------------------+
    | - idNumber : Integer                                                                       |
    | - lastName : String                                                                        |
    | - firstName : String                                                                       |
    | - contact : ContactInfo                                                                    |
    | + IDNumber : Integer                                                                       |
    | + LastName : String                                                                        |
    | + FirstName : String                                                                       |
    | + Contact : ContactInfo                                                                    |
    +--------------------------------------------------------------------------------------------+
    | + Person(IDNumber : Integer, LastName : String, FirstName : String, Contact : ContactInfo) |
    | + ToString() : String                                                                      |
    +--------------------------------------------------------------------------------------------+

 */

namespace InheritanceDemo.Classes
{
    public class Person
    {
        int _idnumber; 
        string _lastname;
        string _firstname;

        public int IDNumber
        {
            get { return _idnumber; }
            set
            {
                if (value > 0)
                {
                    _idnumber = value;
                }
                else
                {
                    throw new Exception("IDNumber must be at least 1");
                }
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (value.Length > 0)
                {
                    _lastname = value;
                }
                else
                {
                    throw new Exception("Last name must be at least 1 character");
                }
            }
        }

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (value.Length > 0)
                {
                    _firstname = value;
                }
                else
                {
                    throw new Exception("First name must be at least 1 character");
                }
            }
        }

        public ContactInfo Contact { get; set; }

        public Person(int idnumber, string lastname, string firstname, ContactInfo contact)
        {
            IDNumber = idnumber;
            LastName = lastname;
            FirstName = firstname;
            Contact = contact;
        }

        public override string ToString()
        {
            return string.Format("IDNumber: {0}, Last Name: {1}, First Name: {2}, Contact: {3}", IDNumber, LastName, FirstName, Contact);
        }
    }//eoc
}//eon
