using CourseApplication.Menus;
using Service.Helpers;
using WMPLib;
using System.Media;

namespace CourseApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        static void StartMenu()
        {

            Console.WriteLine(" _________Menu________");
            Console.WriteLine("|                     |");
            Console.WriteLine("|  1-Group methods    |");
            Console.WriteLine("|  2-Student methods  |");
            Console.WriteLine("|  3-Music settings   |");
            Console.WriteLine("|  4-Quit             |");
            Console.WriteLine("|_____________________| ");
            while (true)
            {
            firsmenu: Console.Write("Enter your selection:");
                string choice1 = Console.ReadLine();

                if (choice1 == "1")
                {
                    GroupMenu groupMenu = new GroupMenu();
                    groupMenu.Show();
                }
                else if (choice1 == "2")
                {
                    StudentMenu studentMenu = new StudentMenu();
                    studentMenu.Show();
                }
                else if (choice1 == "3") 
                {
                    MusicMenu musicMenu = new MusicMenu();
                    musicMenu.Show();
                }
                else if (choice1 == "4")
                {
                    return;
                }
                else
                {
                    Console.Beep();
                    Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again.");
                    goto firsmenu;
                }
            }
        }
    }
}
