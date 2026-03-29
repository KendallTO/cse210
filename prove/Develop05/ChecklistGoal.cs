using System;
/// <summary>
/// The Goal class is an abstract base class that represents a general goal. It contains properties for 
/// the goal's name, description, and points, as well as methods for getting the goal's details, recording 
/// an event, checking if the goal is complete, and getting a string representation of the goal. The Goal 
/// class serves as a blueprint for specific types of goals (SimpleGoal, EternalGoal, ChecklistGoal) that 
/// will inherit from it and implement the abstract methods according to their specific behavior.
/// </summary>
public class ChecklistGoal : Goal
{
    // -- MEMBER VARIABLES --
    private bool _isComplete;
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;


    // -- CONSTRUCTORS --

    /// <summary>
    /// Initializes a new instance of the ChecklistGoal class with the specified name, description, points, 
    /// target count, and bonus points. It calls the base constructor of the Goal class to set the common 
    /// properties of the goal, such as name, description, and points, and initializes the completion status 
    /// of the goal to false, as well as the target count and bonus points for the checklist goal.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="points"></param>
    /// <param name="targetCount"></param>
    /// <param name="bonusPoints"></param>
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _isComplete = false;
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = 0;
    }

    /// <summary>
    /// Initializes a new instance of the ChecklistGoal class with the specified name, description, points, 
    /// completion status, target count, bonus points, and current count. It calls the base constructor of 
    /// the Goal class to set the common properties of the goal, such as name, description, and points, and 
    /// initializes the completion status, target count, bonus points, and current count for the checklist 
    /// goal, allowing for the creation of a checklist goal that is already partially completed if needed.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="points"></param>
    /// <param name="isComplete"></param>
    /// <param name="targetCount"></param>
    /// <param name="bonusPoints"></param>
    /// <param name="currentCount"></param>
    public ChecklistGoal(string name, string description, int points, bool isComplete, int targetCount, int bonusPoints, int currentCount) : base(name, description, points)
    {
        _isComplete = isComplete;
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }


    // -- METHODS --

    /// <summary>
    /// Checks if the checklist goal is complete. This method checks if the current count of accomplishments 
    /// has reached the target count for the checklist goal. If the current count is equal to the target count, 
    /// it sets the completion status to true. Otherwise, it returns the value of the _isComplete member 
    /// variable, which indicates whether the goal has been accomplished or not.
    /// </summary>
    /// <returns>True if the checklist goal is complete; otherwise, false.</returns>
    public override bool IsComplete()
    {
        return _isComplete;
    }

    /// <summary>
    /// Records an event for the checklist goal. Each time this method is called, it increments the current count of 
    /// accomplishments for the checklist goal. If the current count reaches the target count, it sets the completion 
    /// status to true and awards the user points for completing the goal, including any bonus points. If the current 
    /// count has not yet reached the target count, it simply awards points for the accomplishment without changing 
    /// the completion status of the goal, allowing the user to continue working towards completing the checklist goal.
    /// </summary>
    /// <returns>The number of points earned for the event.</returns>
    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You have earned {_points + _bonusPoints} points");
            return _points + _bonusPoints;
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points");
            return _points;
        }
    }

    /// <summary>
    /// Gets the details of the checklist goal. This method overrides the GetGoalDetails method from the Goal class to provide
    /// specific information about the checklist goal, including its completion status and the current count of accomplishments
    /// compared to the target count, allowing the user to see their progress towards completing the checklist goal when viewing 
    /// the goal details.
    /// </summary>
    /// <returns>>A string representing the checklist goal's details, including its completion status and progress towards the target count.</returns>
    public override string GetGoalDetails()
    {
        return base.GetGoalDetails() + $" -- Currently Completed: {_currentCount}/{_targetCount}";
    }

    /// <summary>
    /// Gets a string representation of the checklist goal. This method provides a specific format for how the checklist goal should
    /// be represented as a string, which is used when saving the goal to a file. It includes the type of the goal, its name,
    /// description, points, completion status, bonus points, current count, and target count in a specific format that can be easily 
    /// parsed when loading the goal from a file, allowing for the accurate reconstruction of the checklist goal's state when it is 
    /// loaded from a file.
    /// </summary>
    /// <returns>A string representing the checklist goal in a specific format.</returns>
    public override string GetStringRepresentation()
    {
        return $"{nameof(ChecklistGoal)}|{_name}|{_description}|{_points}|{IsComplete()}|{_targetCount}|{_bonusPoints}|{_currentCount}";
    }


}