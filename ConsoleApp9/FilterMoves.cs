using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class FilterMoves
    {
        public static Move[] ForLargest(Move[] moves)
        {
            int LargestSize = 0;
            List<Move> Output = new List<Move>();
            foreach (Move move in moves)
            {
                int NewSize = move.Size;
                LargestSize = Math.Max(LargestSize, NewSize);
            }
            foreach (Move move in moves)
            {
                if (move.Size == LargestSize)
                {
                    Output.Add(move);
                }
            }

            return Output.ToArray();
        }

        public static Move[] Randomize(Move[] moves)
        {
            Move[] Output = new Move[moves.Length];
            List<int> Indexes = new List<int>();
            for (int i = 0; i < moves.Length; i++)
            {
                Indexes.Add(i);
            }
            Random rnd = new Random();
            for (int i = 0; i < moves.Length; i++)
            {
                int Index = Indexes[rnd.Next(Indexes.Count)];
                Indexes.Remove(Index);
                Output[Index] = moves[i];
            }
            return Output;
        }

        public static Move ForMostSpace(Move[] moves, Board b, Player p)
        {
            int[] Evaluations = new int[moves.Length];
            int Index = 0;
            foreach (Move move in moves)
            {
                p.MakeMove(b, move);
                Evaluations[Index] = CountStartSquares(p.Colour, b);
                p.UnmakeMove(b, move);
                Index++;
            }
            Index = FindLargestIndex(Evaluations);
            return moves[Index];
        }

        private static int CountStartSquares(char colour, Board b)
        {
            return FindStartSquares.FindInt(b, colour).Length;
        }

        private static int FindLargestIndex(int[] a)
        {
            int Largest = a[0];
            int CurrentIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int Value = a[i];
                if(Value > Largest)
                {
                    Largest = Value;
                    CurrentIndex = i;
                }
                if (Value == Largest)
                {
                    Random R = new Random();
                    if (R.Next(2) == 0)
                    {
                        Largest = Value;
                        CurrentIndex = i;
                    }
                }
            }
            return CurrentIndex;
        }
    }
}
