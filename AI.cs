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
        public string Difficulty { get; set; }

        public AI(string name) 
        { 
            this.Name = name;
            this.Difficulty = "easy";
            this.Wins = 0;
            this.Losses = 0;
        }

        public static string MakeMoveComputer(int[][] board)
        {
            bool validMove = false;
            string computerMove = "";
            Random rand = new Random();



            while (!validMove)
            {

                int pileIndex = rand.Next(0, 3); // Assuming there are 3 piles
                int sticksLeft = board[pileIndex].Length;

                if (sticksLeft == 0)
                {
                    continue; // Pick another pile if this one is empty
                }
                else 
                { 
                    int sticksToRemove = rand.Next(1, Math.Min(6, sticksLeft + 1)); // Remove between 1 and 5 sticks, but not more than available
                    computerMove = $"{pileIndex + 1} {sticksToRemove}";
                    validMove = true;
                }

            }

            return computerMove;

        }

        public static void UpdateScore(string currentPlayer, AI player)
        {
            if (currentPlayer == player.Name)
            {
                Console.WriteLine($"Congratulations on the win {player.Name}!");
                player.Wins++;
            }
            else
            {
                player.Losses++;
            }
        }
    }
}
