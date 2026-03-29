using System;
using System.Dynamic;
/// <summary>
/// The Goal class is an abstract base class that represents a general goal. It contains properties for 
/// the goal's name, description, and points, as well as methods for getting the goal's details, recording 
/// an event, checking if the goal is complete, and getting a string representation of the goal. The Goal 
/// class serves as a blueprint for specific types of goals (SimpleGoal, EternalGoal, ChecklistGoal) that 
/// will inherit from it and implement the abstract methods according to their specific behavior.
/// </summary>
public abstract class Goal
{
    //-- MEMBER VARIABLES --
    protected string _name = "";
    protected string _description = "";
    protected int _points;
    

    // -- CONSTRUCTORS --

    /// <summary>
    /// Initializes a new instance of the Goal class with the specified name, description, and points.
    /// </summary>
    /// <param name="name">The name of the goal.</param>
    /// <param name="description">The description of the goal.</param>
    /// <param name="points">The points associated with the goal.</param>
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;

    }
    
    /// <summary>
    /// Initializes a new instance of the Goal class with the specified name, description, points, and 
    /// completion status.
    /// </summary> 
    /// <param name="name">The name of the goal.</param>
    /// <param name="description">The description of the goal.</param>
    /// <param name="points">The points associated with the goal.</param>
    /// <param name="isComplete">The completion status of the goal.</param>
    public Goal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
    }


    // -- METHODS --

    /// <summary>
    /// Gets the details of the goal.
    /// </summary>
    /// <returns>A string representing the goal's details.</returns>
    public virtual string GetGoalDetails()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    /// <summary>
    /// Gets a simplified string representation of the goal's details, which includes only the completion status
    /// and the name of the goal. This method can be used in contexts where a more concise representation of the 
    /// goal is needed, such as when listing goals without their descriptions.
    /// </summary> 
    /// <returns>A simplified string representing the goal's details, including only the completion status and name.</returns>
    public virtual string GetGoalDetailsSimplified()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name}";
    }

    // <summary>
    /// Records an event for the goal. This method is abstract and must be implemented by derived 
    /// classes to define how the goal's state changes when an event is recorded.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Checks if the goal is complete. This method is abstract and must be implemented by derived
    /// classes to define the criteria for when a goal is considered complete.
    /// </summary>
    public abstract bool IsComplete();
   
    /// <summary>
    /// Gets a string representation of the goal. This method is abstract and must be implemented by
    /// derived classes to provide a specific format for how the goal should be represented as a string,
    /// which is used when saving the goal to a file.
    /// </summary>
    public abstract string GetStringRepresentation();   
    
}