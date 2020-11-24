using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    +---------------------------------------------------------------------------------------------+
    | EngineType                                                                                  |
    +---------------------------------------------------------------------------------------------+
    | - size : Double                                                                             |
    | - cylinders : Integer                                                                       |
    | - horsepower : Integer                                                                      |
    | + Size : Double                                                                             |
    | + Cylinders : Integer                                                                       |
    | + Horsepower : Integer                                                                      |
    +---------------------------------------------------------------------------------------------+
    | + EngineType(Size : Double, Cylinders : Integer, Horsepower : Integer)                      |
    | + ToString() : String                                                                       |
    +---------------------------------------------------------------------------------------------+
 */
namespace CarClassDemo.Classes
{
    public class EngineType
    {
        //private field(s)
        private double _size;
        private int _cylinders;
        private int _horsepower;
        //public accessor(s) amd mutator(s)
        public double Size
        {
            get { return _size; }
            set
            {
                if (value >= 1.0)
                {
                    _size = value;
                }
                else
                {
                    throw new Exception("Invalid engine size. Engine must be at least 1L.");
                }
            }
        }

        public int Cylinders
        {
            get { return _cylinders; }
            set
            {
                if (value >= 4 && value <= 12 && value % 2 == 0)
                {
                    _cylinders = value;
                }
                else
                {
                    throw new Exception("Invalid cylinder value. Must be even number between 4 and 12.");
                }
            }
        }

        public int Horsepower
        {
            get { return _horsepower; }
            set
            {
                if (value > 0)
                {
                    _horsepower = value;
                }
                else
                {
                    throw new Exception("Invalid horespower value. Must be greater than 0.");
                }
            }
        }

        //constructor(s)
        public EngineType(double size, int horsepower, int cylinders)
        {
            Size = size;
            Horsepower = horsepower;
            Cylinders = cylinders;
        }

        //class method(s)
        public override string ToString()
        {
            return string.Format("{0} cylinder, {1}L, {2} bhp", Cylinders, Size, Horsepower);
        }
    }//eoc
}//eon