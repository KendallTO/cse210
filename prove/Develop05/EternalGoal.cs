using System;
/// <summary>
/// The EternalGoal class is a specific type of goal that inherits from the Goal class. It represents a goal that can be
/// completed multiple times, allowing the user to earn points each time they accomplish it. The EternalGoal class implements
/// the abstract methods from the Goal class to provide specific behavior for recording events and checking completion
/// status, where the IsComplete method always returns false since an eternal goal can never be fully completed, and the 
/// RecordEvent method awards points each time it is called without changing the completion status of the goal.
/// </summary>
public class EternalGoal : Goal
{
    // -- CONSTRUCTORS --

    /// <summary>
    /// Initializes a new instance of the EternalGoal class with the specified name, description, and points. It calls the
    /// base constructor of the Goal class to set the common properties of the goal, such as name, description, and points.
    /// </summary>
    /// <param name="name">The name of the eternal goal.</param>
    /// <param name="description">The description of the eternal goal.</param>
    /// <param name="points">The points awarded for completing the eternal goal.</param>
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }


    // -- METHODS --

    /// <summary>
    /// Checks if the eternal goal is complete. Since an eternal goal can never be fully completed, this method always 
    /// returns false, indicating that the goal is still active and can be accomplished multiple times.
    /// </summary>
    /// <returns>Always returns false, indicating that the eternal goal is never fully completed.</returns>
    public override bool IsComplete()
    {
        return false;
    }

    /// <summary>
    /// Records an event for the eternal goal. Each time this method is called, it awards points to the user for accomplishing
    ///  the goal, but it does not change the completion status of the goal since it can be accomplished multiple times
    /// </summary>
    /// <returns>The points awarded for recording the event.</returns>
    public override int RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        return _points;
    }

    /// <summary>
    /// Gets a string representation of the eternal goal. This method provides a specific format for how the eternal goal should
    ///  be represented as a string, which is used when saving the goal to a file. It includes the type of the goal, its name, 
    /// description, and points in a specific format that can be easily parsed when loading the goal from a file.
    /// </summary>
    /// <returns>A string representing the eternal goal in a specific format.</returns>
    public override string GetStringRepresentation()
    {
        return $"{GetType()}|{_name}|{_description}|{_points}";
    }


}