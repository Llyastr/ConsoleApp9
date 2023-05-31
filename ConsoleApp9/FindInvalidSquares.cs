using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class FindInvalidSquares
    {
        public static bool[] Find(Board b, char colour)
        {
            bool[] ColoursSquares = b.GetSquaresForColour[colour];
            bool[] AllOccupiedSquares = b.GetAllOccupiedSquares();

            bool[] InvalidSquares = new bool[400];

            if (Check(0, ColoursSquares, AllOccupiedSquares, 1, 20) == true)
            {
                InvalidSquares[0] = true;
            }
            for (int i = 1; i <= 18; i++)
            {
                //check top row
                if (Check(i, ColoursSquares, AllOccupiedSquares, 1, 20, -1) == true)
                {
                    InvalidSquares[i] = true;
                }
            }
            if (Check(19, ColoursSquares, AllOccupiedSquares, 20, -1) == true)
            {
                InvalidSquares[19] = true;
            }
            for (int i = 20; i <= 379; i++)
            {
                if(i % 20 == 19)
                {
                    //check right
                    if (Check(i, ColoursSquares, AllOccupiedSquares, -20, 20, -1) == true)
                    {
                        InvalidSquares[i] = true;
                    }
                }
                else if(i % 20 == 0)
                {
                    //check left
                    if (Check(i, ColoursSquares, AllOccupiedSquares, -20, 1, 20) == true)
                    {
                        InvalidSquares[i] = true;
                    }
                }
                else
                {
                    if (Check(i, ColoursSquares, AllOccupiedSquares, -20, 1, 20, -1) == true)
                    {
                        InvalidSquares[i] = true;
                    }
                }
            }
            if (Check(380, ColoursSquares, AllOccupiedSquares, -20, 1) == true)
            {
                InvalidSquares[380] = true;
            }
            for (int i = 380; i <= 398; i++)
            {
                //check bottom row
                if (Check(i, ColoursSquares, AllOccupiedSquares, -20, 1,-1) == true)
                {
                    InvalidSquares[i] = true;
                }
            }
            if (Check(399, ColoursSquares, AllOccupiedSquares, -20, -1) == true)
            {
                InvalidSquares[399] = true;
            }

            return InvalidSquares;
        }

        private static bool Check(int square, bool[] coloursSquares, bool[]allOccupiedSquares, params int[] offsets)
        {
            //true if square is invalid
            //direction -20 = up; +1 = right; +20 = down; -1 = left
            if (allOccupiedSquares[square] == true)
            {
                return true;
            }
            int[] AdjacentSquares = new int[offsets.Length];
            int Pointer = 0;
            foreach (int d in offsets)
            {
                AdjacentSquares[Pointer] = square + d;
                Pointer++;
            }
            foreach (int s in AdjacentSquares)
            {
                if (coloursSquares[s] == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
