using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece4Four : Piece
    {
        public Piece4Four(string Name = "Four", int Length = 4) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 1, 1));
            AddRotations();
        }
    }
}
