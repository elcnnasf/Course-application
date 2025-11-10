using CourseApplication.Menus;

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
            Console.WriteLine("|  3-Quit             |");
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
                    return;
                }
                else
                {
                    Console.Beep();
                    goto firsmenu;
                }
            }
        }
    }
}
