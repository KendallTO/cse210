using System;
/// <summary>
/// The MathAssignment class is a subclass of the Assignment class that represents a math assignment. It 
/// includes additional properties for the textbook section and problems assigned, as well as a method to 
/// retrieve the homework list. The constructor allows for initializing the student name, topic, textbook 
/// section, and problems when creating an instance of the MathAssignment class.
/// </summary>
public class MathAssignment : Assignment
{
    // -- MEMBER VARIABLES --
    private string _textbookSection = "";

    private string _problems = "";


    // -- CONSTRUCTORS --
    /// <summary>
    /// The default constructor initializes the MathAssignment object with default values for the textbook 
    /// section and problems. This allows for creating a MathAssignment instance without providing specific 
    /// details, and the textbook section and problems can be set later using a method.
    /// </summary>
    public MathAssignment()
    {
        _textbookSection = "X.C";
        _problems = "X-Z";
    }

    /// <summary>
    /// The constructor initializes the MathAssignment object by calling the base class constructor to set the
    /// student name and topic, and then sets the textbook section and problems. This allows for creating a 
    /// MathAssignment instance with specific details about the student, topic, textbook section, and problems.
    /// </summary>
    /// <param name="studentName">Name of the student</param>
    /// <param name="topic">Topic of the assignment</param>
    /// <param name="textbookSection">Section of the textbook</param>
    /// <param name="problems">Problems assigned</param>
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base (studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }


    // -- METHODS --
    /// <summary>
    /// The GetHomeworkList method returns a string that includes the textbook section and the problems assigned 
    /// for the math assignment. This method provides information about the math assignment in a formatted manner, 
    /// allowing for easy retrieval of the homework
    /// </summary>
    /// <returns>A string containing the textbook section and problems assigned</returns>
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}