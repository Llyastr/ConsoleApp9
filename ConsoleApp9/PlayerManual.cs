using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class PlayerManual : Player
    {
        public PlayerManual(char colour) : base(colour)
        {
            // Manual Player
            ID = "Manual";
        }

        public override bool DoTurn(Board b)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();
            if (Finished)
            {
                Console.WriteLine("No more valid moves for this player: " + Colour);
                return false;
            }

            Move[] MovesTemp = FindMoves.AllMoves(b, this);
            if (MovesTemp.Length == 0)
            {
                Console.WriteLine("No more valid moves for this player");
                Finish();
                return false;
            }

            Move[] Moves;
            Move CurrentMove;
            while (true)
            {
                Console.WriteLine("Select a Piece:");
                DisplayAvaliablePieces();
                int MaxPiece = NumberOfPiecesRemaining();
                Piece CurrentPiece = AvaliablePieces[GetInput(MaxPiece)];

                int[] StartSquares = FindStartSquares.FindInt(b, Colour);
                Hover.StartSquares(StartSquares, b);
                int MaxStartSquare = StartSquares.Length;
                int CurrentStartSquare = StartSquares[GetInput(MaxStartSquare)];

                Moves = FindMoves.WithPieceAndStartSquare(b, CurrentPiece, CurrentStartSquare, Colour);
                Hover.MoveArray(Moves);
                if (Moves.Length != 0)
                {
                    CurrentMove = CycleMoves(Moves, b);
                    if (CurrentMove != null)
                    {
                        break;
                    }
                }
            }

            MakeMove(b, CurrentMove);
            return true;
        }

        public override void DoFirstTurn(Board b, int initialStart)
        {
            Console.WriteLine();
            Console.WriteLine(Colour + "'s turn");
            b.Print();

            Move[] Moves;
            Move CurrentMove;
            while (true)
            {
                Console.WriteLine("Select a Piece:");
                DisplayAvaliablePieces();
                int MaxPiece = NumberOfPiecesRemaining();
                Piece CurrentPiece = AvaliablePieces[GetInput(MaxPiece)];

                int CurrentStartSquare = initialStart;

                Moves = FindMoves.WithPieceAndStartSquare(b, CurrentPiece, CurrentStartSquare, Colour);
                Hover.MoveArray(Moves);
                if (Moves.Length != 0)
                {
                    CurrentMove = CycleMoves(Moves, b);
                    if (CurrentMove != null)
                    {
                        break;
                    }
                }
            }

            MakeMove(b, CurrentMove);
        }

        private Move CycleMoves(Move[] moves, Board b)
        {
            int Max = moves.Length;
            int Index = 0;
            while (true)
            {
                Hover.Move(moves[Index], b, Index + 1);
                int Input = AskConfirmOrBack();
                if (Input == 1)
                {
                    return moves[Index];
                }
                if (Input == 2)
                {
                    return null;
                }
                if (Input == 3)
                {
                    DoOverrideControl(b);
                    return null;
                }
                Index = (Index + 1) % Max;
            }
        }

        private static int AskConfirmOrBack()
        {
            // 1 is confirm
            // 2 is back
            Console.Write("Type 'Confirm' to confirm or 'Back' to go back: ");
            string temp = Console.ReadLine();
            if (temp == "Confirm" || temp == "c" || temp == "C")
            {
                return 1;
            }
            if (temp == "Back" || temp == "b" || temp == "B")
            {
                return 2;
            }
            if (temp == "Override")
            {
                return 3;
            }
            return 0;
        }

        private static int GetInput(int max)
        {
            int input;
            while (true)
            {
                Console.WriteLine("Enter number from 1 to " + max);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 1 && input <= max)
                    {
                        break;
                    }
                }
                catch
                { }
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine();
            return input - 1;
        }

        private void DoOverrideControl(Board b)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\nOverriding:\n\n");
            int Option = 0;

            b.PrintOverride();
            while (Option != 5)
            {
                switch (Option)
                {
                    case 1:
                        DoRemoveSquare();
                        break;
                    case 2:
                        DoAddOrReplaceSquare();
                        break;
                    case 3:
                        DoAddPiece();
                        break;
                    case 4:
                        DoRemovePiece();
                        break;
                }

                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Remove square");
                Console.WriteLine("2. Add or replace square");
                Console.WriteLine("3. Add piece to current player");
                Console.WriteLine("4. Remove piece from current player");
                Console.WriteLine("5. End Override\n");

                Option = GetInput(5) + 1;
            }
            Console.WriteLine("\n\nOverride Ended:\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            b.Print();

            void DoRemoveSquare()
            {
                Console.WriteLine("Removing square:\n");

                Console.WriteLine("Current board:");
                b.PrintOverride();

                Console.Write("Select column to remove from:");
                int Column = GetInput(20) + 1;
                Console.Write("Select row to remove from:");
                int Row = GetInput(20) + 1;
                Space TempSpace = new Space(Column, Row);
                int Pos = TempSpace.ToSquare();

                b.Remove(Pos);

                Console.WriteLine("Current board:");
                b.PrintOverride();
            }

            void DoAddOrReplaceSquare()
            {
                Console.WriteLine("Adding or replacing square:\n");

                Console.WriteLine("Current board:");
                b.PrintOverride();

                Console.WriteLine("Select column to add to replace to:");
                int Column = GetInput(20) + 1;
                Console.WriteLine("Select row to add or replace to:");
                int Row = GetInput(20) + 1;
                Space TempSpace = new Space(Column, Row);
                int Pos = TempSpace.ToSquare();
                Console.WriteLine("Select colour to add or replace:");
                char C = GetColourInput();

                b.Remove(Pos);
                b.Add(Pos, C);

                Console.WriteLine("Current board:");
                b.PrintOverride();
            }

            void DoAddPiece()
            {
                Console.WriteLine("Adding piece to current player:\n");

                Console.WriteLine("Select piece to add:");
                Console.WriteLine("1.One");
                Console.WriteLine("2.Two");
                Console.WriteLine("3.Three");
                Console.WriteLine("4.Four");
                Console.WriteLine("5.Five");
                Console.WriteLine("6.TetriminoL");
                Console.WriteLine("7.TetriminoT");
                Console.WriteLine("8.TetriminoS");
                Console.WriteLine("9.TetriminoO");
                Console.WriteLine("10.Plus");
                Console.WriteLine("11.Corner");
                Console.WriteLine("12.OPlus");
                Console.WriteLine("13.BigL");
                Console.WriteLine("14.W");
                Console.WriteLine("15.BigT");
                Console.WriteLine("16.U");
                Console.WriteLine("17.LongL");
                Console.WriteLine("18.Australia");
                Console.WriteLine("19.BigS");
                Console.WriteLine("20.TallCurved");
                Console.WriteLine("21.TallStraight");
                int Index = GetInput(21) + 1;
                AddPiece(Index);

                Console.WriteLine("Current players pieces:");
                DisplayAvaliablePieces();
            }

            void DoRemovePiece()
            {
                Console.WriteLine("Removing piece from current player:\n");

                if (AvaliablePieces.Count > 1)
                {
                    Console.WriteLine("Select piece to remove:");
                    DisplayAvaliablePieces();
                    int Index = GetInput(AvaliablePieces.Count);
                    AvaliablePieces.RemoveAt(Index);
                }

                Console.WriteLine("Current players pieces:");
                DisplayAvaliablePieces();
            }

            char GetColourInput()
            {
                string Input;
                while (true)
                {
                    Console.WriteLine("Choose either 'R', 'B', 'G', or 'Y':");
                    Input = Console.ReadLine();
                    if (Input == "R" || Input == "B" || Input == "G" || Input == "Y")
                    {
                        return Convert.ToChar(Input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
    }
}
