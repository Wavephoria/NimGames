using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal class Player : IPlayer
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Wins = 0;
            this.Losses = 0;
        }

        // Overriding ToString to show the current name of player to display when ending the game
        public override string ToString() { return Name; }
    }
}
