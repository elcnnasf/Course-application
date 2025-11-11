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
    public class GroupController
    {
        GroupService groupService = new GroupService();
        public static void CreateGroup(GroupService group)
        {
            Console.WriteLine("═════════ Create Group ═════════");

            Console.Write("Enter group name: ");
            string name = Console.ReadLine();
            string teacher;
            while (true)
            {
                Console.Write("Enter teacher name: ");
                teacher = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(teacher) && teacher.All(char.IsLetter))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Name must contain only letters!");
                Console.Beep();
            }

            int roomNumber;
            while (true)
            {
                Console.Write("Enter room number: ");
                string roomInput = Console.ReadLine();
                if (int.TryParse(roomInput, out roomNumber))
                    break;
                else
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input must be a number!");
                Console.Beep();
            }

            Groups groups = new Groups
            {
                name = name,
                teacher = teacher,
                room = roomNumber
            };

            group.Create(groups);
            Helpers.ConsoleColor(ConsoleColor.Green, "Group created successfully!");
            Console.WriteLine($"Name: {name} | Teacher: {teacher} | Room: {roomNumber}");
            Console.ReadKey();
        }

        public static void UpdateGroup(GroupService groupService)
        {
            Console.WriteLine("═════════ Update Group ═════════");
            int id;
            while (true)
            {
                Console.Write("Enter group ID to update: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
                Console.Beep();
            }
            Console.Write("Enter new group name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new teacher name: ");
            string teacher = Console.ReadLine();

            int room;
            while (true)
            {
                Console.Write("Enter new room number: ");
                if (int.TryParse(Console.ReadLine(), out room))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
                Console.Beep();
            }
            Groups updatedGroup = new Groups
            {
                name = name,
                teacher = teacher,
                room = room
            };
            try
            {
                groupService.Update(id, updatedGroup);
            }
            catch (Exception ex)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        public static void GetGroupById(GroupService groupService)
        {
            Console.WriteLine("═════════ Get Group by ID ═════════");

            int id;
            while (true)
            {
                Console.Write("Enter group ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
                Console.Beep();
            }

            var group = groupService.Get(id);
            if (group != null)
            {
                Console.WriteLine($"ID: {group.Id} | Name: {group.name} | Teacher: {group.teacher} | Room: {group.room} ");
            }
            Console.ReadKey();
        }

        public static void DeleteGroup(GroupService group)
        {
            Console.WriteLine("═════════ Delete Group ═════════");

            int id;
            while (true)
            {
                Console.Write("Enter group ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
                Console.Beep();
            }

            group.Delete(id);

            Console.ReadKey();
        }

        public static void GetGroupsByTeacher(GroupService group)
        {
            Console.WriteLine("═════════ Get Groups by Teacher ═════════");

            Console.Write("Enter teacher name: ");
            string teacher = Console.ReadLine();

            var groups = group.GetAll().FindAll(g => g.teacher.Equals(teacher, StringComparison.OrdinalIgnoreCase));

            if (groups.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No groups found for this teacher.");
            else
            {
                foreach (var g in groups)
                    Console.WriteLine($"ID: {g.Id} | Name: {g.name} | Room: {g.room}");
            }
            Console.ReadKey();
        }

        public static void GetGroupsByRoom(GroupService group)
        {
            Console.WriteLine("═════════ Get Groups by Room ═════════");

            int room;
            while (true)
            {
                Console.Write("Enter room number: ");
                if (int.TryParse(Console.ReadLine(), out room))
                    break;
                else
                    Console.WriteLine("Input must be a number!");
                Console.Beep();
            }

            var groups = group.GetAll().FindAll(g => g.room == room);

            if (groups.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No groups found in this room.");
            else
            {
                foreach (var g in groups)
                    Console.WriteLine($"ID: {g.Id} | Name: {g.name} | Teacher: {g.teacher}");
            }
            Console.ReadKey();
        }

        public static void GetAllGroups(GroupService group)
        {
            Console.WriteLine("═════════ All Groups ═════════");

            var allGroups = group.GetAll();

            if (allGroups.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No groups found.");
            else
            {
                foreach (var g in allGroups)
                    Console.WriteLine($"ID: {g.Id} | Name: {g.name} | Teacher: {g.teacher} | Room: {g.room}");
            }
            Console.ReadKey();
        }

        public static void SearchGroupsByName(GroupService service)
        {
            Console.WriteLine("═════════ Search Groups by Name ═════════");

            Console.Write("Enter a name: ");
            string keyword = Console.ReadLine();
            var groups = service.GetAll().Where(g => g.name.ToLower().Contains(keyword.ToLower())).ToList();

            if (groups.Count == 0)
                Helpers.ConsoleColor(ConsoleColor.Red, "No groups found.");
            else
            {
                foreach (var g in groups)
                    Console.WriteLine($"ID: {g.Id} | Name: {g.name} | Teacher: {g.teacher} | Room: {g.room}");
            }
            Console.ReadKey();
        }
    }
}

