using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece14W: Piece
    {
        public Piece14W(string Name = "W", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 7, 1, 7));
            Playables.Add(new Playable(1, 3, 1, 3));
            Playables.Add(new Playable(3, 8, 7, 1));
            Playables.Add(new Playable(7, 2, 3, 1));
            Playables.Add(new Playable(4, 1, 8, 7));
            Playables.Add(new Playable(6, 1, 2, 3));
            AddRotations();
        }
    }
}
