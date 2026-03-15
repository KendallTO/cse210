using System;
/// <summary>
/// The Reference class represents a scripture reference, including the book, chapter, and verse(s).
/// It provides constructors to create references with either a single verse or a range of verses, 
/// as well as a method to get the reference text in a formatted string.
/// </summary>
public class Reference
{
    // -- MEMBER VARIABLES --
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;


    // -- CONSTRUCTORS --

    /// <summary>
    /// The constructor initializes the Reference object with the book, chapter, and verse(s). It takes 
    /// parameters for the book name, chapter number, and either a single verse or a range of verses 
    /// (start and end). The constructor assigns these values to the corresponding member variables. The 
    /// GetReferenceText method can then be used to retrieve the formatted reference text based on the 
    /// provided information.
    /// </summary>
    /// <param name="book">Book of Scripture</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="verse">Verse number</param>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    /// <summary>
    /// The constructor initializes the Reference object with the book, chapter, and verse(s). It takes 
    /// parameters for the book name, chapter number, and either a single verse or a range of verses 
    /// (start and end). The constructor assigns these values to the corresponding member variables. The 
    /// GetReferenceText method can then be used to retrieve the formatted reference text based on the 
    /// provided information.
    /// </summary>
    /// <param name="book">Book of Scripture</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="startVerse">Starting verse number</param>
    /// <param name="endVerse">Ending verse number</param>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }


    // -- METHODS --

    /// <summary>
    /// The GetReferenceText method constructs a string representation of the scripture reference. It checks 
    /// if the end verse is 0, which indicates that there is only a single verse in the reference.
    /// </summary>
    public string GetReferenceText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}: {_verse}";
        }
        else
        {
            return $"{_book} {_chapter}: {_verse}-{_endVerse}";
        }
        
    }
}