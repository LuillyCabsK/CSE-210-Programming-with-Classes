using System;

class Program
{
    // Displays welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to this Program!");
    }

    // Prompts for and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Prompts for and returns user's favorite number
    static int PromptUserNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }

    // Squares the given number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    static void Main()
    {
        // Call all the functions in order
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }
}

// coding By: Lcabs