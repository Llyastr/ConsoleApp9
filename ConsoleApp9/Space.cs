using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Space
    {
        public int col;
        public int row;

        public Space(int Col, int Row)
        {
            col = Col;
            row = Row;
        }

        public Space(Space s)
        {
            col = s.col;
            row = s.row;
        }

        public Space(int square)
        {
            int temp = (square + 1) % 20;
            if (temp == 0)
            {
                temp = 20;
                col = 20;
            }
            else
            {
                col = temp;
            }
            row = ((square + 1 - temp) / 20 + 1);
        }

        public int ToSquare()
        {
            return (20 * (row - 1)) + (col - 1);
        }

        public bool Out()
        {
            return (col < 1 || col > 20 || row < 1 || row > 20);
        }

        public void Shift(int dispMethod)
        {
            ShiftHelper(new Translate(dispMethod));
        }

        private void ShiftHelper(Translate t)
        {
            col = col + t.x;
            row = row + t.y;
        }
    }
}
