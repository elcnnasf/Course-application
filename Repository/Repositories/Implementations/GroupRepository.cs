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
    public class GroupRepository : IGroupRepository<Groups>
    {
        public void Create(Groups data)
        {
            try
            {
                if (data is null) throw new NotFounfException("Data not found!");
                AppDbContext<Groups>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Groups data, int id)
        {
            try
            {
                var existing = GetById(id);
                if (existing is null) throw new NotFounfException("No group found with the given ID!");
                AppDbContext<Groups>.datas.Remove(existing);


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Group with ID {id} deleted successfull");
            Console.ResetColor();
        }


        public List<Groups> GetAll()
        {
            return AppDbContext<Groups>.datas;
        }

        public Groups GetById(int id)
        {
            return AppDbContext<Groups>.datas.FirstOrDefault(g => g.Id == id);
        }

        public List<Groups> GetByRoom(string room)
        {
            return AppDbContext<Groups>.datas.Where(g => g.room.ToString() == room).ToList();
        }

        public List<Groups> GetByTeacher(string teacher)
        {
            return AppDbContext<Groups>.datas.Where(g => g.teacher == teacher).ToList();
        }

        public List<Groups> SearchByName(string name)
        {
            return AppDbContext<Groups>.datas.Where(g => g.name.Contains(name)).ToList();
        }

        public void Update(Groups group, int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.name = group.name;
                existing.teacher = group.teacher;
                existing.room = group.room;
            }
        }

    }
}
