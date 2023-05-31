﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece7TetriminoT : Piece
    {
        public Piece7TetriminoT(string Name = "TetriminoT", int Length = 4) : base(Name, Length)
        {
            Playables.Add(new Playable(1, 7, 2));
            Playables.Add(new Playable(1, 3, 8));
            Playables.Add(new Playable(8, 3, 3));
            AddRotations();
        }
    }
}
