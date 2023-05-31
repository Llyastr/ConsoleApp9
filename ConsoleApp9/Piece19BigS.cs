using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece19BigS: Piece
    {
        public Piece19BigS(string Name = "BigS", int Length = 5, int Number = 19) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(19, 1, 7, 7, 1));
            Playables.Add(new Playable(19, 1, 3, 3, 1));
            Playables.Add(new Playable(19, 3, 8, 1, 7));
            Playables.Add(new Playable(19, 7, 2, 1, 3));
            AddRotations();
        }
    }
}
