using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal class AI : IPlayer
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public AI(string name)
        {
            this.Name = name;
            this.Wins = 0;
            this.Losses = 0;
        }

        // Method for making a move for AI
        public static string MakeMoveComputer(int[][] board)
        {
            // Variables needed for making the logic work for AI movement
            bool validMove = false;
            string computerMove = "";
            Random rand = new Random();

            // Looping until AI makes a valid decision
            while (!validMove)
            {
                // AI choosing first a random pile
                int pileIndex = rand.Next(0, 3);
                // Make calculation if pile has any sticks left
                int sticksLeft = board[pileIndex].Length;

                // If pile has no sticks left, it goes back to make a new random decision for a pile
                if (sticksLeft == 0)
                {
                    continue;
                }
                else
                {
                    // If pile has sticks left, AI makes a random choice between minimum of 1 and maximum of 5 or how many sticks is left
                    int sticksToRemove = rand.Next(1, Math.Min(6, sticksLeft + 1)); 
                    computerMove = $"{pileIndex + 1} {sticksToRemove}";
                    validMove = true;
                }
            }
            // Returns the value AI has chosen
            return computerMove;

        }

        // Overriding ToString to write out who won the match in program
        public override string ToString() { return $"the Computer"; }
    }
}
