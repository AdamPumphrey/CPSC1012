using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    +-----------------------------------------------+
    | ContactInfo                                   |
    +-----------------------------------------------+
    | - email : String                              |
    | - phone : String                              |
    | + Email : String                              |
    | + Phone : String                              |
    +-----------------------------------------------+
    | + ContactInfo(Email : String, Phone : String) |
    | + ToString() : String                         |
    +-----------------------------------------------+
 */

namespace InheritanceDemo.Classes
{
    public class ContactInfo
    {
        string _email;

        string _phone;

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 0)
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Email must be at least 1 character");
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value.Length > 0)
                {
                    _phone = value;
                }
                else
                {
                    throw new Exception("Phone must be at least 1 character");
                }
            }
        }

        public ContactInfo(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return string.Format("Email: {0}, Phone: {1}", Email, Phone);
        }
    }//eoc
}//eon
