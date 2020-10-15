using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add the following namespace for reading/writing from/to a file
using System.IO;


/* 
Purpose:		Demo reading from a comma separated values file 
Input:			file to read from	
Output:			formatted contents of the file 
Written By: 	
Last Modified:	
*/

namespace FileReadDemo_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "File Read Demo - Simple File";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            //constant for filename and path
            const string PathAndFile = @"D:\filereaddemos\StudentClassData.csv";
            
            //variables
            string input,
                studentID,
                lastname,
                firstname;
            int grade,
                count = 0; // to count students


            //1. Test if the file exists
            if (File.Exists(PathAndFile))
            {
                //2. Set up the StreamReader
                StreamReader reader = null;
                
                //3. File exists, thus use a try-catch to read and display the file contents
                try
                {
                    //4. Open the file for reading
                    reader = File.OpenText(PathAndFile);
                    

                    //5. display the column headers
                    Console.WriteLine("ID                 Firstname          Lastname          Grade");
                    Console.WriteLine("==========         =========          ========          =====");

                    //6. Use a "while" loop to loop through the file
                    while ((input = reader.ReadLine()) != null)
                    {
                        //7. Split the line of the file based on finding the comma(s) in the line
                        string[] parts = input.Split(',');
                        studentID = parts[0];
                        lastname = parts[1];
                        firstname = parts[2];
                        grade = int.Parse(parts[3]);
                        Console.WriteLine("{0,-19}{1,-19}{2,-19}{3}", studentID, lastname, firstname, grade);
                        count++;
                        
                    }//end while
                    Console.WriteLine("\nThere are {0} students", count);
                    
                }
                catch (Exception ex)
                {
                    //8. Display any File I/O exception messages
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //9. Close the StreamReader
                    reader.Close();
                }
            }
            else
            {
                //10. File does not exist so display an error message
                Console.WriteLine("File does not exist.");
                
            }//end if-else

            Console.ReadLine();
        }//eom
    }//eoc
}//eon
