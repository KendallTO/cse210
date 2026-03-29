using System;
/// <summary>
/// The Goal class is an abstract base class that represents a general goal. It contains properties for 
/// the goal's name, description, and points, as well as methods for getting the goal's details, recording 
/// an event, checking if the goal is complete, and getting a string representation of the goal. The Goal 
/// class serves as a blueprint for specific types of goals (SimpleGoal, EternalGoal, ChecklistGoal) that 
/// will inherit from it and implement the abstract methods according to their specific behavior.
/// </summary>
public class SimpleGoal : Goal
{
    // -- MEMBER VARIABLES --
    private bool _isComplete;


    // -- CONSTRUCTORS --

    /// <summary>
    /// Initializes a new instance of the SimpleGoal class with the specified name, description, and points. 
    /// It calls the base constructor of the Goal class to set the common properties of the goal, such as 
    /// name, description, and points, and initializes the completion status of the goal to false.
    /// </summary>
    /// <param name="name">The name of the simple goal.</param>
    /// <param name="description">The description of the simple goal.</param>
    /// <param name="points">The points awarded for completing the simple goal.</param>
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    /// <summary>
    /// Initializes a new instance of the SimpleGoal class with the specified name, description, points, and 
    /// completion status. It calls the base constructor of the Goal class to set the common properties
    /// of the goal, such as name, description, and points, and initializes the completion status of the goal
    /// based on the provided isComplete parameter, allowing for the creation of a simple goal that is already 
    /// completed if needed.
    /// </summary>
    /// <param name="name">The name of the simple goal.</param>
    /// <param name="description">The description of the simple goal.</param>
    /// <param name="points">The points awarded for completing the simple goal.</param>
    /// <param name="isComplete">The completion status of the simple goal.</param>
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }


    // -- METHODS --

    /// <summary>
    /// Checks if the simple goal is complete. This method returns the value of the _isComplete member variable, 
    /// which indicates whether the goal has been accomplished or not. It allows the GoalManager to determine if 
    /// the user has completed the simple goal and should be awarded points for it.
    /// </summary>
    /// <returns>True if the simple goal is complete; otherwise, false.</returns>
    public override bool IsComplete()
    {
        return _isComplete;
    }

    /// <summary>
    /// Records an event for the simple goal. If the goal is not already complete, this method sets the _isComplete 
    /// member variable to true, indicating that the goal has been accomplished, and awards points to the user for 
    /// completing the goal. If the goal is already complete, it does not award points again and simply informs the 
    /// user that they have already accomplished the goal.
    /// </summary>
    /// <returns>The points awarded for completing the goal.</returns>
    public override int RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        return _points;
    }

    /// <summary>
    /// Gets a string representation of the simple goal. This method provides a specific format for how the simple goal 
    /// should be represented as a string, which is used when saving the goal to a file. It includes the type of the 
    /// goal, its name, description, points, and completion status in a specific format that can be easily parsed when 
    /// loading the goal from a file.
    /// </summary>
    /// <returns>A string representing the simple goal in a specific format.</returns>
    public override string GetStringRepresentation()
    {
        return $"{GetType()}|{_name}|{_description}|{_points}|{IsComplete()}";
    }


}