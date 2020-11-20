using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdvancedFileIOProblem.Classes;

namespace AdvancedFileIOProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mark> marks = new List<Mark>();

            LoadFromFile(marks);

            Console.WriteLine("\n {0} {1,10} {2,10} {3,10} {4,10} {5,10}", "StudentID", "Quiz", "Midterm", "Lab", "Final", "Grade");
            foreach (Mark item in marks)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
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

        static void LoadFromFile(List<Mark> marks)
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
                        // check to make sure each line has 5 pieces of data - avoid out of range errors
                        if (items.Length != 5)
                        {
                            /* 
                               throws exception to jump to catch so method can restart - not sure if best/good practice,
                               or what the 'proper' way of doing this is 
                            */
                            throw new InvalidOperationException("File must contain exactly 5 items of data per line");
                        }
                        marks.Add(new Mark(items[0], int.Parse(items[1]), int.Parse(items[2]), int.Parse(items[3]), int.Parse(items[4])));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! See message below:");
                    Console.WriteLine(ex.Message);
                    // restart method on error
                    LoadFromFile(marks);
                    // exit method
                    return;
                }

                reader.Close();

                Console.WriteLine("Process complete.");
            }
            else
            {
                Console.WriteLine("File does not exist. Try again.");
                LoadFromFile(marks);
            }

        }

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
    }
}
