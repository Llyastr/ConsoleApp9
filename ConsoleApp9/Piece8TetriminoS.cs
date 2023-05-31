using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece8TetriminoS : Piece
    {
        public Piece8TetriminoS(string Name = "TetriminoS", int Length = 4, int Number = 8) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(8, 1, 3, 1));
            Playables.Add(new Playable(8, 1, 7, 1));
            Playables.Add(new Playable(8, 3, 8, 7));
            Playables.Add(new Playable(8, 7, 2, 3));
            AddRotations();
        }
    }
}
