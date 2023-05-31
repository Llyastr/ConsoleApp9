using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece18Australia: Piece
    {
        public Piece18Australia(string Name = "Australia", int Length = 5, int Number = 18) : base(Name, Length, Number)
        {
            Playables.Add(new Playable(18, 1, 7, 7, 2));
            Playables.Add(new Playable(18, 1, 3, 3, 8));
            Playables.Add(new Playable(18, 3, 8, 7, 2));
            Playables.Add(new Playable(18, 7, 2, 3, 8));
            Playables.Add(new Playable(18, 8, 3, 3, 1));
            Playables.Add(new Playable(18, 2, 7, 7, 1));
            Playables.Add(new Playable(18, 2, 7, 1, 7));
            Playables.Add(new Playable(18, 8, 3, 1, 3));
            AddRotations();
        }
    }
}
