using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece11Corner: Piece
    {
        public Piece11Corner(string Name = "Corner", int Length = 3) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 7));
            Playables.Add(new Playable(1, 3));
            AddRotations();
        }
    }
}
