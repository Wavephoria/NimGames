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
            GameBoard = new int[3][];
            GameBoard[0] = new int[] { 1, 1, 1, 1, 1 };
            GameBoard[1] = new int[] { 1, 1, 1, 1, 1 };
            GameBoard[2] = new int[] { 1, 1, 1, 1, 1 };
        }

        public void DisplayBoard(int[][] board) 
        {
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

        public bool ErrorChecks(int[][] board, int row, int amount) 
        {
            int chosenRow = row - 1;       

            return chosenRow >= 0 && chosenRow < board.GetLength(0) &&
                   amount >= 0 && amount <= board[chosenRow].Length;
        }

        public void UpdateBoard(int[][] board, int row, int amount) 
        
        { 
            int chosenRow = row - 1;

            board[chosenRow] = new int[board[chosenRow].Length - amount];

        }
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

            if (sticksLeft > 0) { return true; }
            else { return false; }
        }
    }
}
