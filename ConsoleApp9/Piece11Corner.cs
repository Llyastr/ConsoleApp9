using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece11Corner: Piece
    {
        public Piece11Corner(string Name = "Corner", int Length = 3, int Number = 11) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(11, 1, 7));
            Playables.Add(new Playable(11, 1, 3));
            Playables.Add(new Playable(11, 1, 6));
            AddRotations();
        }
    }
}
