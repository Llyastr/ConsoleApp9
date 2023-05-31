using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece18Australia: Piece
    {
        public Piece18Australia(string Name = "Australia", int Length = 5) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 7, 7, 2));
            Playables.Add(new Playable(1, 3, 3, 8));
            Playables.Add(new Playable(3, 8, 7, 2));
            Playables.Add(new Playable(7, 2, 3, 8));
            Playables.Add(new Playable(8, 3, 3, 1));
            Playables.Add(new Playable(2, 7, 7, 1));
            Playables.Add(new Playable(2, 7, 1, 7));
            Playables.Add(new Playable(8, 3, 1, 3));
            AddRotations();
        }
    }
}
