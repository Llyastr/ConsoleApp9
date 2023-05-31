using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece17LongL: Piece
    {
        public Piece17LongL(string Name = "LongL", int Length = 5, int Number = 17) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(17, 1, 1, 1, 7));
            Playables.Add(new Playable(17, 1, 1, 1, 3));
            Playables.Add(new Playable(17, 1, 7, 7, 7));
            Playables.Add(new Playable(17, 1, 3, 3, 3));
            Playables.Add(new Playable(17, 7, 2, 1, 1));
            Playables.Add(new Playable(17, 3, 8, 1, 1));
            AddRotations();
        }
    }
}
