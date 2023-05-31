using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece15BigT: Piece
    {
        public Piece15BigT(string Name = "BigT", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 8, 3, 3));
            Playables.Add(new Playable(1, 1, 6, 7));
            Playables.Add(new Playable(1, 1, 4, 3));
            AddRotations();
        }
    }
}
