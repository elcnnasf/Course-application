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
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int count;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Groups Create(Groups group)
        {

            group.Id = count;
            _groupRepository.Create(group);
            count++;
            return group;

        }

        public void Delete(int id)
        {
            if (id < count)
            {
                var existing = _groupRepository.GetById(id);
                _groupRepository.Delete(existing, id);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID not found!");
                Console.ResetColor();
                return;
            }

        }


        public Groups Get(int id)
        {
            var existing = _groupRepository.GetById(id);
            if (existing == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No group found with this given ID!");
                Console.ResetColor();
                return null;
            }
            return existing;
        }

        public List<Groups> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Groups Update(int id, Groups group)
        {
            var existing = _groupRepository.GetById(id);
            if (existing == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No group found with ID {id}.");
                Console.ResetColor();
                throw new KeyNotFoundException($"No group found with ID {id}.");
            }
            if (string.IsNullOrWhiteSpace(group.name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Group name cannot be empty!");
                Console.ResetColor();
                throw new ArgumentException("Group name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(group.teacher) || !group.teacher.All(c => char.IsLetter(c) || c == ' '))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher name must only contain only letters and cannot be empty!");
                Console.ResetColor();
                throw new ArgumentException("Teacher name must only contain only letters and cannot be empty.");
            }
            group.name = group.name.Trim();
            group.teacher = group.teacher.Trim();
            _groupRepository.Update(group, id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Group with ID:{id} successfully updated!");
            Console.ResetColor();

            return _groupRepository.GetById(id);
        }


    }
}
