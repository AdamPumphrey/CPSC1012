using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Create Quiz class
Input:          None in this file, but would be at least mark, total, weight, studentName
Output:         None in this file, but would be mark percentage
Written By:     Adam Pumphrey
Last Modified:  Nov. 13, 2020
*/

namespace ObjectPracticeProblem2
{
    public class Quiz
    {
        private string _studentName;
        private int _total,
                    _mark,
                    _weight;

        public string StudentName
        {
            get { return _studentName; }
            set
            {
                if (value.Length >= 1)
                {
                    _studentName = value;
                }
                else
                {
                    throw new Exception("Name must be at least 1 character");
                }
            }
        }

        public int Total
        {
            get { return _total; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _total = value;
                }
                else
                {
                    throw new Exception("Total must be at least 0 and at most 100");
                }
            }
        }

        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value >= 0 && value <= Total)
                {
                    _mark = value;
                }
                else
                {
                    throw new Exception("Mark must be at least 0 and at most the same as the total");
                }
            }
        }

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value >= 0)
                {
                    _weight = value;
                }
                else
                {
                    throw new Exception("Weight must be at least 0");
                }
            }
        }

        public Quiz(int mark, int total, int weight, string studentName)
        {
            // total set first so that mark has a maximum value
            Total = total;
            Mark = mark;
            Weight = weight;
            StudentName = studentName;
        }

        public double GetPercentage()
        {
            return ((double)Mark / Total) * 100;
        }
    }
}
