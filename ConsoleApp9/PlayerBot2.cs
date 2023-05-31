using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerBot2 : Player
    {
        public PlayerBot2(char colour) : base(colour)
        {
            // bot that uses search on largest moves
        }

        public PlayerBot2(Player p) : base(p)
        {
            // constructor to create a duplicate of an opponent with the intellect of Bot2
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

        public void Search(Game g)
        {
            Game DupeGame = DuplicateGame(g);
        }

        private Game DuplicateGame(Game g)
        {
            Player DupeP1 = new PlayerBot2(g.TurnCount.InitialPlayers[0]);
            Player DupeP2 = new PlayerBot2(g.TurnCount.InitialPlayers[1]);
            Player DupeP3 = new PlayerBot2(g.TurnCount.InitialPlayers[2]);
            Player DupeP4 = new PlayerBot2(g.TurnCount.InitialPlayers[3]);
            Game DupeGame = new Game(DupeP1, DupeP2, DupeP3, DupeP4);
            DupeGame.TurnCount.Count = g.TurnCount.Count;
            Board DupeBoard = new Board();
            DupeBoard.GetSquaresForColour['R'] = DuplicateArray(g.Board.GetSquaresForColour['R']);
            DupeBoard.GetSquaresForColour['B'] = DuplicateArray(g.Board.GetSquaresForColour['B']);
            DupeBoard.GetSquaresForColour['G'] = DuplicateArray(g.Board.GetSquaresForColour['G']);
            DupeBoard.GetSquaresForColour['Y'] = DuplicateArray(g.Board.GetSquaresForColour['Y']);
            return DupeGame;
        }

        private bool[] DuplicateArray(bool[] from)
        {
            bool[] Output = new bool[from.Length];
            for (int i = 0; i < from.Length; i++)
            {
                if(from[i])
                {
                    Output[i] = true;
                }
            }
            return Output;
        }
    }
}
