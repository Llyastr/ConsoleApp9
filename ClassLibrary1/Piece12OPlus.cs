using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece12OPlus: Piece
    {
        public Piece12OPlus(string Name = "OPlus", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 1, 7, 5));
            Playables.Add(new Playable(1, 1, 3, 5));
            Playables.Add(new Playable(7, 1, 3, 3));
            Playables.Add(new Playable(3, 1, 7, 7));
            Playables.Add(new Playable(1, 4, 1, 1));
            Playables.Add(new Playable(1, 6, 1, 1));
            Playables.Add(new Playable(3, 1, 7, 1));
            Playables.Add(new Playable(7, 1, 3, 1));
            AddRotations();
        }
    }
}
