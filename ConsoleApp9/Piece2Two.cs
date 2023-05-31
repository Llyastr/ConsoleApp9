using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece2Two : Piece
    {
        public Piece2Two(string Name = "Two", int Length = 2, int Number = 2) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(2, 1));
            AddRotations();
        }
    }
}
