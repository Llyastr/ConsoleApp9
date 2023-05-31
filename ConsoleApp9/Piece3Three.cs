using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece3Three: Piece
    {
        public Piece3Three(string Name = "Three", int Length = 3, int Number = 3) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(3, 1, 1));
            AddRotations();
        }
    }
}
