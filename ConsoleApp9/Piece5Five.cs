using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece5Five : Piece
    {
        public Piece5Five(string Name = "Five", int Length = 5, int Number = 5) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(5, 1, 1, 1, 1));
            AddRotations();
        }
    }
}
