using System;
/// <summary>
/// The WritingAssignment class is a subclass of the Assignment class that represents a writing assignment. It includes 
/// an additional property for the title of the writing assignment and a method to retrieve information about the writing 
/// assignment, including the title and the student's name. The constructor allows for initializing the student name, 
/// topic, and title when creating an instance of the WritingAssignment class.
/// </summary>
public class WritingAssignment : Assignment
{
    // -- MEMBER VARIABLES --
    private string _title = "";


    // -- CONSTRUCTORS --
    /// <summary>
    /// The default constructor initializes the WritingAssignment object with a default title of "Blank". This allows for 
    /// creating a WritingAssignment instance without providing specific details, and the title can be set later using a method
    /// </summary>
    public WritingAssignment()
    {
        _title = "Blank";
    }

    /// <summary>
    /// The constructor initializes the WritingAssignment object by calling the base class constructor to set the student 
    /// name and topic, and then sets the title of the writing assignment. This allows for creating a WritingAssignment 
    /// instance with specific details about the student, topic, and title of the assignment.
    /// </summary>
    /// <param name="studentName">Name of the student</param>
    /// <param name="topic">Topic of the assignment</param>
    /// <param name="title">Title of the writing assignment</param>
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }


    // -- METHODS --
    /// <summary>
    /// The GetWritingInformation method returns a string that includes the title of the writing assignment and the student's 
    /// name. This method provides information about the writing assignment in a formatted manner, allowing for easy retrieval
    /// of the assignment
    /// </summary>
    /// <returns>A string containing the title and student name</returns>
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }

    // PERSONAL NOTE: I can access the _studentName variable directly since it is protected in the base class, but I could also
    // use a method like GetStudentName() if it were available. For streamlining, I made the _studentName variable protected in 
    // the Assignment class.

        // public string GetWritingInformation()
        // {
        //    return $"{_title} by {GetStudentName()}";
        // }
}