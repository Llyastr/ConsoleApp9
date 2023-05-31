using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerBot3 : Player
    {
        public PlayerBot3(char colour) : base(colour)
        {
            // makes a plan and executes it
        }

        public PlayerBot3(Player p) : base(p)
        {
            // constructor to create a duplicate of an opponent with the intellect of Bot2
        }

        List<Move> Plan;

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

            if (!Valid(Plan[0], b))
            {
                Plan = MakeNewPlan(b, new List<Move>(), 5);
            }

            Move CurrentMove = Plan[0];
            Plan.RemoveAt(0);

            MakeMove(b, CurrentMove);
            return true;
        }

        public override void DoFirstTurn(Board b, int startSquare)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();

            Plan = MakeNewPlan(b, new List<Move>(), 5, startSquare);
            Console.WriteLine(Plan.Count);
            PrintPlan(b);

            Move CurrentMove = Plan[0];
            Plan.RemoveAt(0);

            MakeMove(b, CurrentMove);
        }

        private List<Move> MakeNewPlan(Board b, List<Move> path, int depth, int initialSquare = -1)
        {
            Move[] Moves;
            if (initialSquare != -1)
            {
                Moves = FindMoves.WithStartSquare(b, this, initialSquare);
            }
            else
            {
                Moves = FindMoves.AllMoves(b, this);
            }
            Moves = FilterMoves.ForLargest(Moves);
            Moves = FilterMoves.Randomize(Moves);

            Console.WriteLine("Moves Length is: " + Moves.Length);

            if (Moves.Length == 0 || depth == 0)
            {
                return path;
            }

            int BestEval = 0;
            List<Move> BestPath = new List<Move>();
            foreach (Move move in Moves)
            {
                MakeMove(b, move);
                path.Add(move);
                b.Print();
                List<Move> NewPath = MakeNewPlan(b, path, depth - 1);
                path.Remove(move);
                UnmakeMove(b, move);

                int NewEval = EvaluatePlan(NewPath);

                if(NewEval > BestEval)
                {
                    BestPath = NewPath;
                }
            }
            return BestPath;
        }

        private bool Valid(Move m, Board b)
        {
            bool[] InvalidSquares = FindInvalidSquares.Find(b, Colour);
            foreach (int square in m.Squares)
            {
                if (InvalidSquares[square])
                {
                    return false;
                }
            }
            return true;
        }

        private int EvaluatePlan(List<Move> moves)
        {
            int Eval = 0;
            foreach (Move move in moves)
            {
                Eval += move.Size;
            }
            return Eval;
        }

        private void PrintPlan(Board b)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + " 's current plan:");
            foreach (Move move in Plan)
            {
                MakeMove(b, move);
            }
            b.Print();
            foreach (Move move in Plan)
            {
                UnmakeMove(b, move);
            }
        }
    }
}
