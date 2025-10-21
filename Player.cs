using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal class Player
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
    }
}
