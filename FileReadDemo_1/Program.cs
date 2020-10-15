using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add the following namespace for reading/writing from/to a file
using System.IO;
using System.Diagnostics.PerformanceData;


/* 
Purpose:		Demo reading from a simple file (not comma separated values)	 
Input:			file to read from	
Output:			contents of the file 
Written By: 	
Last Modified:	
*/

namespace FileReadDemo_1
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
            const string PathAndFile = @"D:\filereaddemos\Students.txt";
            
            //variables
            string input,
                name;
            int count = 0; // to count students

            Console.WriteLine("Filename is {0}", PathAndFile);

            //1. Test if the file exists
            if (File.Exists(PathAndFile))
            {
                
                //2. Set up the StreamReader
                StreamReader reader = null;
               
                //3. File exists, thus use a try-catch-finally to read and display the file contents
                try
                {
                    //4. Open the file for reading
                    reader = File.OpenText(PathAndFile);

                    //5. Use a "while" loop to loop through the file
                    while ((input = reader.ReadLine()) != null)
                    {
                        count++;
                        name = input;
                        Console.WriteLine("Student {0}: {1}", count, name);
                    }
                    
                }
                catch (Exception ex)
                {
                    //6. Display any File I/O exception messages
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //7. Close the StreamReader
                    reader.Close();
                }
            }
            else
            {
                //8. File does not exist so display an error message
                Console.WriteLine("Filename {0} does not exist!", PathAndFile);
                
            }//end if-else

            Console.ReadLine();
        }//eom
    }//eoc
}//eon
