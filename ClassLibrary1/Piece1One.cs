using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece1One : Piece
    {
        public Piece1One(string Name = "One", int Length = 1) : base(Name, Length)
        {
            Playables.Add(new Playable());
        }
    }
}
