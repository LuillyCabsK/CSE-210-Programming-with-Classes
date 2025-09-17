using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a list to store numbers
        List<int> numbers = new List<int>();
        int number;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Get numbers from user until they enter 0
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            
            // Validate input
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }
            
            // Add to list if not 0
            if (number != 0)
            {
                numbers.Add(number);
            }
            
        } while (number != 0);

        // Core Requirements
        if (numbers.Count > 0)
        {
            // Calculate sum
            int sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");
            
            // Calculate average (as double for precision)
            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");
            
            // Find maximum
            int max = numbers.Max();
            Console.WriteLine($"The largest number is: {max}");
            
            // Stretch Challenges
            // Find smallest positive number
            var positiveNumbers = numbers.Where(n => n > 0);
            if (positiveNumbers.Any())
            {
                int smallestPositive = positiveNumbers.Min();
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers were entered.");
            }
            
            // Sort and display the list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}