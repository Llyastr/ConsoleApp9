using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Hover
    {
        public static void Move(Move m, Board b, int MoveNumber)
        {
            Console.WriteLine("Displaying Move " + MoveNumber  + ": ");
            char[] state = b.CombineSquares();
            foreach (int i in m.Squares)
            {
                state[i] = 'X';
            }
            Print(state);
            Console.WriteLine();
        }

        public static void StartSquares(int[] startSquares, Board b)
        {
            int Index = 1;
            char[] state = b.CombineSquares();

            int count = 20;
            for (int i = 0; i <= 399; i++)
            {
                if (Contains(startSquares, i))
                {
                    if (Index < 10)
                    {
                        Console.Write(Index + "  ");
                    }
                    else
                    {
                        Console.Write(Index + " ");
                    }
                    Index++;
                }
                else
                {
                    switch (state[i])
                    {
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'R':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'Y':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 'G':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    Console.Write(state[i] + "  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                count--;
                if (count == 0)
                {
                    Console.WriteLine();
                    count = 20;
                }
            }
        }

        private static bool Contains(int[] A, int i)
        {
            foreach (int x in A)
            {
                if (x == i)
                {
                    return true;
                }
            }
            return false;
        }

        public static void MoveArray(Move[] moves)
        {
            if (moves.Length == 0)
            {
                Console.WriteLine("No valid moves for this piece");
                Console.WriteLine();
                return;
            }
            int MoveNumber = 1;
            Console.WriteLine("Displaying Moves");
            foreach (Move move in moves)
            {
                Console.Write("Move " + MoveNumber + ": ");
                MoveArrayHelper(move);
                MoveNumber++;
            }
            Console.WriteLine();
        }

        private static void MoveArrayHelper(Move m)
        {
            Console.Write("Using piece #" + m.PieceNumber + ": ");
            foreach (int square in m.Squares)
            {
                Space NewSpace = new Space(square);
                Console.Write("(" + NewSpace.col + ", " + NewSpace.row + ") ");
            }
            Console.WriteLine();
        }

        private static void Print(char[] state)
        {
            int count = 20;
            foreach (char c in state)
            {
                switch (c)
                {
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'R':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'Y':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 'G':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                Console.Write(c + "  ");
                Console.ForegroundColor = ConsoleColor.White;
                count--;
                if (count == 0)
                {
                    Console.WriteLine();
                    count = 20;
                }
            }
        }
    }
}
