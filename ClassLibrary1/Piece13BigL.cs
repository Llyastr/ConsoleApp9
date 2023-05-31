using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece13BigL: Piece
    {
        public Piece13BigL(string Name = "BigL", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 1, 7, 7));
            Playables.Add(new Playable(1, 1, 3, 3));
            AddRotations();
            Playables.Add(new Playable(7, 2, 1, 9));
            Playables.Add(new Playable(3, 8, 1, 10));
            Playables.Add(new Playable(5, 2, 3, 9));
            Playables.Add(new Playable(5, 8, 7, 10));
        }
    }
}
