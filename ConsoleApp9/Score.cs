using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Score
    {
        public int Red;
        public int Blue;
        public int Green;
        public int Yellow;

        public Score(TurnCount tc)
        {
            Red = tc.InitialPlayers[0].CalculateScore();
            Blue = tc.InitialPlayers[1].CalculateScore();
            Green = tc.InitialPlayers[2].CalculateScore();
            Yellow = tc.InitialPlayers[3].CalculateScore();
        }

        public Score(Board b)
        {
            Red = CalculateForColour('R', b);
            Blue = CalculateForColour('B', b);
            Green = CalculateForColour('G', b);
            Yellow = CalculateForColour('Y', b);
        }

        private int CalculateForColour(char c, Board b)
        {
            int Output = 89;
            foreach (bool square in b.GetSquaresForColour[c])
            {
                if(square)
                {
                    Output -= 1;
                }
            }
            return Output;
        }

        public void Print()
        {
            Console.WriteLine("Score is:");

            Console.Write("Red: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Red);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(", Blue: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Blue);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(", Green: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Green);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(", Yellow: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Yellow);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }
    }
}
