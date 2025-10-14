using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureMemorizer
{
    private List<Scripture> _scriptures;
    private Scripture _currentScripture;
    private Random _random;

    public ScriptureMemorizer()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        InitializeScriptures();
        LoadScripturesFromFile();
    }

    private void InitializeScriptures()
    {
        // Add some default scriptures
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him and he will make your paths straight."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all this through him who gives me strength."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd I shall not want"
        ));
    }

    private void LoadScripturesFromFile()
    {
        try
        {
            if (File.Exists("scriptures.txt"))
            {
                string[] lines = File.ReadAllLines("scriptures.txt");
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && line.Contains("|"))
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length >= 3)
                        {
                            string reference = parts[0].Trim();
                            string text = parts[1].Trim();
                            string[] refParts = reference.Split(' ');
                            
                            if (refParts.Length >= 2)
                            {
                                string book = refParts[0];
                                string[] chapterVerse = refParts[1].Split(':', '-', '–');
                                
                                if (chapterVerse.Length >= 2)
                                {
                                    int chapter = int.Parse(chapterVerse[0]);
                                    int startVerse = int.Parse(chapterVerse[1]);
                                    
                                    if (chapterVerse.Length == 2)
                                    {
                                        _scriptures.Add(new Scripture(
                                            new Reference(book, chapter, startVerse),
                                            text
                                        ));
                                    }
                                    else if (chapterVerse.Length == 3)
                                    {
                                        int endVerse = int.Parse(chapterVerse[2]);
                                        _scriptures.Add(new Scripture(
                                            new Reference(book, chapter, startVerse, endVerse),
                                            text
                                        ));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {ex.Message}");
        }
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Choose difficulty:");
        Console.WriteLine("1. Easy (hide 1 word at a time)");
        Console.WriteLine("2. Medium (hide 2 words at a time)");
        Console.WriteLine("3. Hard (hide 3 words at a time)");
        Console.Write("Select (1-3): ");
        
        string difficultyInput = Console.ReadLine();
        int wordsToHide = 3; // default medium
        
        if (difficultyInput == "1") wordsToHide = 1;
        else if (difficultyInput == "2") wordsToHide = 2;
        else if (difficultyInput == "3") wordsToHide = 3;

        // Select random scripture
        _currentScripture = _scriptures[_random.Next(_scriptures.Count)];
        
        Console.WriteLine($"\nSelected scripture: {_currentScripture.GetDisplayText()}");
        Console.WriteLine($"Total scriptures in library: {_scriptures.Count}");
        Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
        Console.ReadLine();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Progress: {_currentScripture.HiddenWords}/{_currentScripture.TotalWords} words hidden");
            Console.WriteLine(_currentScripture.GetDisplayText());
            
            if (_currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();
            
            if (input?.ToLower() == "quit")
            {
                break;
            }

            _currentScripture.HideRandomWords(wordsToHide);
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}