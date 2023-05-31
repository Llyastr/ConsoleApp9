using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Piece
    {
        public string Name;
        public int Number;
        public int Length;
        public List<Playable> Playables = new List<Playable>();

        public Piece(string name, int length, int number)
        {
            Name = name;
            Length = length;
            Number = number;
        }

        public void AddRotations()
        {
            List<Playable> ToAdd = new List<Playable>();
            foreach (Playable p in Playables)
            {
                ToAdd.Add(new Playable(p, 2));
                ToAdd.Add(new Playable(p, 4));
                ToAdd.Add(new Playable(p, 6));
            }
            Playables.AddRange(ToAdd);
        }
    }
}
