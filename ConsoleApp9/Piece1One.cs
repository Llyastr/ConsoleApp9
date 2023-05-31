using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece1One : Piece
    {
        public Piece1One(string Name = "One", int Length = 1, int Number = 1) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(1));
        }
    }
}
