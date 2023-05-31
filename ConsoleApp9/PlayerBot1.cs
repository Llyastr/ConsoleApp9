using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerBot1 : Player
    {
        public PlayerBot1(char colour) : base(colour)
        {
            // bot that plays its largest piece
            ID = "Lv2";
        }

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

            Moves = FilterMoves.ForLargest(Moves);

            Random R = new Random();
            Move CurrentMove = Moves[R.Next(Moves.Length)];

            MakeMove(b, CurrentMove);
            return true;
        }

        public override void DoFirstTurn(Board b, int startSquare)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();

            Move[] Moves = FindMoves.WithStartSquare(b, this, startSquare);
            Moves = FilterMoves.ForLargest(Moves);

            Random R = new Random();
            Move CurrentMove = Moves[R.Next(Moves.Length)];

            MakeMove(b, CurrentMove);
        }
    }
}
