using Domain.Models;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;
        private int count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }


        public Student Create(Student student)
        {
            student.Id = count;
            _studentRepository.Create(student);
            count++;
            return student;
        }


        public void Delete(int id)
        {
            if (id < count)
            {
                var existing = _studentRepository.GetById(id);
                _studentRepository.Delete(existing, id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID not found!");
                Console.ResetColor();
                return;
            }
        }


        public Student Get(int id)
        {
            var existing = _studentRepository.GetById(id);
            if (existing == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No group found with this given ID!");
                Console.ResetColor();
                return null;
            }
            return existing;
        }


        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }


        public List<Student> GetAllByGroupId(int groupId)
        {
            var students = _studentRepository.GetByGroupId(groupId);

            if (students == null || students.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No students found in this group ID!");
                Console.ResetColor();
                return new List<Student>();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Students in Group ID: {groupId}");
            Console.ResetColor();

            foreach (var student in students)
            {
                string groupInfo = student.group != null
                    ? $"Group: {student.group.name}, "
                    + $"Teacher: {student.group.teacher},"
                    + $" Room: {student.group.room}" : "Group: No group assigned";

                Console.WriteLine($"Name: {student.name} | Surname: {student.surname} | Age: {student.age} | {groupInfo}");
            }
            return students;
        }//




        public List<Student> SearchByNameOrSurname(string keyword)
        {
            return _studentRepository.SearchByNameOrSurname(keyword);
        }


        public Student Update(int id, Student student)
        {
            var existing = _studentRepository.GetById(id);
            if (existing == null)
                throw new KeyNotFoundException($"No student found with ID {id}.");

            if (string.IsNullOrWhiteSpace(student.name) || !student.name.All(char.IsLetter))
                throw new ArgumentException("Student name must contain only letters and cannot be empty.");

            if (string.IsNullOrWhiteSpace(student.surname) || !student.surname.All(char.IsLetter))
                throw new ArgumentException("Student surname must contain only letters and cannot be empty.");

            if (student.age <= 0)
                throw new ArgumentException("Student age must be a positive number.");

            if (student.group == null || student.group.Id <= 0)
                throw new ArgumentException("Invalid group. Group ID must be provided.");

            student.name = student.name.Trim();
            student.surname = student.surname.Trim();

            if (!string.IsNullOrWhiteSpace(student.group.name))
                student.group.name = student.group.name.Trim();

            if (!string.IsNullOrWhiteSpace(student.group.teacher))
                student.group.teacher = student.group.teacher.Trim();

            existing.name = student.name;
            existing.surname = student.surname;
            existing.age = student.age;
            existing.group = student.group;

            _studentRepository.Update(existing, id);

            return existing;
        }

    }
}
