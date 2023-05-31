using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece10Plus: Piece
    {
        public Piece10Plus(string Name = "Plus", int Length = 5, int Number = 10) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(10, 1, 7, 2, 4));
            AddRotations();
        }
    }
}
