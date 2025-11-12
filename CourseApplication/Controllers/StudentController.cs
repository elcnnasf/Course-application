using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.Controllers
{
    public class StudentController
    {
        public static void CreateStudent(StudentService studentService, GroupService groupService)
        {
            Console.WriteLine("═════════ Create Student ═════════");

            string name;
            while (true)
            {
                Console.Write("Enter student name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Name must contain only letters!");
                Console.Beep();
            }

            string surname;
            while (true)
            {
                Console.Write("Enter student surname: ");
                surname = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(surname) && surname.All(char.IsLetter))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Surname must contain only letters!");
                Console.Beep();
            }

            int age;
            while (true)
            {
                Console.Write("Enter student age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input must be a number!");
                Console.Beep();
            }

            Groups exGroup;
            while (true)
            {
                Console.Write("Enter new group ID: ");
                if (int.TryParse(Console.ReadLine(), out int groupId))
                {
                    exGroup = groupService.Get(groupId);
                    if (exGroup != null)
                        break;
                    else
                        Helpers.ConsoleColor(ConsoleColor.Red, $"Group with ID '{groupId}' does not exist!");
                }
                else
                {
                    Helpers.ConsoleColor(ConsoleColor.Red, "Group ID must be a number!");
                }
            }
            Student student = new Student
            {
                name = name,
                surname = surname,
                age = age,
                group = exGroup
            };
            studentService.Create(student);
            Helpers.ConsoleColor(ConsoleColor.Green, "Student created successfully!");
            Console.WriteLine($"Name: {name} | Surname: {surname} | Age: {age} | Group: {exGroup.name}");
            Console.ReadKey();
        }

        public static void UpdateStudent(StudentService studentService, GroupService groupService)
        {
            Console.WriteLine("═════════ Update Student ═════════");

            int id;
            while (true)
            {
                Console.Write("Enter student ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input must be a number!");
            }

            var existing = studentService.Get(id);
            if (existing == null)
            {
                Helpers.ConsoleColor(ConsoleColor.Red, $"No student found with ID {id}.");
                Console.ReadKey();
                return;
            }

            string name;
            while (true)
            {
                Console.Write("Enter new student name: ");
                name = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Name must contain only letters!");
                Console.Beep();
            }

            string surname;
            while (true)
            {
                Console.Write("Enter new student surname: ");
                surname = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(surname) && surname.All(char.IsLetter))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Surname must contain only letters!");
            }

            int age;
            while (true)
            {
                Console.Write("Enter new student age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Age must be a positive number!");
            }

            Groups exGroup;
            while (true)
            {
                Console.Write("Enter new group ID: ");
                if (int.TryParse(Console.ReadLine(), out int groupId))
                {
                    exGroup = groupService.Get(groupId);
                    if (exGroup != null)
                        break;
                    else
                        Helpers.ConsoleColor(ConsoleColor.Red, $"Group with ID '{groupId}' does not exist!");
                }
                else
                {
                    Helpers.ConsoleColor(ConsoleColor.Red, "Group ID must be a number!");
                }
            }

            Student student = new Student
            {
                name = name,
                surname = surname,
                age = age,
                group = exGroup
            };

            try
            {
                studentService.Update(id, student);
                Helpers.ConsoleColor(ConsoleColor.Green, "Student updated successfully!");
            }
            catch (Exception ex)
            {
                Helpers.ConsoleColor(ConsoleColor.Red, $"{ex.Message}");
            }

            Console.ReadKey();
        }


        public static void GetStudentById(StudentService studentService, GroupService groupService)
        {
            Console.WriteLine("═════════ Get Student by ID ═════════");

            int id;
            while (true)
            {
                Console.Write("Enter student ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
            }

            var student = studentService.Get(id);
            if (student != null)
            {

                Console.WriteLine($"Name :{student.name} | Surname: {student.surname} | Age: {student.age} | Group: {student.group.name} ");
            }
            Console.ReadKey();
        }

        public static void DeleteStudent(StudentService studentService)
        {
            Console.WriteLine("═════════ Delete Student ═════════");

            int id;
            while (true)
            {
                Console.Write("Enter student ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
            }

            studentService.Delete(id);

            Console.ReadKey();
        }

        public static void GetStudentByAge(StudentService studentService)
        {
            Console.WriteLine("═════════ Get student by age ═════════");

            int age;
            while (true)
            {
                Console.Write("Enter new student age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input must be a number!");
            }
            var students = studentService.GetAll().FindAll(s => s.age == age);
            if (students.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No Student found for this age.");
            else
            {
                foreach (var s in students)
                    Console.WriteLine($"Name :{s.name} | Surname: {s.surname} | Age: {s.age} | Group: {s.group.name} ");
            }
            Console.ReadKey();
        }

        public static void GetAllStudentByGroupId(StudentService studentService)
        {
            Console.WriteLine("═════════ Get all students by group id ═════════");

            int groupId;
            while (true)
            {
                Console.Write("Enter group id: ");
                if (int.TryParse(Console.ReadLine(), out groupId))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
            }

            studentService.GetAllByGroupId(groupId);
            Console.ReadKey();
        }

        public static void SearchStudentByNameOrSurname(StudentService studentService)
        {
            Console.WriteLine("═════════ Serach students by name/surname ═════════");

            Console.Write("Enter a name/surname: ");
            string keyword = Console.ReadLine();
            var students = studentService.GetAll().Where(s => s.name.ToLower().Contains(keyword.ToLower()) ||
            s.surname.ToLower().Contains(keyword.ToLower())).ToList();

            if (students.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No student found.");
            else
            {
                foreach (var s in students)
                    Console.WriteLine($"Name :{s.name} | Surname: {s.surname} | Age: {s.age} | Group: {s.group.name} ");
            }
            Console.ReadKey();
        }

        public static void GetAllStudents(StudentService studentService)
        {
            Console.WriteLine("═════════ All Students ═════════");

            var allstudents = studentService.GetAll();

            if (allstudents.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No student found.");

            else
            {
                foreach (var s in allstudents)
                    Console.WriteLine($"Name :{s.name} | Surname: {s.surname} | Age: {s.age} | Group: {s.group.name} ");
            }
            Console.ReadKey();
        }
    }
}
