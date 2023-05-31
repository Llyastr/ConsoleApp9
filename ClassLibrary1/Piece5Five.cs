using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece5Five : Piece
    {
        public Piece5Five(string Name = "Five", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 1, 1, 1));
            AddRotations();
        }
    }
}
