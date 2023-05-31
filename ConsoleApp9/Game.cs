using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleApp9
{
    class Game
    {
        public Board Board;
        public TurnCount TurnCount;

        public Game(Player p1, Player p2, Player p3, Player p4)
        {
            Board = new Board();

            TurnCount = new TurnCount(p1, p2, p3, p4);
        }

        public void Play()
        {
            Console.WriteLine("Game Started\n\n\n");
            DoFirstTurn(0);
            DoFirstTurn(19);
            DoFirstTurn(399);
            DoFirstTurn(380);
            while(!Finished())
            {
                Stopwatch watch = new Stopwatch();
                watch.Reset();
                watch.Start();
                DoTurn();
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");            
            }
            Console.WriteLine();
            ShowScore();
        }

        public bool Finished()
        {
            for (int i = 0; i <= 3; i++)
            {
                if (!TurnCount.InitialPlayers[i].Finished)
                {
                    return false;
                }
            }
            return true;
        }

        public void Toggle()
        {
            TurnCount.Toggle();
        }

        public void DoTurn()
        {
            if (TurnCount.Turn.DoTurn(Board))
            {
                Toggle();
                return;
            }
            Toggle();
        }

        public void DoFirstTurn(int initialSquare)
        {
            TurnCount.Turn.DoFirstTurn(Board, initialSquare);
            Toggle();
        }

        public void ShowScore()
        {
            Score TempScore = new Score(TurnCount);
            TempScore.Print();
        }
    }
}
