using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece9TetriminoO: Piece
    {
        public Piece9TetriminoO(string Name = "TetriminoO", int Length = 4) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 3, 5));
            AddRotations();
        }
    }
}
