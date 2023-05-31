using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Move
    {
        public int PieceNumber;
        public int[] Squares;
        public int Size;

        public Move(int p, int[] squares)
        {
            PieceNumber = p;
            Squares = squares;
            if (Squares != null)
            {
                Size = Squares.Length;
            }
        }
    }
}
