using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFileIOProblem.Classes
{
    public class Mark
    {

        const double QuizWeight = 0.10,
                     MidtermWeight = 0.25,
                     LabWeight = 0.30,
                     FinalWeight = 0.35;

        private string _studentID;
        private int _quiz,
                    _midterm,
                    _lab,
                    _final;

        public string StudentID
        {
            get { return _studentID; }
            set
            {
                if (value.Length == 8)
                {
                    _studentID = value;
                }
                else
                {
                    throw new Exception("Student ID must be 8 characters long");
                }
            }
        }

        public int Quiz
        {
            get { return _quiz; }
            set
            {
                if (value >=0 && value <= 100)
                {
                    _quiz = value;
                }
                else
                {
                    throw new Exception("Quiz mark must be at least 0 and at most 100");
                }
            }
        }

        public int Midterm
        {
            get { return _midterm; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _midterm = value;
                }
                else
                {
                    throw new Exception("Midterm exam mark must be at least 0 and at most 100");
                }
            }
        }

        public int Lab
        {
            get { return _lab; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _lab = value;
                }
                else
                {
                    throw new Exception("Lab mark must be at least 0 and at most 100");
                }
            }
        }

        public int Final
        {
            get { return _final; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _final = value;
                }
                else
                {
                    throw new Exception("Final exam mark must be at least 0 and at most 100");
                }
            }
        }

        public Mark(string studentID, int quiz, int midterm, int lab, int final)
        {
            StudentID = studentID;
            Quiz = quiz;
            Midterm = midterm;
            Lab = lab;
            Final = final;
        }

        public double CalculateGrade()
        {
            return (Quiz * QuizWeight) + (Midterm * MidtermWeight) + (Lab * LabWeight) + (Final * FinalWeight);
        }

        public override string ToString()
        {
            return string.Format("{0,10} {1,10} {2,10} {3,10} {4,10} {5,10:0}", StudentID, Quiz, Midterm, Lab, Final, CalculateGrade());
        }
    }
}
