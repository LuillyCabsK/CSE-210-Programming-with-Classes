using System;

class Program
{
    static void Main()
    {
        // Initialize random number generator
        Random randomGenerator = new Random();
        bool playAgain = true;
        
        while (playAgain)
        {
            // Generate random number between 1-10
            int magicNumber = randomGenerator.Next(1, 11);
            int guessCount = 0;
            int guess = 0;
            
            Console.WriteLine("Welcome to Guess The Number Game!");
            Console.WriteLine("I've picked a number between 1 and 10.");
            
            // Game loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                
                // Validate input
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                
                if (guess < 1 || guess > 10)
                {
                    Console.WriteLine("Please enter a number between 1 and 10.");
                    continue;
                }

                guessCount++;
                
                // Check guess against magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }
            
            // Ask if player wants to play again
            Console.Write("Would you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes" || response == "y");
        }
        
        Console.WriteLine("I hope you had fun with this game as much as me! /t Goodbye!");
    }
}

// coding By: Lcabs