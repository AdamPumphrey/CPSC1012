using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    +---------------------------------------------------------------------------------------------+
    | TransmissionType                                                                            |
    +---------------------------------------------------------------------------------------------+
    | - gears : Integer                                                                           |
    | + Gears : Integer                                                                           |
    | + Type : TypeName                                                                           |
    +---------------------------------------------------------------------------------------------+
    | + TransmissionType (Gears : Integer, Type : TypeName)                                       |
    | + ToString() : String                                                                       |
    +---------------------------------------------------------------------------------------------+
 */
namespace CarClassDemo.Classes
{
    public class TransmissionType
    {
        //public enumeration for the type of transmission
        public enum TypeName
        {
            Automatic,
            Manual,
            CVT
        }
        //private field(s)
        private int _gears;

        //public accessor(s) amd mutator(s)
        public int Gears
        {
            get { return _gears; }
            set
            {
                if (value >= 2)
                {
                    _gears = value;
                }
                else
                {
                    throw new Exception("Invalid Transmission Gears");
                }
            }
        }

        public TypeName Type;

        //constructor(s)
        public TransmissionType(int gears, TypeName type)
        {
            Gears = gears;
            Type = type;
        }

        //class method(s)
        public override string ToString()
        {
            return string.Format("{0} speed {1} transmission", Gears, Type);
        }

    }//eoc
}//eon
