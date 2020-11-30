using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_AdvPortfolio_AdamPumphrey.Classes
{
    class Invoice
    {
        /*
         * auto-properties allow for default values
         * no need for logic in sets - everything handled outside of class (switches and/or input validation)
         * private variables not needed, compiler handles it
        */
        public string Name
        {
            get; set;
        } = "";

        public string Brand
        {
            get; set;
        } = "Trek";

        public int Tire
        {
            get; set;
        } = 20;

        public double Metal
        {
            get; set;
        } = 0;

        public double Donation
        {
            get; set;
        } = 0;

        // no need for constructor

        public override string ToString()
        {
            return string.Format("{0,-25} {1,-13} {2,-9} {3,-10:0.00} {4,8:0.00}", Name, Brand, Tire, Metal, Donation);
        }
    }
}
