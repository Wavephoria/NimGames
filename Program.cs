using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NimGames
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Playing game of NIM
            // Rules of the game:
            // 3 piles of 5 sticks
            // Each round you can choose from 1 pile and between 1 and 5 sticks
            // Last to pick a stick from a pile is the winner of the game


            // Requirements:
            // - Greeting and rules for game
            // - Name for players and game is supposed to know who is the next player
            // - After game, print out winner and thank for playing
            // - Ask if they wanna play again
            // - Statistics for current session
            // - Playing field will be stored in an array
            // - One playing round will be printed as <pile> <amount>
            // - No crashes, check if input is correct
            // - AI implemented
            // - Not just black and white

            // Methods:
            // - Greeting/Rules
            // - Name
            // - Current player
            // - Printing out game field
            // - Keeping track of amount of sticks left
            // - Making the move
            // - Uppdating game field
            // - End of game
            // - AI move

            bool playingAgain = true;
            object currentPlayer = null!;

            // string player1;
            // string player2;

            GreetingRules greeting = new GreetingRules();
            greeting.Greeting();
            greeting.Rules();

            Console.WriteLine("What is the name of first player?");
            string userInput = Console.ReadLine()!;
            string input = ErrorCheck(userInput);
            Player player1 = new Player(input);

            Console.WriteLine("What is the name of the second player?");
            userInput = Console.ReadLine()!;
            input = ErrorCheck(userInput);
            Player player2 = new Player(input);



            while (playingAgain) 
            {
                bool sticksLeft = true;
                Board game = new Board();
                currentPlayer = player1;

                while (sticksLeft) 
                {
          
                    game.DisplayBoard(game.GameBoard);
                    Console.WriteLine();

                    if (currentPlayer == player1) { Console.WriteLine($"Time for {player1.Name} to make a move!"); }
                    else { Console.WriteLine($"Time for {player2.Name} to make a move!"); }

                    // Make errorcheck on wrong inputs
                    Console.WriteLine("Which row do you choose?");
                    int row = int.Parse(Console.ReadLine()!);

                    // Make errorcheck on wrong inputs
                    Console.WriteLine("How many sticks do you want to take?");
                    int amount = int.Parse(Console.ReadLine()!);

                    if (game.ErrorChecks(game.GameBoard, row, amount))
                    {
                        Console.WriteLine("Good, now we take away those sticks");
                        game.UpdateBoard(game.GameBoard, row, amount);
                        sticksLeft = game.SticksLeft(game.GameBoard);
                        if (!sticksLeft) break;
                       
                        currentPlayer = (currentPlayer == player1) ? player2 : player1;

                    }
                    else 
                    {
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ogiltigt drag! Försök igen.");
                            Console.ResetColor();
                            continue; 
                        }
                    }
                   
                    sticksLeft = game.SticksLeft(game.GameBoard);

                }

                if (currentPlayer == player1)
                {
                    Console.WriteLine($"Congratulations on the win {player1.Name}!");
                    player1.Wins++;
                    player2.Losses++;
                }

                else 
                {
                    Console.WriteLine($"Congratulations on the win {player2.Name}!");
                    player2.Wins++;
                    player1.Losses++;
                }

                Console.WriteLine($"{player1.Name} has {player1.Wins} wins!");

                Console.WriteLine("Do you wanna play another game?");
                Console.ReadLine();
            }




            static string ErrorCheck(string message) 
            {
                if (message != null && message != "")
                {
                    return message;
                }

                else 
                { 
                    return "Hank"; 
                }
            }


        }
    }
}
