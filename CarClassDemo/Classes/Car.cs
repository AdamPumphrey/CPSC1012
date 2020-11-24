using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
   +---------------------------------------------------------------------------------------------+
   | Car                                                                                         |
   +---------------------------------------------------------------------------------------------+
   | - make : String                                                                             |
   | - model : String                                                                            |
   | + Make : String                                                                             |
   | + Model : String                                                                            |
   | + Engine : EngineType                                                                       |
   | + Transmission : TransmissionType                                                           |
   +---------------------------------------------------------------------------------------------+
   | + Car (Make : String, Model : String, Engine : EngineType, Transmission : TransmissionType) |
   | + ToString() : String                                                                       |
   +---------------------------------------------------------------------------------------------+
 */
namespace CarClassDemo.Classes
{
    public class Car
    {
        //private field(s)
        private string _make;
        private string _model;

        //public accessor(s) amd mutator(s)
        public string Make
        {
            get { return _make; }
            set
            {
                if (value.Length >= 2)
                {
                    _make = value;
                }
                else
                {
                    throw new Exception("Invalid Car Make");
                }
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (value.Length >= 2)
                {
                    _model = value;
                }
                else
                {
                    throw new Exception("Invalid Car Model");
                }
            }
        }

        public EngineType Engine { get; set; }
        public TransmissionType Transmission { get; set; }

        //constructor(s)
        public Car(string make, string model, EngineType engine, TransmissionType transmission)
        {
            Make = make;
            Model = model;
            Engine = engine;
            Transmission = transmission;
        }

        //class method(s)
        public override string ToString()
        {
            return string.Format("{0} {1}\n{2}\n{3}", Make, Model, Engine, Transmission);
        }//end of ToString

    }//eoc
}//eon
