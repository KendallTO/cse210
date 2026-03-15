using System;
/// <summary>
/// This Scripture class represents a scripture reference and its associated text. It contains a Reference 
/// object to store the book, chapter, and verse(s) of the scripture, as well as a list of Word objects to 
/// represent each word in the scripture text. The class provides methods to display the scripture text, 
/// check if all words are hidden, and hide random words in the scripture.
/// </summary>
public class Scripture
{
    // -- MEMBER VARIABLES --
    private Reference _reference;

    private List<Word> _words;

    private Random _random;

    // -- CONSTRUCTORS --

    /// <summary>
    /// The constructor initializes the Scripture object with a Reference and a string of text. It creates a 
    /// list of Word objects from the text, splitting it into individual words and storing each word as a Word 
    /// object in the list. It also initializes a Random object for later use in hiding random words.
    /// </summary>
    /// <param name="reference">The Reference object representing the scripture reference.</param>
    /// <param name="text">The string of text representing the scripture content.</param>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();
        _words = new List<Word>();
        
        string[] wordArray = text.Split(" ");
        foreach (string word in wordArray)
        {
            Word wordObj = new Word(word);
            _words.Add(wordObj);
        } 
    }


    // -- METHODS --

    /// <summary>
    /// The GetDisplayText method constructs a string representation of the scripture text, including the 
    /// reference and the display text for each word. It iterates through the list of Word objects, calling 
    /// their GetDisplayText method to get either the original word or a hidden version (if the word is hidden). 
    /// The resulting string includes the reference followed by the display text for each word, separated by spaces.
    /// </summary>
    /// <returns>The display text of the scripture.</returns>
    public string GetDisplayText()
    {   
        string display = "";
        foreach (Word word in _words)
        {   
            display += word.GetDisplayText() + " ";
            
        }

        return _reference.GetReferenceText() + " " + display;
    }

    /// <summary>
    /// The IsCompletlyHidden method checks if all words in the scripture are hidden. It iterates through the 
    /// list of Word objects and checks if any word is not hidden. If it finds a word that is not hidden, it 
    /// returns false. If it finishes checking all words and finds that they are all hidden, it returns true.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {   
            if (word.GetIsHidden() == false)
            {
                return false;
            }            
        }

        return true;
    }

    /// <summary>
    /// The HideRandomWords method hides a random selection of words in the scripture. It uses a while loop to 
    /// hide three words at a time. Inside the loop, it generates a random index to select a Word object
    /// </summary>
    public void HideRandomWords()
    {
        int count = 0;

        while (count != 3)
        {
//---------------------------------
// STRETCH: Only randomly hide 3 words at a time that are not already hidden.
// ---------------------------------
            int index;
            do
            {
                index = _random.Next(_words.Count);

            } while (_words[index].GetIsHidden());

            _words[index].Hide();

            if (IsCompletelyHidden())
            {
                break;
            }

            count ++;
        }
    }
}