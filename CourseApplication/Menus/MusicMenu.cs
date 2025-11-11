using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace CourseApplication.Menus
{
    internal class MusicMenu
    {
        private static WindowsMediaPlayer player = new WindowsMediaPlayer();
        public void Show() 
        {

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("___________Music Menu_________");
                Console.WriteLine("|                             |");
                Console.WriteLine("|   1-Change & Play music     |");
                Console.WriteLine("|   2-Pause Music             |");
                Console.WriteLine("|   3-Resume music            |");
                Console.WriteLine("|   4-Stop music              |");
                Console.WriteLine("|   5-Return to the main menu |");
                Console.WriteLine("|_____________________________|");
                Console.WriteLine(" ");
            Input: Console.Write("Enter your selection: ");
                var choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
               firsmenu:Console.WriteLine("________Options______");
                        Console.WriteLine("|                   |");
                        Console.WriteLine("|  1-Slow Cinematic |");
                        Console.WriteLine("|  2-Slow piano     |");
                        Console.WriteLine("|  3-Piano          |");
                        Console.WriteLine("|___________________| ");
                        Console.WriteLine(" ");
                        Console.Write("Your selection:");
                        var music = Console.ReadLine();
                        if(music == "1") 
                        {
                            player.controls.stop();
                            player.URL = @"C:\Users\hp\Desktop\Course-application\Musics\ConsoleAppMusic1.mp3";
                            player.controls.play();
                            Console.WriteLine("Music 1 is playing...");
                            Console.ReadKey();
                        }
                        else if(music == "2") 
                        {
                            player.controls.stop();
                            player.URL = @"C:\Users\hp\Desktop\Course-application\Musics\ConsoleAppMusic2.mp3";
                            player.controls.play();
                            Console.WriteLine("Music 2 is playing...");
                            Console.ReadKey();
                        }
                        else if (music == "3") 
                        {
                            player.controls.stop();
                            player.URL = @"C:\Users\hp\Desktop\Course-application\Musics\ConsoleAppMusic3.mp3";
                            player.controls.play();
                            Console.WriteLine("Music 3 is playing...");
                            Console.ReadKey();
                        }
                        else 
                        {
                            Console.Beep();
                            Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again.");
                            goto firsmenu;
                        }
                        break;

                    case "2":
                        player.controls.pause();
                        Console.WriteLine("Music paused...");
                        Console.ReadKey();
                        break;
                    case "3":
                        player.controls.play();
                        Console.WriteLine("Music resumed...");
                        Console.ReadKey();
                        break;
                    case "4":
                        player.controls.stop();
                        Console.WriteLine("Music stopped...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(" _________Menu________");
                        Console.WriteLine("|                     |");
                        Console.WriteLine("|  1-Group methods    |");
                        Console.WriteLine("|  2-Student methods  |");
                        Console.WriteLine("|  3-Music settings   |");
                        Console.WriteLine("|  4-Quit             |");
                        Console.WriteLine("|_____________________| ");
                        return;
                    default:
                        Console.Beep();
                        Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again."); 
                        goto Input;

                }
            }
        }
    }
}
