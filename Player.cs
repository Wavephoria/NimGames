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

        public static void PlayerMove(string userInput)
        {
            // To be implemented
        }

        public static void NextPlayer(string currentPlayer)
        {
            // To be implemented
        }

        public static void UpdateScore(string currentPlayer, Player player)
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




        public static void EndGame()
        {

        }

    }
}
