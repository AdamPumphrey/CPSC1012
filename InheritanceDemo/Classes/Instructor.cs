using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

    +-----------------------------------------------------------------------------------------------+
    | Instructor                                                                                    |
    +-----------------------------------------------------------------------------------------------+
    | - officeNumber : String                                                                       |   
    | + OfficeNumber : String                                                                       |
    +-----------------------------------------------------------------------------------------------+
    | + Instructor(IDNumber : Integer, LastName: String, FirstName : String, Contact : ContactInfo, |
    |              OfficeNumber : String)                                                           |
    | + ToString() : String                                                                         |
    +-----------------------------------------------------------------------------------------------+
 */

namespace InheritanceDemo.Classes
{
    public class Instructor : Person
    {
        private string _officenumber;

        public string OfficeNumber
        {
            get { return _officenumber; }
            set
            {
                if (value.Length > 0)
                {
                    _officenumber = value;
                }
                else
                {
                    throw new Exception("OfficeNumber must be at least 1 character");
                }
            }
        }

        public Instructor(int idnumber, string lastname, string firstname, ContactInfo contact, string officenumber) : base(idnumber, lastname, firstname, contact)
        {
            OfficeNumber = officenumber;
        }

        public override string ToString()
        {
            return string.Format("IDNumber: {0}, Last Name: {1}, First Name: {2}, Contact: {3}, Office Number: {4}", IDNumber, LastName, FirstName, Contact, OfficeNumber);
        }
    }//eoc
}//eon
