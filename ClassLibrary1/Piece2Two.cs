using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece2Two : Piece
    {
        public Piece2Two(string Name = "Two", int Length = 2) : base(Name, Length)
        {
            Playables.Add(new Playable(1));
            AddRotations();
        }
    }
}
