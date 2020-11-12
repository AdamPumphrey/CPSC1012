using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieClassDemo
{
    public class Die
    {
        // private member fields
        private int _sides;
        private int _faceValue;

        // public Accessors and Mutators
        public int Sides
        {
            get { return _sides; } // public Accessor
            // public Mutator
            set
            {
                if (value >= 4)
                {
                    _sides = value;
                }
                else
                {
                    throw new Exception("Invalid sides for a Die");
                }
            }
        }

        public int FaceValue
        {
            get { return _faceValue; }
            set
            {
                if (value > 0 && value <= _sides)
                {
                    _faceValue = value;
                }
                else
                {
                    throw new Exception("Invalid face value");
                }
            }
        }

        // Constructor(s)
        // Empty constructor
        public Die()
        {
            Sides = 6;
            FaceValue = 1;
        }

        // Greedy constructor
        public Die(int sides)
        {
            Sides = sides;
            FaceValue = 1;
        }

        // Class method(s)
        public void Roll()
        {
            Random rnd = new Random();
            FaceValue = rnd.Next(1, Sides + 1);
        }

        public override string ToString()
        {
            //return "Sides = " + Sides + ", FaceValue = " + FaceValue;
            return string.Format("Sides = {0}, FaceValue = {1}", Sides, FaceValue);
        }
    }
}
