using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NimGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playingAgain = true;
            object currentPlayer = null!;
            bool vsHuman = false;
            bool vsAI = false;
            IPlayer player2 = null!;
            GreetingRules greeting = new GreetingRules();


            greeting.Greeting();
            greeting.Rules();


            Console.WriteLine("What is the name of first player?");
            string userInput = Console.ReadLine()!;
            string input = greeting.PlayerNames(userInput);
            Player player1 = new Player(input);


            Console.WriteLine("Do you wanna play against another human? y/n (Wrong input gives you AI opponent)");
            string humanInput = Console.ReadLine()!;


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

                    string userMove = "";
                    if (vsHuman || vsAI && currentPlayer == player1)
                    {
                        // Make errorcheck on wrong inputs
                        Console.WriteLine("Which row do you choose and how many sticks?");
                        userMove = Console.ReadLine()!;

                    }
                    else 
                    { 
                        Console.WriteLine("The computer is making a move...");
                        userMove = AI.MakeMoveComputer(game.GameBoard);
                    }

                    string[] inputs = userMove.Split(' ');

                    int row = int.Parse(inputs[0]);
                    int amount = int.Parse(inputs[1]);  
                    // Make it one string and split it into two ints
                    // int row = int.Parse(Console.ReadLine()!);
                    // int amount = int.Parse(Console.ReadLine()!);

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
                            Console.WriteLine("Illegal move! Try again.");
                            Console.ResetColor();
                            continue; 
                        }
                    }
                   
                    sticksLeft = game.SticksLeft(game.GameBoard);

                }

                Console.WriteLine("Thank you for playing!");
                Console.WriteLine("----------------------");
                Console.WriteLine($"{player1.Name} has {player1.Wins} wins!");
                Console.WriteLine($"{player2.Name} has {player2.Wins} wins!");
                Console.WriteLine();


                Console.WriteLine("Do you wanna play another game? y/n");
                string endInput = Console.ReadLine()!;

                if (endInput == "n") { playingAgain = false; }
            }







        }
    }
}
