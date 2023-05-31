using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece3Three: Piece
    {
        public Piece3Three(string Name = "Three", int Length = 3) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 1));
            AddRotations();
        }
    }
}
