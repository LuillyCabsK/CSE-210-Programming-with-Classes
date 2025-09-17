using System;

class Program
{
    static void Main()
    {
        // Get grade percentage from user calification in number
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        // Validate that the input is a number
        if (!int.TryParse(input, out int gradePercentage))
        {
            Console.WriteLine("Error: Please enter a valid number.");
            return;
        }
        
        // Validate ranke percentage is between 0 and 100
        if (gradePercentage < 0 || gradePercentage > 100)
        {
            Console.WriteLine("Error: Percentage must be between 0 and 100.");
            return;
        }

        string letter = "";  // Will hold the letter grade
        string sign = "";    // Will hold the + or - sign

        // Determine letter grade
        if (gradePercentage >= 90) letter = "A";
        else if (gradePercentage >= 80) letter = "B";
        else if (gradePercentage >= 70) letter = "C";
        else if (gradePercentage >= 60) letter = "D";
        else letter = "F";

        // Determine sign (only for grades A-D)
        if (letter != "F")
        {
            int lastDigit = gradePercentage % 10;
            
            if (lastDigit >= 7 && letter != "A")  // No A+
            {
                sign = "+";
            }
            else if (lastDigit < 3 && letter != "F")  // No F-
            {
                sign = "-";
            }
        }

        // Print the letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine if student passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard for next time!");
        }
    }
}
// coding by: Lcabs