using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece8TetriminoS : Piece
    {
        public Piece8TetriminoS(string Name = "TetriminoS", int Length = 4) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 3, 1));
            Playables.Add(new Playable(1, 7, 1));
            Playables.Add(new Playable(3, 8, 7));
            Playables.Add(new Playable(7, 2, 3));
            AddRotations();
        }
    }
}
