using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerRandom : Player
    {
        public PlayerRandom(char colour) : base(colour)
        {
            // Bot that plays a random move
            ID = "Lv1";
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

            Random R = new Random();
            Move CurrentMove = Moves[R.Next(Moves.Length)];

            MakeMove(b, CurrentMove);
        }
    }
}
