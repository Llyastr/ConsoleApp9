using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece16U: Piece
    {
        public Piece16U(string Name = "U", int Length = 5, int Number = 16) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(16, 1, 7, 7, 5));
            Playables.Add(new Playable(16, 1, 3, 3, 5));
            Playables.Add(new Playable(16, 1, 6, 7, 1));
            Playables.Add(new Playable(16, 1, 4, 3, 1));
            AddRotations();
        }
    }
}
