using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class FindStartSquares
    {
        public static int[] FindInt(Board b, char colour)
        {
            bool[] BoolArray = Find(b, colour);
            List<int> temp = new List<int>();

            for (int i = 0; i <= 399; i++)
            {
                if (BoolArray[i])
                {
                    temp.Add(i);
                }
            }

            return temp.ToArray();
        }

        public static bool[] Find(Board b, char colour)
        {
            bool[] ColoursSquares = b.GetSquaresForColour[colour];
            bool[] AllInvalidSquares = FindInvalidSquares.Find(b, colour);

            bool[] StartSquares = new bool[400];

            if (Check(0, ColoursSquares, AllInvalidSquares, 21) == true)
            {
                StartSquares[0] = true;
            }
            for (int i = 1; i <= 18; i++)
            {
                //check top row
                if (Check(i, ColoursSquares, AllInvalidSquares, 19, 21) == true)
                {
                    StartSquares[i] = true;
                }
            }
            if (Check(19, ColoursSquares, AllInvalidSquares, 19) == true)
            {
                StartSquares[19] = true;
            }
            for (int i = 20; i <= 379; i++)
            {
                if (i % 20 == 19)
                {
                    //check right
                    if (Check(i, ColoursSquares, AllInvalidSquares, -21, 19) == true)
                    {
                        StartSquares[i] = true;
                    }
                }
                else if (i % 20 == 0)
                {
                    //check left
                    if (Check(i, ColoursSquares, AllInvalidSquares, -19, 21) == true)
                    {
                        StartSquares[i] = true;
                    }
                }
                else
                {
                    if (Check(i, ColoursSquares, AllInvalidSquares, -21, -19, 19, 21) == true)
                    {
                        StartSquares[i] = true;
                    }
                }
            }
            if (Check(380, ColoursSquares, AllInvalidSquares, -19) == true)
            {
                StartSquares[380] = true;
            }
            for (int i = 380; i <= 398; i++)
            {
                //check bottom row
                if (Check(i, ColoursSquares, AllInvalidSquares, -21, -19) == true)
                {
                    StartSquares[i] = true;
                }
            }
            if (Check(399, ColoursSquares, AllInvalidSquares, -21) == true)
            {
                StartSquares[399] = true;
            }

            return StartSquares;
        }

        private static bool Check(int square, bool[] coloursSquares, bool[] allInvalidSquares, params int[] offsets)
        {
            //true if square is valid
            //direction -21 = top left; -19 = top right; +21 = bottom right; +19 = bottom left
            if (allInvalidSquares[square] == true)
            {
                return false;
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
