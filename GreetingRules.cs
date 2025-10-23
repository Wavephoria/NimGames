using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal class GreetingRules
    {
        public void Greeting() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the game NIM!");
            Console.ResetColor();
        }

        public void Rules() 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Regler:");
            Console.WriteLine("- There are 3 rows with 5 sticks in each row");
            Console.WriteLine("- Each play will take turns in removing sticks from the rows this is done by typing 2 numbers, the first numbers should be between 1-3 corresponding to the row you want to remove sticks from, the second number is the amount of sticks you want to remove from the row ");
            Console.WriteLine("- The one who grabs the last stick will be crowned victor");
            Console.WriteLine("- Press any character then and [ENTER] to enter your names! If you wish to play against an AI opponent leave the second name blank and press [ENTER]");
            Console.ResetColor();
            Console.ReadLine();
        }

        // Error checking for user input to avoid having no name on a player, if no input is made, it is default to Hank
        public string PlayerNames(string userInput)
        {
            string input = ErrorCheck(userInput);
            return input;
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
