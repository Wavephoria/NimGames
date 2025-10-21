using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal class AI
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Difficulty { get; set; }

        public AI(string name, string difficulty) 
        { 
            this.Name = name;
            this.Difficulty = difficulty;
            this.Wins = 0;
            this.Losses = 0;
        }

        
    }
}
