using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class TurnCount
    {
        public Player Turn;

        public int Count = 0;

        public Dictionary<int, Player> InitialPlayers = new Dictionary<int, Player>();

        public TurnCount(Player p1, Player p2, Player p3, Player p4)
        {
            InitialPlayers.Add(0, p1);
            InitialPlayers.Add(1, p2);
            InitialPlayers.Add(2, p3);
            InitialPlayers.Add(3, p4);

            Turn = p1;
        }

        public void Toggle()
        {
            Count++;
            SetFromCount();
        }

        private void SetFromCount()
        {
            int p1 = Count % 4;
            Turn = InitialPlayers[p1];
        }
    }
}
