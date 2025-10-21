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

        static void MakeMove()
        {

            Random rand = new Random();
            int pileIndex = rand.Next(0, 3); // Assuming there are 3 piles
            int sticksToRemove = rand.Next(1, 6); // Remove between 1 and 5 sticks

        }
    }
}
