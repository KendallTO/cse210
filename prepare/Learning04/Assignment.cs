using System;
/// <summary>
/// The Assignment class is the base class for all types of assignments. It contains properties and methods that are common 
/// to all assignments, such as the student's name and the topic of the assignment. The MathAssignment and WritingAssignment 
/// classes inherit from the Assignment class and add additional properties and methods specific to their respective types of
/// assignments.
/// </summary>
public class Assignment
{
    // -- MEMBER VARIABLES --
    protected string _studentName = "";
    private string _topic = "";


    // -- CONSTRUCTORS --
    /// <summary>
    /// The default constructor initializes the Assignment object with default values for the student name and topic. This allows for 
    /// creating an Assignment instance without providing specific details, and the student name and topic can be set later using a method.
    /// </summary>
    public Assignment()
    {
        _studentName = "Anonomous";
        _topic = "Unknown";
    }

    /// <summary>
    /// The constructor initializes the Assignment object by setting the student name and topic. This allows for creating an Assignment 
    /// instance with specific details about the student and the topic of the assignment.
    /// </summary>
    /// <param name="studentName">Name of the student</param>
    /// <param name="topic">Topic of the assignment</param>
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }


    // -- METHODS --
    /// <summary>
    /// The GetSummary method returns a string that includes the student's name and the topic of the assignment. This method provides a 
    /// summary of the assignment in a formatted manner, allowing for easy retrieval of the assignment details.
    /// </summary>
    /// <returns>A string containing the student name and topic</returns>
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}