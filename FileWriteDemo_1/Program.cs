using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Required for File I/O
using System.IO;

/* 
Purpose:		Demonstrate how to create a simple text file with comma separated values
                1) If the file does not exist, create it, or
                2) If is does exist, append data to the file
Input:			firstname, lastname, grade
Output:			the file of names 
Written By: 	
Last Modified:	 
*/

namespace FileWriteDemo_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "File Write Demo 1";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            //constants
            const string PathAndFile = @"D:\filereaddemos\StudentList.csv";
           
            //const int MinimumGrade = 0,
            //    MaximumGrade = 100;// these will be needed for the grade validation

            //variables
            string firstname,
                lastname,
                output,
                input;
            int grade,
                count = 0;
            char addAnother;

            do
            {
                //1. Enter student's information
                Console.Write("Enter firstname: ");
                firstname = Console.ReadLine();
                Console.Write(" Enter lastname: ");
                lastname = Console.ReadLine();
                Console.Write("Enter grade: ");
                grade = int.Parse(Console.ReadLine()); //proper validation needs to be performed on this input

                //2. Create output
                output = lastname + "," + firstname + "," + grade;

                //3. Initiate the StreamWriter
                StreamWriter writer = null;
                
                //4. Set up the try-catch-finally
                try
                {
                    //5. Check if the file exists
                    if (File.Exists(PathAndFile))
                    {
                        //5(a). Append to the existing file
                        writer = File.AppendText(PathAndFile);
                    }
                    else
                    {
                        //5(b). Create the file
                        writer = File.CreateText(PathAndFile);
                    }
                    //5(c). Write to the file
                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    writer.Close();
                }

                //6. Prompt to add another student record
                Console.Write("Add another (Y): ");
                addAnother = char.Parse(Console.ReadLine().ToUpper()); //proper validation needs to be performed on this input

            } while (addAnother == 'Y'); //end do-while

            //7. Read & display the contents of the file you just created
            if (File.Exists(PathAndFile))
            {
                //7(a). File exists, thus use a try-catch-finally to read and display the file contents
                StreamReader reader = null;
                try
                {
                    //7(b). Open the file for reading
                    reader = File.OpenText(PathAndFile);

                    //7(c). display the column headers
                    Console.WriteLine("Firstname           Lastname            Grade");
                    Console.WriteLine("=========           ========            =====");
                    //7(d). Use a "while" loop to loop through the file
                    while ((input = reader.ReadLine()) != null)
                    {
                        //7(e). Split the line of the file based on finding the comma(s) in the line
                        string[] parts = input.Split(',');
                        count++;
                        lastname = parts[0];
                        firstname = parts[1];
                        grade = int.Parse(parts[2]);
                        Console.WriteLine("{0, -20}{1,-20}{2}", lastname, firstname, grade);
                    }//end while
                    Console.WriteLine("\nThere are {0} students in this list", count);
                    
                }
                catch (Exception ex)
                {
                    //7(f). Display any File I/O exception messages
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //7(g). Close the StreamReader
                    reader.Close();
                   
                }//end try-catch-finally
            }
            else
            {
                //File does not exist so display an error message
                Console.WriteLine("The file {0} does not exist", PathAndFile);
            }//end if-else

            //keep the console window open
            Console.ReadLine();
        }//eom
    }//eoc
}//eon
