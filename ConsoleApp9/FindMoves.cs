using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class FindMoves
    {
        public static Move[] WithPieceAndStartSquare(Board b, Piece p, int startSquare, char colour)
        {
            bool[] InvalidSquares = FindInvalidSquares.Find(b, colour);
            List<Move> Output = new List<Move>();

            foreach (Playable playable in p.Playables)
            {
                Move NewMove = Base(InvalidSquares, playable, startSquare);
                if (NewMove != null)
                {
                    Output.Add(NewMove);
                }
            }

            return Output.ToArray();
        }

        public static Move[] WithStartSquare(Board b, Player p, int startSquare)
        {
            char Colour = p.Colour;
            List<Move> Output = new List<Move>();
            foreach (Piece piece in p.AvaliablePieces)
            {
                Move[] temp = WithPieceAndStartSquare(b, piece, startSquare, Colour);
                foreach (Move m in temp)
                {
                    Output.Add(m);
                }
            }
            return Output.ToArray();
        }

        public static Move[] WithPiece(Board b, Piece p, char colour)
        {
            int[] StartSquares = FindStartSquares.FindInt(b, colour);
            List<Move> Output = new List<Move>();

            foreach (int startSquare in StartSquares)
            {
                Move[] temp = WithPieceAndStartSquare(b, p, startSquare, colour);
                foreach (Move m in temp)
                {
                    Output.Add(m);
                }
            }

            return Output.ToArray();
        }

        public static Move[] AllMoves(Board b, Player p)
        {
            char Colour = p.Colour;
            int[] StartSquares = FindStartSquares.FindInt(b, Colour);
            List<Move> Output = new List<Move>();

            foreach (Piece piece in p.AvaliablePieces)
            {
                Move[] temp = WithPiece(b, piece, Colour);
                foreach (Move m in temp)
                {
                    Output.Add(m);
                }
            }

            return Output.ToArray();
        }

        private static Move Base(bool[] occupiedSquares, Playable p, int startSquare)
        {
            return p.ToMove(startSquare, occupiedSquares);
        }
    }
}
