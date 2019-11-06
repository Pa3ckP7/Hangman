using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class GameMaster
    {
        Pictures pic = new Pictures();
        public string Passcode { get; set; }
        int lives=11;
        string code;
        bool PasscodeGuessed = false;
        bool Reset = false;
        List<char> wrong_letters = new List<char>();
        List<char> used_letters = new List<char>();
        public void StartGame() 
        {
            Passcode=Passcode.Trim();
            for (int i = 0; i < Passcode.Length; i++)
            {
                code += "*";
            }
            Char[] pc = Passcode.ToCharArray();
            Char[] c = code.ToCharArray();
            for (int i = 0; i < Passcode.Length; i++)
            {
                if (pc[i] == ' ')
                {
                    c[i] = pc[i];
                }
            }
            code = new string(c);
            Console.Clear();
            Console.WriteLine();
            Game();
            
        }
        public void Game() 
        {
            while (PasscodeGuessed == false && lives > 0 && Reset==false)
            {
                Stats();
                Console.Write("your guess>");
                string your_guesss = Console.ReadLine().ToLower();
                
                if (your_guesss.Equals("")) 
                {
                    Console.Clear();
                    Console.WriteLine();
                    continue;
                }
                if (your_guesss.Equals("/reset")) 
                {
                    Reset = true;
                    break;
                }
                if (your_guesss.Length > 1)
                {
                    if (your_guesss.Equals(Passcode))
                    {
                        PasscodeGuessed = true;
                        break;
                    }
                    else 
                    {
                        lives = 0;
                        break;
                    }
                }
                char your_guess=Convert.ToChar(your_guesss);
                if (used_letters.Contains(your_guess)) 
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("You already tried that");
                    continue;
                }
                used_letters.Add(your_guess);
                bool found = false;
                List<int> index = new List<int>();
                Char[] pc = Passcode.ToCharArray();
                Char[] c = code.ToCharArray();
                for (int i = 0; i < Passcode.Length; i++)
                {
                    if (pc[i] == your_guess)
                    {
                        index.Add(i);
                        
                        found = true;
                        
                    }  
                }
                if (found == true)
                {
                    foreach (int i in index)
                    {
                        c[i] = pc[i];
                    }
                    index.Clear();
                }
                else 
                {
                    wrong_letters.Add(your_guess);
                }
                code = new string(c);
                if (found == false)
                {
                    lives--;
                }
                if (Passcode.Equals(code))
                {
                    PasscodeGuessed = true;
                }
                Console.Clear();
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine();
            GameEnd();
        }
        public void Stats() 
        {
            Console.WriteLine($"{code}     | {Passcode.Length} letters");
            if (lives <= 5 && lives > 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (lives <= 3 && lives > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (lives == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            switch (lives) 
            {
                case 10:
                    Console.WriteLine(pic.p10);
                    break;
                case 9:
                    Console.WriteLine(pic.p9);
                    break;
                case 8:
                    Console.WriteLine(pic.p8);
                    break;
                case 7:
                    Console.WriteLine(pic.p7);
                    break;
                case 6:
                    Console.WriteLine(pic.p6);
                    break;
                case 5:
                    Console.WriteLine(pic.p5);
                    break;
                case 4:
                    Console.WriteLine(pic.p4);
                    break;
                case 3:
                    Console.WriteLine(pic.p3);
                    break;
                case 2:
                    Console.WriteLine(pic.p2);
                    break;
                case 1:
                    Console.WriteLine(pic.p1);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            Console.ResetColor();
            Console.Write("incorect letters: ");
            wrong_letters.ForEach(Console.Write);
            Console.WriteLine("\n------------------------");
        }
        public void GameEnd() 
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (lives == 0&& PasscodeGuessed==false)
            {
                Console.WriteLine($"You Lose.\n{pic.p0}\nThe passcode was {Passcode}");
            }
            Console.ResetColor();
            if (PasscodeGuessed == true) 
            {
                Console.WriteLine("You win");
            }
            if (PasscodeGuessed == true && lives == 0) 
            {
                Console.WriteLine("Impossible");
            }
            if (Reset==true) 
            {
                Console.WriteLine($"Force reset triggered. The word was {Passcode}");
            }
            code = "";
            lives = 10;
            PasscodeGuessed = false;
            Reset = false;
            wrong_letters.Clear();
            used_letters.Clear();
        }
    }
}
