using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece13BigL: Piece
    {
        public Piece13BigL(string Name = "BigL", int Length = 5, int Number = 13) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(13, 1, 1, 7, 7));
            Playables.Add(new Playable(13, 1, 1, 3, 3));
            AddRotations();
            Playables.Add(new Playable(13, 7, 2, 1, 9));
            Playables.Add(new Playable(13, 3, 8, 1, 10));
            Playables.Add(new Playable(13, 5, 2, 3, 9));
            Playables.Add(new Playable(13, 5, 8, 7, 10));
        }
    }
}
