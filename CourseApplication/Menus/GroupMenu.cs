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
    internal class GroupMenu
    {
        public void Show()
        {
            GroupService groupService = new GroupService();

            while (true)
            {
                Console.Clear();
                Helpers.ConsoleColor(ConsoleColor.Green, "Welcome to group menu:");
                Console.WriteLine(" _______________Group menu_____________");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|      1-Create Group                  |");
                Console.WriteLine("|      2-Update Group                  |");
                Console.WriteLine("|      3-Get group by id               |");
                Console.WriteLine("|      4-Delete Group                  |");
                Console.WriteLine("|      5-Get all groups by teacher     |");
                Console.WriteLine("|      6-Get all groups by room        |");
                Console.WriteLine("|      7-Get all groups                |");
                Console.WriteLine("|      8-Search groups by name         |");
                Console.WriteLine("|      9-Return to main menu           |");
                Console.WriteLine("|      0-Quit                          |");
                Console.WriteLine("|______________________________________|");
                Console.WriteLine();

            Input: Console.Write("Enter your selection: ");
                string input = Console.ReadLine();
                int number;

                if (!int.TryParse(input, out number))
                {
                    Helpers.ConsoleColor(ConsoleColor.Red, "Input type is not correct!");
                }

                switch (input)
                {
                    case "1":
                        GroupController.CreateGroup(groupService);
                        break;

                    case "2":
                        GroupController.UpdateGroup(groupService);
                        break;

                    case "3":
                        GroupController.GetGroupById(groupService);
                        break;

                    case "4":
                        GroupController.DeleteGroup(groupService);
                        break;

                    case "5":
                        GroupController.GetGroupsByTeacher(groupService);
                        break;

                    case "6":
                        GroupController.GetGroupsByRoom(groupService);
                        break;

                    case "7":
                        GroupController.GetAllGroups(groupService);
                        break;

                    case "8":
                        GroupController.SearchGroupsByName(groupService);
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine(" _________Menu________");
                        Console.WriteLine("|                     |");
                        Console.WriteLine("|  1-Group methods    |");
                        Console.WriteLine("|  2-Student methods  |");
                        Console.WriteLine("|  3-Music settings   |");
                        Console.WriteLine("|  4-Quit             |");
                        Console.WriteLine("|_____________________| ");
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
