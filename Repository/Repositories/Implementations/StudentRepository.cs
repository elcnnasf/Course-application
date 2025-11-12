using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFounfException("Data not found!");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(Student data, int id)
        {
            try
            {
                var existing = GetById(id);
                if (existing is null) throw new NotFounfException("No student found with the given ID!");
                AppDbContext<Student>.datas.Remove(existing);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Student with ID:{id} deleted successfull");
            Console.ResetColor();
        }
        public List<Student> GetAll()
        {
            return AppDbContext<Student>.datas;
        }

        public List<Student> GetByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(s => s.age == age).ToList();
        }

        public List<Student> GetByGroupId(int groupId)
        {
            return AppDbContext<Student>.datas.Where(s => s.group.Id == groupId).ToList();
        }

        public Student GetById(int id)
        {
            return AppDbContext<Student>.datas.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            return AppDbContext<Student>.datas
                .Where(s => s.name.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                s.surname.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(Student data, int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.name = data.name;
                existing.surname = data.surname;
                existing.age = data.age;
                if (data.group != null)
                {
                    existing.group = data.group;
                }
                else
                {
                    throw new ArgumentException("Group cannot be null.");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No student found with ID {id}.");
            }
        }

    }
}
