using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece9TetriminoO: Piece
    {
        public Piece9TetriminoO(string Name = "TetriminoO", int Length = 4, int Number = 9) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(9, 1, 3, 5));
            AddRotations();
        }
    }
}
