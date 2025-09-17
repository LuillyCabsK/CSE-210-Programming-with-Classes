using System;

class Program
{
    static void Main()
    {
        string name;
        string lastName;

        // Input
        Console.WriteLine("Welcome to CSE210 - C# - Week 1!");
        Console.WriteLine("Enter your name:");
        name = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();

        // Output
        Console.WriteLine($"Hello Mr. {lastName}, {name} {lastName}.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
// coding by: Lcabs