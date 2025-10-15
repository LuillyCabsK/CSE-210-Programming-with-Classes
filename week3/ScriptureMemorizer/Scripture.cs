using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<Word> _hiddenWords;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _hiddenWords = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        Random random = new Random();
        var visibleWords = _words.Except(_hiddenWords).ToList();
        
        if (visibleWords.Count == 0) return;
        
        int wordsToHide = Math.Min(count, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            Word wordToHide = visibleWords[index];
            wordToHide.Hide();
            _hiddenWords.Add(wordToHide);
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _hiddenWords.Count == _words.Count;
    }

    public int TotalWords => _words.Count;
    public int HiddenWords => _hiddenWords.Count;
}