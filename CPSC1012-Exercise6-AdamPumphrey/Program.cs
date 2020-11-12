using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
Purpose:        A program that reads student marks, determines the highest mark, and then assigns grades
Input:          student's names and marks
Output:         student's names, marks, and corresponding grade
Written By:     Adam Pumphrey
Last Modified:  November 11, 2020
*/

namespace CPSC1012_Exercise6_AdamPumphrey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Exercise #6";

            char fileLoad,
                 proceed;

            int size;

            string[] names;
            int[] marks;

            fileLoad = GetSafeChar("Do you want to load data from a file? Enter Y to load from file, enter N to fill manually: ");

            if (fileLoad == 'Y')
            {
                // create lists since we don't know how many items are in the file being imported
                List<string> fileNames = new List<string>();
                List<int> fileMarks = new List<int>();

                LoadFromFile(fileNames, fileMarks);

                // change lists to arrays
                names = fileNames.ToArray();
                marks = fileMarks.ToArray();
            }
            else
            {
                size = GetSafeInt("Enter the number of students to grade: ");

                names = new string[size];
                marks = new int[size];

                // manually fill arrays
                FillArrays(names, marks, size);
            }

            ShowGrades(names, marks, marks.Length);

            proceed = GetSafeChar("Do you want to save the names and marks to a CSV file? Enter Y to continue, or N to exit: ");

            if (proceed == 'Y')
            {
                WriteToFile(names, marks);
            }

            Console.ReadLine();
        }

        static void FillArrays(string[] names, int[] marks, int size)
        {
            for (int index = 0; index < size; index++)
            {
                names[index] = GetSafeString("Enter the name for student #" + (index + 1).ToString() + ": ");
                marks[index] = GetSafeInt("Enter the mark for student #" + (index + 1).ToString() + ": ");
            }
        }

        static int GetMax(int[] marks)
        {
            // sort array using quicksort
            SortArray(marks, 0, marks.Length - 1);

            return marks[marks.Length - 1];
        }

        static char GetGrade(int highestMark, int studentMark)
        {
            // experimenting with pattern matching in switch
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch#the-case-statement-and-the-when-clause
            // https://visualstudiomagazine.com/articles/2017/02/01/pattern-matching.aspx
            switch (studentMark)
            {
                case int mark when mark >= highestMark - 10:
                    return 'A';

                case int mark when mark >= highestMark - 20:
                    return 'B';

                case int mark when mark >= highestMark - 30:
                    return 'C';

                case int mark when mark >= highestMark - 40:
                    return 'D';

                default:
                    return 'F';
            }
        }

        static void ShowGrades(string[] names, int[] marks, int size)
        {
            char grade;
            int[] maxMarks = new int[size];
            int maxMark;

            // clone marks array to sort for highest mark without changing order of students because parallel arrays
            marks.CopyTo(maxMarks, 0);

            // sort array and get highest mark
            maxMark = GetMax(maxMarks);

            for (int i = 0; i < size; i++)
            {
                // assign grades based on highest mark
                grade = GetGrade(maxMark, marks[i]);
                Console.WriteLine("{0}'s mark is {1} and grade is {2}", names[i], marks[i], grade);
            }
        }

        static void SortArray(int[] marks, int start, int end)
        {
            int temp,
                first = start,
                last = end;

            // if partition size is 2
            if (end - start == 1)
            {
                // simple compare
                if (marks[start] > marks[end])
                {
                    temp = marks[end];
                    marks[end] = marks[start];
                    marks[start] = temp;
                }
                start++;
                end--;
            }
            // if partition size is greater than 2
            else if (end - start > 1)
            {
                // get pivot - approx. middle point of partition
                // uses actual partition size (+ 1 accomplishes this) to calculate middle point, then - 1 to move it back to proper index
                int pivot = marks[start + (((int)Math.Ceiling((end - start + 1) / 2.0)) - 1)];
                // quicksort
                while (start <= end)
                {
                    // move pointer until value > pivot
                    while (marks[start] < pivot && start <= end)
                    {
                        start++;
                    }

                    // move pointer until value < pivot
                    while (marks[end] > pivot && start <= end)
                    {
                        end--;
                    }

                    if (marks[start] > marks[end] && start <= end)
                    {
                        // swap values in both arrays (parallel)
                        temp = marks[end];
                        marks[end] = marks[start];
                        marks[start] = temp;

                        start++;
                        end--;
                    }
                    // no swap needed if two values are the same
                    else if (marks[start] == marks[end] && start <= end)
                    {
                        start++;
                        end--;
                    }
                }
            }

            // if left partition will be more than 1 item
            if (first < end)
            {
                // left partition
                SortArray(marks, first, end);
            }

            // if right partition will be more than 1 item
            if (start < last)
            {
                // right partition
                SortArray(marks, start, last);
            }
            
        }

        // optional challenge 1
        static void WriteToFile(string[] names, int[] marks)
        {
            string output;

            // ensure that a .csv file is being used/created
            string filepath = VerifyFile();
            
            StreamWriter writer;

            try
            {
                if (File.Exists(filepath))
                {
                    writer = File.AppendText(filepath);
                }
                else
                {
                    writer = File.CreateText(filepath);
                }

                for (int i = 0; i < names.Length; i++)
                {
                    output = names[i] + ',' + marks[i];
                    writer.WriteLine(output);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! See message below:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Restarting filewrite process");
                // call function again so user doesn't have to restart entire program because of a typo
                WriteToFile(names, marks);
                // exit method
                return;
            }
            
            writer.Close();

            Console.WriteLine("Process complete.");
        }

        static string VerifyFile()
        {
            bool isValid = false;
            string filepath;

            // ensure that a .csv file is being used/created
            do
            {
                filepath = GetSafeString("Enter the file path eg) drive: slash folder slash file.csv: ", true);
                if (filepath.Length >= 4)
                {
                    string extension = filepath.Substring(filepath.Length - 4);
                    if (!extension.Equals(".csv"))
                    {
                        Console.WriteLine("Invalid file type. Please enter a valid file path for a .csv file");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid file path. Try again");
                }

            } while (!isValid);

            return filepath;
        }

        // optional challenge 2
        static void LoadFromFile(List<string> fileNames, List<int> fileMarks)
        {
            // ensure that a .csv file is being used
            string input,
                   filepath = VerifyFile();

            if (File.Exists(filepath))
            {
                StreamReader reader;

                try
                {
                    reader = File.OpenText(filepath);

                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] items = input.Split(',');
                        // check to make sure each line has 2 pieces of data - avoid out of range errors
                        if (items.Length != 2)
                        {
                            /* 
                               throws exception to jump to catch so method can restart - not sure if best/good practice,
                               or what the 'proper' way of doing this is 
                            */
                            throw new InvalidOperationException("File must contain exactly 2 items of data per line");
                        }
                        fileNames.Add(items[0]);
                        fileMarks.Add(int.Parse(items[1]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! See message below:");
                    Console.WriteLine(ex.Message);
                    // restart method on error
                    LoadFromFile(fileNames, fileMarks);
                    // exit method
                    return;
                }

                reader.Close();

                Console.WriteLine("Process complete.");
            }
            else
            {
                Console.WriteLine("File does not exist. Try again.");
                LoadFromFile(fileNames, fileMarks);
            }

        }

        #region Input Validation Methods
        // from previous assignments
        static int GetSafeInt(string prompt)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    // validate int input
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return number;
        }

        // from previous assignments
        static string GetSafeString(string prompt, bool file = false)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                if (!file)
                {
                    name = Console.ReadLine();
                }
                else
                {
                    name = @"" + Console.ReadLine();
                }
                if (name.Length > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);
            return name;
        }

        // from previous assignments
        static char GetSafeChar(string prompt)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                // validate char input
                try
                {
                    Console.Write(prompt);
                    character = char.Parse(Console.ReadLine().ToUpper());
                    if (character == 'Y' || character == 'N')
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            // return valid char input
            return character;
        }
        #endregion
    }
}
