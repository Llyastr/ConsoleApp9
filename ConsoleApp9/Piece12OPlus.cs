using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece12OPlus: Piece
    {
        public Piece12OPlus(string Name = "OPlus", int Length = 5, int Number = 12) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(12, 1, 1, 7, 5));
            Playables.Add(new Playable(12, 1, 1, 3, 5));
            Playables.Add(new Playable(12, 7, 1, 3, 3));
            Playables.Add(new Playable(12, 3, 1, 7, 7));
            Playables.Add(new Playable(12, 1, 4, 1, 1));
            Playables.Add(new Playable(12, 1, 6, 1, 1));
            Playables.Add(new Playable(12, 3, 1, 7, 1));
            Playables.Add(new Playable(12, 7, 1, 3, 1));
            AddRotations();
        }
    }
}
