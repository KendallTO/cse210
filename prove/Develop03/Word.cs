using System;
using System.Runtime.CompilerServices;
/// <summary>
/// The Word class represents a single word in a scripture passage. It has member variables to store 
/// the original text of the word, a flag to indicate whether the word is hidden or not, and a hidden 
/// version of the text (with underscores). The class provides methods to hide the word, check if it 
/// is hidden, and get the appropriate display text based on its hidden state.
/// </summary>
public class Word
{
    // -- MEMBER VARIABLES --
    private string _text;
    private bool _isHidden;
    private string _hiddenText;


    // -- CONSTRUCTORS --

    /// <summary>
    /// The constructor initializes the Word object with the provided text. It sets the initial 
    /// state of the word as not hidden and creates a hidden version of the text with underscores.
    /// </summary>
    /// <param name="text">The original text of the word.</param>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _hiddenText = new string('_', _text.Length);

        // PERSONAL NOTE: Long way of converting characters to "_"
            // foreach (char _ in _text)
            // {
            //     _hiddenText += "_";
            // }

    }


    // -- METHODS --

    /// <summary>
    /// The Hide method sets the _isHidden flag to true, indicating that the word should be hidden. 
    /// When the GetDisplayText method is called, it will return the hidden version of the text (underscores)
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// The GetIsHidden method returns the current state of the _isHidden flag, indicating whether the word is hidden or not.   
    /// </summary>
    public bool GetIsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// The GetDisplayText method returns the appropriate display text based on whether the word is hidden or not.
    ///  If the word is hidden, it returns the hidden version (underscores); otherwise, it returns the original text.
    /// </summary>
    /// <returns>The display text of the word.</returns>
    public string GetDisplayText()
    {   
        // PERSONAL NOTE: Shorthand if else (Ternary)
        return _isHidden ? _hiddenText : _text;

        // PERSONAL NOTE: Standard if else for bool
        // if (_isHidden)
        // {
        //     return _hiddenText;
        // }
        // else
        // {
        //     return _text;
        // }
    }

}