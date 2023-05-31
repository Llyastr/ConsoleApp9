using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece6TetriminoL : Piece
    {
        public Piece6TetriminoL(string Name = "TetriminoL", int Length = 4, int Number = 6) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(6, 1, 1, 3));
            Playables.Add(new Playable(6, 1, 1, 7));
            Playables.Add(new Playable(6, 1, 7, 7));
            Playables.Add(new Playable(6, 1, 3, 3));
            Playables.Add(new Playable(6, 3, 8, 1));
            Playables.Add(new Playable(6, 7, 2, 1));
            AddRotations();
        }
    }
}
