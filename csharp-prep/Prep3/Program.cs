using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {   

    // DoWhile loop that starts the game and repeats if user response is "yes"
        string response;
        do
        {
        //Generates a random magic number 
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1,100);

        //Initialize variables 
            int guess = 0;
            int numOfGuesses = 0;

        // Repeats guessing loop untill the guess matches the magic number giving hints if wrong
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);

            // Adds to the guess counter
                numOfGuesses++;

                if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed the magic number!");
                    Console.WriteLine($"It took you {numOfGuesses} guesses.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            
            } 
        // Asks user if they want to repeat the game
            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();

        } while (response == "yes");
    }
}