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
            Console.WriteLine("Hangman");
            while (run == true)
            {
                Console.Write("Skrita beseda...   ");
                string Passcode = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Passcode))
                {
                    Console.WriteLine("Invalid passcode!");
                    continue;
                }
                else 
                {
                    gm.Passcode = Passcode.ToLower();
                }
                gm.StartGame();
            }

        }
    }
}
