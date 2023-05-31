using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece15BigT: Piece
    {
        public Piece15BigT(string Name = "BigT", int Length = 5, int Number = 15) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(15, 1, 8, 3, 3));
            Playables.Add(new Playable(15, 1, 1, 6, 7));
            Playables.Add(new Playable(15, 1, 1, 4, 3));
            AddRotations();
        }
    }
}
