using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece20TallCurved: Piece
    {
        public Piece20TallCurved(string Name = "TallCurved", int Length = 5, int Number = 20) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(20, 1, 1, 3, 1));
            Playables.Add(new Playable(20, 1, 1, 7, 1));
            Playables.Add(new Playable(20, 8, 3, 4, 3));
            Playables.Add(new Playable(20, 2, 7, 6, 7));
            Playables.Add(new Playable(20, 7, 2, 3, 3));
            Playables.Add(new Playable(20, 3, 8, 7, 7));
            Playables.Add(new Playable(20, 1, 3, 1, 1));
            Playables.Add(new Playable(20, 1, 7, 1, 1));
            AddRotations();
        }
    }
}
