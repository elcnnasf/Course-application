using Service.Helpers;
using System;
using System.IO;
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
                Console.WriteLine("╔═════════════════════════════╗");
                Console.WriteLine("║          Music Menu         ║");
                Console.WriteLine("╠═════════════════════════════╣");
                Console.WriteLine("║                             ║");
                Console.WriteLine("║  1-Change & Play music      ║");
                Console.WriteLine("║  2-Pause Music              ║");
                Console.WriteLine("║  3-Resume Music             ║");
                Console.WriteLine("║  4-Stop Music               ║");
                Console.WriteLine("║  5-Return to the main menu  ║");
                Console.WriteLine("║                             ║");
                Console.WriteLine("╚═════════════════════════════╝");
                Console.WriteLine("");
                Console.Write("Enter your selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowMusicOptions();
                        break;

                    case "2":
                        player.controls.pause();
                        Helpers.ConsoleColor(ConsoleColor.Yellow, "Music paused...");
                        Console.ReadKey();
                        break;

                    case "3":
                        player.controls.play();
                        Helpers.ConsoleColor(ConsoleColor.Green, "Music resumed...");
                        Console.ReadKey();
                        break;

                    case "4":
                        player.controls.stop();
                        Helpers.ConsoleColor(ConsoleColor.Red, "Music stopped...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("╔═════════════════════╗");
                        Console.WriteLine("║        Menu         ║");
                        Console.WriteLine("╠═════════════════════╣");
                        Console.WriteLine("║  1-Group methods    ║");
                        Console.WriteLine("║  2-Student methods  ║");
                        Console.WriteLine("║  3-Music settings   ║");
                        Console.WriteLine("║  4-Quit             ║");
                        Console.WriteLine("╚═════════════════════╝");
                        return; 

                    default:
                        Console.Beep();
                        Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMusicOptions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════╗");
                Console.WriteLine("║       Options       ║");
                Console.WriteLine("╠═════════════════════╣");
                Console.WriteLine("║  1-Slow Cinematic   ║");
                Console.WriteLine("║  2-Slow Piano       ║");
                Console.WriteLine("║  3-Piano            ║");
                Console.WriteLine("║  4-Return           ║");
                Console.WriteLine("╚═════════════════════╝");
                Console.WriteLine();
                Console.Write("Your selection: ");
                string musicChoice = Console.ReadLine();

                string musicFile = musicChoice switch
                {
                    "1" => "ConsoleAppMusic1.mp3",
                    "2" => "ConsoleAppMusic2.mp3",
                    "3" => "ConsoleAppMusic3.mp3",
                    "4" => null, 
                    _ => ""
                };

                if (musicFile == null)
                    break; 

                if (string.IsNullOrEmpty(musicFile))
                {
                    Console.Beep();
                    Helpers.ConsoleColor(ConsoleColor.Red, "Wrong selection! Try again.");
                    Console.ReadKey();
                    continue; 
                }

                string musicFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musics");
                string musicPath = Path.Combine(musicFolder, musicFile);

                if (!File.Exists(musicPath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Music file not found... ");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue; 
                }
                player.URL = musicPath;
                player.controls.play();
                Helpers.ConsoleColor(ConsoleColor.Green, $"{musicFile} is now playing...");
                Console.ReadKey();
                break; 
            }
        }
    }
}
