using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            GameMaster gm = new GameMaster();
            SloGameMasterSolo sgms = new SloGameMasterSolo();
            EngGameMasterSolo egms = new EngGameMasterSolo();
            Console.WriteLine("Hangman");
            Console.Title = "Hangman";
            while (run == true)
            {
                Console.Clear();
                Console.Write("/help at anytime for help | Select mode...   ");
                String mode = Console.ReadLine();
                Console.Clear();
                if (mode.Equals("/help"))
                {
                    Console.WriteLine("There are two modes solo and 2players\n" +
                        "Solo | the computer chooses the word and you guess\n" +
                        "2players | 1st player chooses the word and the second guesses");
                }
                else if (mode.Equals("solo"))
                {
                    lang:
                    Console.Write("slovenian or english>");
                    string lang = Console.ReadLine();
                    if (lang.Equals("english"))
                    {
                        egms.StartGame();

                    }
                    else if (lang.Equals("slovenian"))
                    {
                        sgms.StartGame();
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Either you typed the language incorectly or it is not available");
                        goto lang;
                    }
                }
                else if (mode.Equals("2players")) 
                {
                    gm.StartGame();
                }
            }

        }
    }
}
