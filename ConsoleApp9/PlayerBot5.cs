using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerBot5 : Player
    {
        public PlayerBot5(char colour) : base(colour)
        {
            // bot that Evaluates move based on size, Start squares, and opponents StartSquares
            ID = "Lv4";
        }

        const int StartEvalTurn = 4;
        const int OppStartValue = 120;
        const int StartSquareValue = 100;
        const int SizeValue = 300;
        const int InvalidSquaresValue = 5;
        int CurrentTurn = 0;

        public override bool DoTurn(Board b)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();
            Move[] Moves = FindMoves.AllMoves(b, this);
            if (Finished || Moves.Length == 0)
            {
                Console.WriteLine("No more valid moves for this player: " + Colour);
                Console.WriteLine();
                Finish();
                return false;
            }

            Move CurrentMove;
            if (CurrentTurn < StartEvalTurn)
            {
                Moves = FilterMoves.ForLargest(Moves);

                CurrentMove = FilterMoves.ForMostSpace(Moves, b, this);
            }
            else
            {
                CurrentMove = Evaluate(Moves, b);
            }

            MakeMove(b, CurrentMove);

            CurrentTurn++;
            return true;
        }

        public override void DoFirstTurn(Board b, int startSquare)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();

            Move[] Moves = FindMoves.WithStartSquare(b, this, startSquare);
            Moves = FilterMoves.ForLargest(Moves);

            Move CurrentMove = FilterMoves.ForMostSpace(Moves, b, this);

            MakeMove(b, CurrentMove);

            CurrentTurn++;
        }

        private Move Evaluate(Move[] moves, Board b)
        {
            int[] Evaluations = new int[moves.Length];
            Eval(moves, Evaluations, b);

            int Index = FindLargestIndex(Evaluations);
            return moves[Index];
        }

        private void Eval(Move[] moves, int[] evaluations, Board b)
        {
            int Index = 0;
            foreach (Move move in moves)
            {
                MakeMove(b, move);
                evaluations[Index] += (move.Size * SizeValue);
                evaluations[Index] += (CountStartSquares(b) * StartSquareValue);
                evaluations[Index] -= (CountOppStartSquares(b) * OppStartValue);
                evaluations[Index] -= (CountInvalid(b) * InvalidSquaresValue);
                UnmakeMove(b, move);
                Index++;
            }
        }

        private int CountInvalid(Board b)
        {
            int Count = 0;
            bool[] temp = FindInvalidSquares.Find(b, Colour);
            foreach (bool square in temp)
            {
                if (square)
                {
                    Count++;
                }
            }
            return Count;
        }

        private int CountOppStartSquares(Board b)
        {
            int Count = 0;
            Dictionary<int, char> IntToColour = new Dictionary<int, char>();
            IntToColour.Add(0, 'R');
            IntToColour.Add(1, 'B');
            IntToColour.Add(2, 'G');
            IntToColour.Add(3, 'Y');

            for (int i = 0; i <= 3; i++)
            {
                char CurrentColour = IntToColour[i];
                if (CurrentColour != Colour)
                {
                    Count += FindStartSquares.FindInt(b, CurrentColour).Length;
                }
            }
            return Count;
        }

        private int CountStartSquares(Board b)
        {
            return FindStartSquares.FindInt(b, Colour).Length;
        }

        private static int FindLargestIndex(int[] a)
        {
            int Largest = a[0];
            int CurrentIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int Value = a[i];
                if (Value > Largest)
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
