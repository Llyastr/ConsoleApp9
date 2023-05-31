using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---Blokus---\n\n\n");
            Console.WriteLine("Press Enter to begin\n");
            string Check = Console.ReadLine();
            while (Check != "End")
            {
                Player p1;
                Player p2;
                Player p3;
                Player p4;
                while (true)
                {
                    Console.WriteLine("Choose type for each player:\n");
                    p1 = GetPlayer('R');
                    p2 = GetPlayer('B');
                    p3 = GetPlayer('G');
                    p4 = GetPlayer('Y');
                    DisplayPlayers(p1, p2, p3, p4);
                    if (AskConfirm())
                    {
                        break;
                    }
                }
                Game Game1 = new Game(p1, p2, p3, p4);
                Console.Write("\n\n\n\n");
                Game1.Play();
                Console.Write("\n\n\n\nGame ended, Press enter to start new game or type 'End' to close program: ");
                Check = Console.ReadLine();
                Console.WriteLine("\n\n\n");
            }
        }

        static Player GetPlayer(char colour)
        {
            static void ChangeColour(char colour = 'W')
            {
                switch (colour)
                {
                    case 'R':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'G':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'Y':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 'W':
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            Console.Write("Making player '");
            ChangeColour(colour);
            Console.Write(colour);
            ChangeColour();
            Console.WriteLine("', choose from one of the options:");
            Console.WriteLine("1. Lv1 Bot");
            Console.WriteLine("2. Lv2 Bot");
            Console.WriteLine("3. Lv3 Bot");
            Console.WriteLine("4. Lv4 Bot");
            Console.WriteLine("or default will be Manual");
            string Input = Console.ReadLine();
            Console.WriteLine();
            switch(Input)
            {
                case "1":
                    return new PlayerRandom(colour);
                case "2":
                    return new PlayerBot1(colour);
                case "3":
                    return new PlayerBot4(colour);
                case "4":
                    return new PlayerBot5(colour);
            }
            return new PlayerManual(colour);
        }

        static void DisplayPlayers(Player p1, Player p2, Player p3, Player p4)
        {
            static void ChangeColour(char colour = 'W')
            {
                switch(colour)
                {
                    case 'R':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'G':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'Y':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 'W':
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            static void DisplayPlayer(Player p)
            {
                ChangeColour(p.Colour);
                Console.Write(p.ID);
                ChangeColour();
            }

            DisplayPlayer(p1);
            Console.Write(" vs ");
            DisplayPlayer(p2);
            Console.Write(" vs ");
            DisplayPlayer(p3);
            Console.Write(" vs ");
            DisplayPlayer(p4);
            Console.WriteLine();
        }

        static bool AskConfirm()
        {
            Console.Write("Type 'Confirm' to confirm: ");
            string temp = Console.ReadLine();
            Console.WriteLine();
            if (temp == "Confirm" || temp == "c" || temp == "C")
            {
                return true;
            }
            return false;
        }
    }
}
