using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NimGames
{
    internal class Board
    {
        public int[][] GameBoard { get; }

        public Board() 
        {
            // When creating an instance of the game, it creates a jagged array. This worked the best for our logic to use 
            GameBoard = new int[3][];
            GameBoard[0] = new int[] { 1, 1, 1, 1, 1 };
            GameBoard[1] = new int[] { 1, 1, 1, 1, 1 };
            GameBoard[2] = new int[] { 1, 1, 1, 1, 1 };
        }
        // Method for displaying the board
        public void DisplayBoard(int[][] board) 
        {
            // It loops through the board and for every spot it created a | to show on console
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                Console.Write($"Row {i+1}");

                foreach (int x in board[i]) 
                { 
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }

        // Error checking if the current input is valid for current board state
        public bool ErrorChecks(int[][] board, int row, int amount) 
        {
            // You have to pick atleast one stick, if you choose 0, you have to make a new choice
            if (amount == 0) { return false; }

            // If a number is being picked, it looks at the current pile and the current sticks in it, returns either true or false
            // depending on the result of the check
            else
            {
                int chosenRow = row - 1;
                return chosenRow >= 0 && chosenRow < board.GetLength(0) &&
                       amount >= 0 && amount <= board[chosenRow].Length;
            }
        }

        // Updating the current board state after a move has been complete
        public void UpdateBoard(int[][] board, int row, int amount) 
        { 
            int chosenRow = row - 1;
            board[chosenRow] = new int[board[chosenRow].Length - amount];
        }

        // Checking if there is any sticks left to pick from the board
        public bool SticksLeft(int[][] board) 
        {
            int sticksLeft = 0;
            
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                foreach (int x in board[i])
                {
                    sticksLeft++;
                }
            }

            // Returns true if stick left and false if not
            if (sticksLeft > 0) { return true; }
            else { return false; }
        }
    }
}
