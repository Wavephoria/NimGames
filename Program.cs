using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NimGames
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Nim game made by Jens Gustafsson and Kasper Rosén
            // Submitted on 23/10-25
            // Virtual studio version 17.14.9 (July 2025)


            // Variables used for logic in program, first for keeping program playing until player wants to quit
            bool playingAgain = true;
            
            // Variables used for keeping track on players in game
            IPlayer currentPlayer = null!;
            IPlayer player2 = null!;

            // Variables used for keeping track of game mode
            bool vsHuman = false;
            bool vsAI = false;
            
            // Making an instance of the class GreetingRules where we keep greetings and rules
            GreetingRules greeting = new GreetingRules();
            greeting.Greeting();
            greeting.Rules();

            // Getting name for player 1 plus errorcheck if no name is being inserted, then creating an instance of the class Player
            Console.WriteLine("What is the name of first player?");
            string userInput = Console.ReadLine()!;
            string input = greeting.PlayerNames(userInput);
            Player player1 = new Player(input);
            
            // Having the user make a choice to play against human or AI
            Console.WriteLine("Do you wanna play against another human? y/n (Wrong input gives you AI opponent)");
            string humanInput = Console.ReadLine()!;
            Console.WriteLine();
            // Creating an instance of player 2 depending on if player wants human or AI opponent
            if (humanInput == "y")
            {
                vsHuman = true;
                Console.WriteLine("What is the name of the second player?");
                userInput = Console.ReadLine()!;
                input = greeting.PlayerNames(userInput);
                player2 = new Player(input);
            }
            else 
            {
                vsAI = true;
                player2 = new AI("Computer");
            }

            // Main loop for the program, plays until player wants to quit
            while (playingAgain) 
            {
                // Bool variable to keep track of if game is over
                bool sticksLeft = true;
                // Creating an instance of class Board
                Board game = new Board();
                // Making player1 the current player in game
                currentPlayer = player1;
                // Variables used later when user makes a move
                int row;
                int amount;

                // Loop for playing the game until no sticks are left
                while (sticksLeft) 
                {
                    // Calling on method the display the current board
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    game.DisplayBoard(game.GameBoard);
                    Console.ResetColor();
                    Console.WriteLine();

                    // Logic for knowing which player is the current player
                    if (currentPlayer == player1) { Console.WriteLine($"Time for {player1.Name} to make a move!"); }
                    else { Console.WriteLine($"Time for {player2.Name} to make a move!"); }

                    string userMove = "";
                    // Check that is a human player that has turn order
                    if (vsHuman || vsAI && currentPlayer == player1)
                    {
                        Console.WriteLine("Which row do you choose and how many sticks?");

                        userMove = Console.ReadLine()!;
                        if (userMove.ToLower() == "aye macarena")
                        {
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("E");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Y");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Y");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Y");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Y");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Y");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("!");
                            Thread.Sleep(150);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("!");
                            Thread.Sleep(150);


                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("!");
                            Thread.Sleep(150);

                            Console.ResetColor();
                            continue;
                        }
                    }
                    // Check if the current player is the AI
                    else 
                    { 
                        Console.WriteLine("The computer is making a move...");
                        // Calling for method for computer the calculate move
                        userMove = AI.MakeMoveComputer(game.GameBoard);
                    }

                    // Error checking if the current input is correct, otherwise a new input has to be made
                    try
                    {
                        string[] inputs = userMove.Split(' ');
                        row = int.Parse(inputs[0]);
                        amount = int.Parse(inputs[1]);
                    }
                    catch
                    {
                        // Throwing error and has the player make a new move
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] You have to write numbers! [ERROR] No space before entering numbers!");
                        Console.ResetColor();
                        continue; 
                    }

                    // Error checking if current input is correct on the current board state
                    if (game.ErrorChecks(game.GameBoard, row, amount))
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Good, now we take away those sticks!");
                        Console.WriteLine();
                        Console.ResetColor();
                        game.UpdateBoard(game.GameBoard, row, amount);
                        sticksLeft = game.SticksLeft(game.GameBoard);

                        // Game ends if there is no sticks left
                        if (!sticksLeft) break;
                        
                        // Switching the current player if there is still sticks left
                        currentPlayer = (currentPlayer == player1) ? player2 : player1;

                    }
                    else 
                    {
                        // If user makes illegal move, user will have a new chance to make a move
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Illegal move! Try again.");
                        Console.ResetColor();
                        continue; 
                    }
                   
                    // sticksLeft = game.SticksLeft(game.GameBoard);

                }

                // Add wins and losses depending on the current player
                if (currentPlayer == player1)
                {
                    player1.Wins++;
                    player2.Losses++;
                }
                else
                { 
                    player1.Losses++;
                    player2.Wins++;
                }

                // Displaying winner and stats for the session
                Console.WriteLine("----------------------");
                Console.WriteLine("Thank you for playing!");
                Console.WriteLine($"The winner is {currentPlayer.ToString()}");
                Console.WriteLine("----------------------");
                Console.WriteLine($"{player1.Name} has {player1.Wins} wins!");
                Console.WriteLine($"{player2.Name} has {player2.Wins} wins!");
                Console.WriteLine();

                // Asking user if they wanna play again, closing if no
                Console.WriteLine("Do you wanna play another game? y/n");
                string endInput = Console.ReadLine()!;
                if (endInput == "n") { playingAgain = false; }
            }
        }
    }
}
