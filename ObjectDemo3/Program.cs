using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Require additional namespaces
using ObjectDemo3.Classes; // Student class is in a different namespace
using System.IO; // used for file I/O


/* 
Purpose:		Demonstrate the following:
                1. Putting a class in a different namespace and thus requiring a using statement
                    a. Create a new folder called "Classes"
                    b. Add a class definition for the Student.cs as defined below
                2. Load data from a file into a List<T>
                3. Add a new Student to the List<T>
                4. Sorting the List<T> by LastName
                5. Write out the List<T> to a file (overwriting the existing data)
Input:			StudentClassData.csv
                Student.cs
                +-----------------------------------------------------------------------------------+
                | Student                                                                           |
                +-----------------------------------------------------------------------------------+
                | - firstName: String                                                               |
                | - lastName: String                                                                |
                | - studentID: String                                                               |
                | - grade: Integer                                                                  |
                | + FirstName: String                                                               |
                | + LastName: String                                                                |
                | + StudentID: String                                                               |
                | + Grade: Integer                                                                  |
                +-----------------------------------------------------------------------------------+
                | + Student(FirstName: String, LastName: String, StudentID: String, Grade: Integer) |
                | + ToString() : String                                                             |
                +-----------------------------------------------------------------------------------+
Output:			A formatted list of Student instances
                A class average
Written By: 	Allan Anderson 
Last Modified:	 
*/

namespace ObjectDemo3
{
    class Program
    {
        //class constants
        const string PathAndFile = @"D:\testing\StudentClassData.csv"; //update this value to use a path of your choice

        static void Main(string[] args)
        {
            Setup();
            //variables and class instances
            List<Student> students = new List<Student>(); //uncomment once the Student class has been created
            //1. Check if the file exists before proceeding
            if (File.Exists(PathAndFile))
            {
                try
                {
                    //2. Load the List<T> from a file
                    LoadFromFile(students);
                    //3. Display the List<T> data
                    DisplayStudents(students);
                    //4. Add another Student instance to the List<T>
                    AddStudent(students);
                    //5. Sort the List<T> on LastName
                    //students.Sort((student1, student2) => student1.LastName.CompareTo(student2.LastName));
                    students.Sort((student1, student2) => {
                        int compare = string.Compare(student1.LastName, student2.LastName);
                        return compare != 0 ? compare : student1.FirstName.CompareTo(student2.FirstName);
                        });
                    //6. Display the updated List<T>
                    DisplayStudents(students);
                    //7. Write the updated List<T> to a file
                    WriteToFile(students);
                    Console.WriteLine("\nSuccessfully written {0} lines to {1}", students.Count, PathAndFile);
                    //8. Calculate and display the class average
                    Console.WriteLine("Class average is: {0}", CalculateAverage(students));
                }//end try
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: {0}", ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }//end catch
            }
            else
            {
                Console.WriteLine("The file {0} does not exist", PathAndFile);
            }

            Console.ReadLine();
        }//eom

        #region User Defined Methods
        static void LoadFromFile(List<Student> students)
        {
            string firstName,
                lastName,
                studentID,
                input;
            int grade;
            Student student = null; //uncomment once the Student class is created

            //1. Setup the StreamReader
            StreamReader reader = null;
            //2. try-catch-finally structure to read the file
            try
            {
                //3. Open the file for reading
                reader = File.OpenText(PathAndFile);
                //4. Loop until there is no more data to read
                while ((input = reader.ReadLine()) != null)
                {
                    //5. Split the input string on the ','
                    string[] parts = input.Split(',');
                    //6. Assign the parts of string[] parts to the variables
                    // student = new Student(parts[2], parts[1], parts[0], int.Parse(parts[3]));
                    studentID = parts[0];
                    lastName = parts[1];
                    firstName = parts[2];
                    grade = int.Parse(parts[3]);
                    //7. Create a Student instance
                    student = new Student(firstName, lastName, studentID, grade);
                    //8. Add the Student instance to the List<T>
                    students.Add(student);
                }//end while loop
            }
            catch (Exception ex)
            {
                //throw any File I/O and/or parsing errors back to the calling method
                throw new Exception("ERROR: " + ex.Message);
            }
            finally
            {
                //close the StreamReader
                reader.Close();
            }//end try-catch-finally

        }//end of LoadFromFile

        static void WriteToFile(List<Student> students)
        {
            string firstname,
                lastname,
                studentID,
                output;
            int grade;

            //1. Setup the StreamWriter using the PathAndFile
            StreamWriter writer = null;
            //2. Setup the try-cath-finally
            try
            {
                //3. OPen the file for writing
                writer = File.CreateText(PathAndFile);
                //4. Loop through the List<T>
                foreach(Student student in students)
                {
                    //5. Get the values of each property of a Student instance
                    studentID = student.StudentID;
                    lastname = student.LastName;
                    firstname = student.FirstName;
                    grade = student.Grade;
                    //6. Create the output string
                    output = string.Format("{0},{1},{2},{3}", studentID, lastname, firstname, grade);
                    //7. Write the output string to the file
                    writer.WriteLine(output);
                }//end foreach
            }
            catch (Exception ex)
            {
                //throw any File I/O and/or parsing errors back to the calling method
                throw new Exception("ERROR: " + ex.Message);
            }
            finally
            {
                //close the StreamWriter

            }//end try-catch-finally
        }//end of WriteToFile

        static void AddStudent(List<Student> students)
        {
            string firstName,
                lastName,
                studentID;
            int grade;
            //1. Get values for each of the variables above using the provided menthods
            firstName = GetSafeString("Enter student's first name: ");
            lastName = GetSafeString("Enter student's last name: ");
            studentID = GetSafeString("Enter student's ID number: ");
            grade = GetSafeInt("     Enter student's grade: ");
            //2. Create an instance of Student
            Student student = new Student(firstName, lastName, studentID, grade);
            //3. Add the new Student instance to the List<T>
            students.Add(student);
        }//end of AddStudent

        static void DisplayStudents(List<Student> students)
        {
            //1. Create the display header
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,3}", "ID", "Last Name", "First Name", "Grade");
            //2. Loop though the List<T>
            foreach(Student student in students)
            {
                //3. Display each property of a student
                Console.WriteLine(student);
            }//end foreach
        }//end of DisplayStudents

        
        static double CalculateAverage(List<Student> students)
        {
            double average = 0;
            double sum = 0;
            //1. Loop through the List<T>
            foreach (Student student in students)
            {
                //2. Get the Grade from each Student instance and accumulate average
                sum += student.Grade;
            }//end foreach
            //4. Calculate average
            average = sum / students.Count;
            return average;
        }//end of CalculateAverage
        #endregion

        #region Provided Methods
        static void Setup()
        {
            Console.Title = "Object Demo 3";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        static int GetSafeInt(string prompt)
        {
            int number = 1;
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write("{0,20}", prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number >= 0 && number <= 100)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid number ... try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid number ... try again");
                }
            } while (!isValid);
            return number;
        }//end of getSafeInt

        static string GetSafeString(string prompt)
        {
            string name;
            bool isValid = false;
            do
            {
                Console.Write("{0,20}", prompt);
                name = Console.ReadLine();
                if (name.Length >= 3)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Name is not valid");
                }
            } while (!isValid);
            return name;
        }//end of GetSafeString
        #endregion
    }//eoc
}//eon
