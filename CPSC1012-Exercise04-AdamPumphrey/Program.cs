using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
Purpose:            Design and implement a 'fool-proof' menu-driven checkbook-balancing program
Input:              input, desposit, withdrawal
Output:             balance, deposit, withdrawal, interestValue
Written By:         Adam Pumphrey
Last Modified:      Oct 16, 2020
*/

namespace CPSC1012_Exercise04_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Exercise 4";
            Console.Clear();

            const double Interest = 0.0125;

            double balance = 0,
                   deposit = 0,
                   withdrawal = 0,
                   interestValue;

            int input = 0;

            string depositCheck,
                   withdrawCheck;

            bool menuIsValid = false,
                 running = true,
                 depositIsValid = false,
                 withdrawalIsValid = false,
                 depositStringCheck = false,
                 withdrawStringCheck = false;

            do
            {
                do
                {
                    // display menu
                    Console.WriteLine();
                    Console.WriteLine("\t1. Display Balance");
                    Console.WriteLine("\t2. Deposit");
                    Console.WriteLine("\t3. Withdrawal");
                    Console.WriteLine("\t4. Add interest (1.25% interest on current balance)");
                    Console.WriteLine("\t5. Quit");
                    Console.Write("\nSelect your menu option (1-5): ");
                    
                    // validate input
                    try
                    {
                        input = int.Parse(Console.ReadLine());

                        // check input range
                        if ((input > 0) && (input < 6))
                        {
                            menuIsValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Try again");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nInvalid input. Try again");
                    }
                } while (!menuIsValid);

                // reset menu input validation
                menuIsValid = false;

                switch (input)
                {
                    // option 1
                    case 1:
                        // display balance
                        Console.WriteLine("\nYou selected 1. Display balance");
                        Console.WriteLine("Your current balance is: {0:c}", balance);
                        break;

                    case 2:
                        // option 2
                        Console.WriteLine("\nYou selected 2. Deposit");
                        do
                        {
                            Console.Write("Enter how much you want to deposit: ");
                            // input validation
                            try
                            {
                                /* 
                                   I read the input as a string to check for over 2 decimal places.
                                   Since currency cannot have more than 2 decimal places ($35.555),
                                   I treat it as invalid input.
                                */
                                depositCheck = Console.ReadLine();

                                // check if decimal within input
                                if (depositCheck.Contains('.'))
                                {
                                    string[] depositSplit = depositCheck.Split('.');

                                    // check how many decimal places within input
                                    if (depositSplit[1].Length <= 2)
                                    {
                                        // valid currency input -> parse to double
                                        deposit = double.Parse(depositCheck);
                                        depositStringCheck = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input. Try again");
                                    }
                                }
                                // if no decimal found in input
                                else
                                {
                                    deposit = double.Parse(depositCheck);
                                    depositStringCheck = true;
                                }

                                // if decimal check passed
                                if (depositStringCheck)
                                {
                                    // reset decimal check boolean
                                    depositStringCheck = false;

                                    // check for negative deposit value
                                    if (deposit >= 0)
                                    {
                                        depositIsValid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input. Try again");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nInvalid input. Try again");
                            }
                        } while (!depositIsValid);

                        // reset input validation boolean
                        depositIsValid = false;

                        // display deposit and updated balance
                        balance += deposit;
                        Console.WriteLine("\nYou deposited {0:c}", deposit);
                        Console.WriteLine("Your current balance is now: {0:c}", balance);
                        break;

                    case 3:
                        // option 3
                        Console.WriteLine("\nYou selected 3. Withdrawal");
                        do
                        {
                            // input validation
                            Console.Write("Enter how much you want to withdraw: ");
                            try
                            {
                                // Same as deposit - checking for improper number of decimal places
                                withdrawCheck = Console.ReadLine();

                                if (withdrawCheck.Contains('.'))
                                {
                                    string[] withdrawSplit = withdrawCheck.Split('.');

                                    if (withdrawSplit[1].Length <= 2)
                                    {
                                        withdrawal = double.Parse(withdrawCheck);
                                        withdrawStringCheck = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input. Try again");
                                    }
                                }
                                else
                                {
                                    withdrawal = double.Parse(withdrawCheck);
                                    withdrawStringCheck = true;
                                }

                                // if decimal check passed
                                if (withdrawStringCheck)
                                {
                                    withdrawStringCheck = false;

                                    // check for negative withdrawal value
                                    if (withdrawal >= 0)
                                    {
                                        withdrawalIsValid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input. Try again");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nInvalid input. Try again");
                            }
                        } while (!withdrawalIsValid);

                        // reset input validation boolean
                        withdrawalIsValid = false;

                        // display withdrawal and updated balance
                        balance -= withdrawal;
                        Console.WriteLine("\nYou withdrew {0:c}", withdrawal);
                        Console.WriteLine("Your current balance is: {0:c}", balance);
                        break;

                    case 4:
                        // option 4
                        Console.WriteLine("\nYou selected 4. Add interest");

                        // check for positive balance - can't add interest to negative balance
                        if (balance >= 0)
                        {
                            // display interest rate, value of interest from balance, and updated balance
                            Console.WriteLine("Current interest rate is: {0}%", Interest * 100);
                            interestValue = balance * Interest;
                            balance += interestValue;
                            Console.WriteLine("\nInterest total is: {0:c}", interestValue);
                            Console.WriteLine("Your current balance is now: {0:c}", balance);
                        }
                        else
                        {
                            Console.WriteLine("Cannot add interest to a negative balance");
                        }
                        break;

                    default:
                        // option 5 - quit application
                        Console.WriteLine("\nYou selected 5. Quit");
                        Console.WriteLine("Qutting application...");
                        // changing to false tells program to exit do-while loop and terminate
                        running = false;
                        break;
                }
            } while (running);

            // keep console open
            Console.ReadLine();
        }
    }
}
