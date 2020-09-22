using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:        Calculate the total sale, including GST (5%) from the inputted price and
                quantity purchased. Use the following table to determine the discount rate
                Quantity Purchased  Discount Rate
                    7 or more           10%
                    4-6                 5%
                    2-3                 2%
                    1                   0%
Input:          price, quantity
Output:         totalSale, subtotal, discount, subtotalAfterDiscount, tax
Written By:     Adam Pumphrey 
Last Modified:  Sept 22, 2020
*/

namespace DiscountRate
{
    class Program
    {
        static void Main(string[] args)
        {
            const double GST = 0.05;

            int quantity;

            double price,
                   totalSale,
                   subtotal,
                   discount,
                   subtotalAfterDiscount,
                   tax;

            Console.Write("Enter the price of the item: ");
            price = double.Parse(Console.ReadLine());

            Console.Write("         Enter the quantity: ");
            quantity = int.Parse(Console.ReadLine());

            if (quantity >= 7)
            {
                discount = 0.10;
            }
            else if (quantity <= 6 && quantity >= 4)
            {
                discount = 0.05;
            }
            else if (quantity == 3 || quantity == 2)
            {
                discount = 0.02;
            }
            else
            {
                discount = 0;
            }

            subtotal = price * quantity;

            discount *= subtotal;
            subtotalAfterDiscount = subtotal - discount;

            tax = GST * subtotalAfterDiscount;

            totalSale = subtotalAfterDiscount + tax;

            Console.WriteLine("\n----- Bill Total -----");
            Console.WriteLine("Subtotal: {0,8:c}", subtotal);
            Console.WriteLine("Discount: {0,8:c}", discount);
            Console.WriteLine("Purchase: {0,8:c}", subtotalAfterDiscount);
            Console.WriteLine("     GST: {0,8:c}", tax);
            Console.WriteLine("   Total: {0,8:c}", totalSale);

            Console.ReadLine();
        }
    }
}
