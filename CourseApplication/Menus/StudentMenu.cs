using CourseApplication.Controllers;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.Menus
{
    internal class StudentMenu
    {
        public void Show()
        {
            GroupService groupService = new GroupService();
            StudentService studentService = new StudentService();

            while (true)
            {
                Console.Clear();
                Helpers.ConsoleColor(ConsoleColor.Green, "Welcome to student menu:");

                Console.WriteLine("╔═════════════════════════════════════════════╗");
                Console.WriteLine("║                 Student menu                ║");
                Console.WriteLine("╠═════════════════════════════════════════════╣");
                Console.WriteLine("║                                             ║");
                Console.WriteLine("║     1-Create Student                        ║");
                Console.WriteLine("║     2-Update Student                        ║");
                Console.WriteLine("║     3-Get student by id                     ║");
                Console.WriteLine("║     4-Delete student                        ║");
                Console.WriteLine("║     5-Get students by age                   ║");
                Console.WriteLine("║     6- Get all students by group id         ║");
                Console.WriteLine("║     7-Search for students by name/surname   ║");
                Console.WriteLine("║     8-Get All Students                      ║");
                Console.WriteLine("║     9-Return to main menu                   ║");
                Console.WriteLine("║     0-Quit                                  ║");
                Console.WriteLine("║                                             ║");
                Console.WriteLine("╚═════════════════════════════════════════════╝");
                Console.WriteLine(" ");
            Input: Console.Write("Enter your selection: ");
                string input = Console.ReadLine();
                int number;

                if (!int.TryParse(input, out number))
                {
                    Console.Beep();
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input type is not correct!");
                }

                switch (input)
                {
                    case "1":
                        StudentController.CreateStudent(studentService, groupService);
                        break;

                    case "2":
                        StudentController.UpdateStudent(studentService, groupService);
                        break;

                    case "3":
                        StudentController.GetStudentById(studentService, groupService);
                        break;

                    case "4":
                        StudentController.DeleteStudent(studentService);
                        break;

                    case "5":
                        StudentController.GetStudentByAge(studentService);
                        break;

                    case "6":
                        StudentController.GetAllStudentByGroupId(studentService);
                        break;

                    case "7":
                        StudentController.SearchStudentByNameOrSurname(studentService);
                        break;

                    case "8":
                        StudentController.GetAllStudents(studentService);
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine("╔═════════════════════╗");
                        Console.WriteLine("║        Menu         ║");
                        Console.WriteLine("╠═════════════════════╣");
                        Console.WriteLine("║  1-Group methods    ║");
                        Console.WriteLine("║  2-Student methods  ║");
                        Console.WriteLine("║  3-Music settings   ║");
                        Console.WriteLine("║  4-Quit             ║");
                        Console.WriteLine("╚═════════════════════╝");
                        return;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Beep();
                        Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again.");
                        goto Input;
                }
            }
        }
    }
}
