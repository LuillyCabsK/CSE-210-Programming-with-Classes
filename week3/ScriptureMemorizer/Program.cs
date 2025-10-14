using System;

class Program
{
    static void Main(string[] args)
    {
        // To exceed requirements, I have implemented the following features:
        // 1. Scripture library with multiple scriptures that are randomly selected
        // 2. Ability to load additional scriptures from a file
        // 3. Different difficulty levels (easy, medium, hard) that control how many words are hidden at once
        // 4. Progress tracking that shows how many words are hidden vs total
        // 5. The program ensures unique words are hidden until all are hidden (stretch challenge)

        ScriptureMemorizer memorizer = new ScriptureMemorizer();
        memorizer.Run();
    }
}