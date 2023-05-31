using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Playable
    {
        int PieceNumber;
        int[] A;

        public Playable(int pn, params int[] dispMethods)
        {
            PieceNumber = pn;
            int L = dispMethods.Length;
            if (L > 0)
            {
                A = new int[L];
                for (int i = 0; i < L; i++)
                {
                    A[i] = dispMethods[i];
                }
            }
            else
            {
                A = new int[0];
            }
        }

        public Playable(Playable p, int rotation)
        {
            PieceNumber = p.PieceNumber;
            int L = p.A.Length;
            A = new int[L];
            for(int i = 0; i < L; i++)
            {
                A[i] = p.A[i] + rotation;
                if (A[i] > 8)
                {
                    A[i] = A[i] % 8;
                }
            }
        }

        public Move ToMove(int startSquare, bool[] occupiedSquares)
        {
            // will return null if move is off the board or on an occupied square
            int[] Squares = ToSquares(startSquare);
            Move NewMove = new Move(PieceNumber, Squares);
            if (Squares == null || !CheckValid(occupiedSquares, NewMove))
            {
                return null;
            }
            return NewMove;
        }

        private bool CheckValid(bool[] occupiedSquares, Move m)
        {
            foreach (int square in m.Squares)
            {
                if (occupiedSquares[square])
                {
                    return false;
                }
            }
            return true;
        }

        private int[] ToSquares(int startSquare)
        {
            Space[] Spaces = ToSpaces(startSquare);

            int[] Output = new int[A.Length + 1];
            if  (Spaces == null)
            {
                return null;
            }
            int Pointer = 0;
            foreach (Space s in Spaces)
            {
                Output[Pointer] = s.ToSquare();
                Pointer++;
            }
            return Output;
        }

        private Space[] ToSpaces(int startSquare)
        {
            Space CurrentSpace = new Space(startSquare);
            int Max = A.Length;
            Space[] Output = new Space[Max + 1];

            Output[0] = new Space(CurrentSpace);
            for (int Pointer = 0; Pointer < Max; Pointer++)
            {
                CurrentSpace.Shift(A[Pointer]);
                Output[Pointer + 1] = new Space(CurrentSpace);

                if (CurrentSpace.Out())
                {
                    return null;
                }
            }

            return Output;
        }
    }
}
