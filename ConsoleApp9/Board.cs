using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Board
    {
        bool[] RedSquares = new bool[400];
        bool[] BlueSquares = new bool[400];
        bool[] GreenSquares = new bool[400];
        bool[] YellowSquares = new bool[400];

        public Dictionary<char, bool[]> GetSquaresForColour = new Dictionary<char, bool[]>();

        public Board()
        {
            GetSquaresForColour.Add('R', RedSquares);
            GetSquaresForColour.Add('B', BlueSquares);
            GetSquaresForColour.Add('G', GreenSquares);
            GetSquaresForColour.Add('Y', YellowSquares);
        }

        public void Add(int position, char colour)
        {
            GetSquaresForColour[colour][position] = true;
        }

        public void Remove(int position, char colour)
        {
            GetSquaresForColour[colour][position] = false;
        }

        public void Remove(int position)
        {
            RedSquares[position] = false;
            BlueSquares[position] = false;
            GreenSquares[position] = false;
            YellowSquares[position] = false;
        }

        public void Print()
        {
            char[] state = CombineSquares();
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

        public void PrintOverride()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            char[] state = CombineSquares();
            int count = 20;
            int ColumnCount = 1;
            PrintColumnNumber();
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
                Console.ForegroundColor = ConsoleColor.Gray;
                count--;
                if (count == 0)
                {
                    Console.WriteLine();
                    PrintColumnNumber();
                    count = 20;
                }
            }
            Console.WriteLine("    1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20");
            Console.WriteLine();

            void PrintColumnNumber()
            {
                if (ColumnCount < 10)
                {
                    Console.Write(ColumnCount + " : ");
                }
                else
                {
                    if (ColumnCount <= 20)
                    {
                        Console.Write(ColumnCount + ": ");
                    }
                }
                ColumnCount++;
            }
        }

        public bool[] GetOtherSquares(char colour)
        {
            bool[] temp = GetAllOccupiedSquares();
            bool[] ColoursSquares = GetSquaresForColour[colour];
            for (int i = 0; i < 400; i++)
            {
                if (ColoursSquares[i] == true)
                {
                    temp[i] = false;
                }
            }
            return temp;
        }

        public bool[] GetAllOccupiedSquares()
        {
            bool[] temp = new bool[400];
            for (int i = 0; i < 400; i++)
            {
                if(RedSquares[i] == true || BlueSquares[i] == true || GreenSquares[i] == true || YellowSquares[i] == true)
                {
                    temp[i] = true;
                }
            }
            return temp;
        }

        public char[] CombineSquares()
        {
            char[] temp = new char[400];
            for (int i = 0; i < 400; i++)
            {
                temp[i] = '-';
            }
            AddSquaresOfColour(RedSquares, 'R', temp);
            AddSquaresOfColour(BlueSquares, 'B', temp);
            AddSquaresOfColour(GreenSquares, 'G', temp);
            AddSquaresOfColour(YellowSquares, 'Y', temp);
            return temp;
        }

        private void AddSquaresOfColour(bool[] Squares, char colour, char[] b)
        {
            int i = 0;
            foreach(bool square in Squares)
            {
                if(square)
                {
                    b[i] = colour;
                }
                i++;
            }
        }
    }
}
