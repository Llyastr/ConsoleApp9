using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    abstract class Player
    {
        public string ID;
        public char Colour;
        public List<Piece> AvaliablePieces = new List<Piece>();
        public bool Finished = false;

        private Dictionary<int, Piece> AllPieces = new Dictionary<int, Piece>();

        public Player(Player p)
        {
            Colour = p.Colour;

            AllPieces.Add(1, new Piece1One());
            AllPieces.Add(2, new Piece2Two());
            AllPieces.Add(3, new Piece3Three());
            AllPieces.Add(4, new Piece4Four());
            AllPieces.Add(5, new Piece5Five());
            AllPieces.Add(6, new Piece6TetriminoL());
            AllPieces.Add(7, new Piece7TetriminoT());
            AllPieces.Add(8, new Piece8TetriminoS());
            AllPieces.Add(9, new Piece9TetriminoO());
            AllPieces.Add(10, new Piece10Plus());
            AllPieces.Add(11, new Piece11Corner());
            AllPieces.Add(12, new Piece12OPlus());
            AllPieces.Add(13, new Piece13BigL());
            AllPieces.Add(14, new Piece14W());
            AllPieces.Add(15, new Piece15BigT());
            AllPieces.Add(16, new Piece16U());
            AllPieces.Add(17, new Piece17LongL());
            AllPieces.Add(18, new Piece18Australia());
            AllPieces.Add(19, new Piece19BigS());
            AllPieces.Add(20, new Piece20TallCurved());
            AllPieces.Add(21, new Piece21TallStraight());

            foreach (Piece piece in p.AvaliablePieces)
            {
                AvaliablePieces.Add(piece);
            }
        }

        public Player(char colour)
        {
            Colour = colour;

            AllPieces.Add(1, new Piece1One());
            AllPieces.Add(2, new Piece2Two());
            AllPieces.Add(3, new Piece3Three());
            AllPieces.Add(4, new Piece4Four());
            AllPieces.Add(5, new Piece5Five());
            AllPieces.Add(6, new Piece6TetriminoL());
            AllPieces.Add(7, new Piece7TetriminoT());
            AllPieces.Add(8, new Piece8TetriminoS());
            AllPieces.Add(9, new Piece9TetriminoO());
            AllPieces.Add(10, new Piece10Plus());
            AllPieces.Add(11, new Piece11Corner());
            AllPieces.Add(12, new Piece12OPlus());
            AllPieces.Add(13, new Piece13BigL());
            AllPieces.Add(14, new Piece14W());
            AllPieces.Add(15, new Piece15BigT());
            AllPieces.Add(16, new Piece16U());
            AllPieces.Add(17, new Piece17LongL());
            AllPieces.Add(18, new Piece18Australia());
            AllPieces.Add(19, new Piece19BigS());
            AllPieces.Add(20, new Piece20TallCurved());
            AllPieces.Add(21, new Piece21TallStraight());

            for (int i = 1; i <= 21; i++)
            {
                AvaliablePieces.Add(AllPieces[i]);
            }
        }

        public int NumberOfPiecesRemaining()
        {
            return AvaliablePieces.Count;
        }

        public void RemovePiece(int n)
        {
            foreach (Piece p in AvaliablePieces)
            {
                if(p.Number == n)
                {
                    AvaliablePieces.Remove(p);
                    return;
                }
            }
        }

        public void AddPiece(int n)
        {
            AvaliablePieces.Add(AllPieces[n]);
        }

        public void DisplayAvaliablePieces()
        {
            int index = 1;
            foreach (Piece p in AvaliablePieces)
            {
                Console.WriteLine(index + ". " + p.Name);
                index++;
            }
            Console.WriteLine();
        }

        public void MakeMove(Board b, Move m)
        {
            foreach (int space in m.Squares)
            {
                b.Add(space, Colour);
            }
            RemovePiece(m.PieceNumber);
        }

        public void UnmakeMove(Board b, Move m)
        {
            foreach (int space in m.Squares)
            {
                b.Remove(space, Colour);
            }
            AddPiece(m.PieceNumber);
        }

        public void Finish()
        {
            Finished = true;
        }

        public int CalculateScore()
        {
            int Score = 0;
            foreach (Piece p in AvaliablePieces)
            {
                Score += p.Length;
            }
            return Score;
        }

        public abstract bool DoTurn(Board b);

        public abstract void DoFirstTurn(Board b, int startSquare);
    }
}
