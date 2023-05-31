using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece21TallStraight: Piece
    {
        public Piece21TallStraight(string Name = "TallStraight", int Length = 5, int Number = 21) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(21, 1, 1, 1, 6));
            Playables.Add(new Playable(21, 1, 1, 1, 4));
            Playables.Add(new Playable(21, 8, 3, 3, 3));
            Playables.Add(new Playable(21, 2, 7, 7, 7));
            Playables.Add(new Playable(21, 8, 3, 1, 1));
            Playables.Add(new Playable(21, 2, 7, 1, 1));
            AddRotations();
        }
    }
}
