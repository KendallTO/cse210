using System;
using System.IO;
/// <summary>
/// Manages a collection of goals and provides methods for creating, displaying, saving, and loading goals.
/// </summary>
public class GoalManager
{
    // -- MEMBER VARIABLES --
    private List<Goal> _goals = new();
    private int _score;

    // -- PROPERTIES --
    public int Score => _score;


    // -- CONSTRUCTORS --
    public GoalManager()
    {
        
    }


    // -- METHODS --

    /// <summary>
    /// Creates a new goal based on the user's choice and adds it to the list of goals.
    /// </summary>
    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter the number of your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a description of the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;

        switch (choice)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("How many times does this goal to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                return;
        }

        _goals.Add(newGoal);
    }

    /// <summary>
    /// Displays the details of all goals in the list. It iterates through the list of goals and calls the
    /// GetGoalDetails method for each goal to display its information, including its completion status, 
    /// name, and description.
    /// </summary>
    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        int listNumber = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{listNumber}. {goal.GetGoalDetails()}");
            listNumber++;
        }
    }

    /// <summary>
    /// Saves the current list of goals to a file. It prompts the user for a filename and then writes the string
    /// representation of each goal to the file, allowing the user to persist their goals for future use.
    /// </summary>
    public void SaveToFile()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }   
        }
        
        Console.WriteLine("File saved successfully!");
    }
    
    /// <summary>
    /// Loads a list of goals from a file. It prompts the user for a filename, reads the contents of the file, and 
    /// creates Goal objects based on the data in the file. The method supports different types of goals (SimpleGoal, 
    /// EternalGoal, ChecklistGoal) and adds them to the list of goals in the GoalManager.
    /// </summary>
    public void LoadFromFile()
    {   
        Console.Clear();
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);
//---------------------------------
// STRETCH: When loading from the file, the first line contains the user's score, which is read and assigned to the _score member variable. This allows the application to restore the user's score along with their goals when they load from a file, providing a more complete and seamless experience for the user as they can continue from where they left off without losing their progress.
// ---------------------------------
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("|");

            if (parts[0] == "SimpleGoal")
            {
                Goal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                Goal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                _goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                Goal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]));
                _goals.Add(goal);
            }
            else
            {
                Console.WriteLine("Error, Not a goal!");
            }

        }

        Console.WriteLine("File loaded successfully!");
        Console.WriteLine($"Score restored: {_score}");
    }

    /// <summary>
    /// Records an event for a goal. It displays the list of goals and prompts the user to select which goal they 
    /// have accomplished. If the selected goal is not already complete, it calls the RecordEvent method for that 
    /// goal and updates the user's score accordingly. If the goal is already complete, it informs the user that 
    /// the goal has already been accomplished.
    /// </summary>
    public void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetGoalDetailsSimplified()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int goalAccomplished = int.Parse(Console.ReadLine()) - 1;
        if (!_goals[goalAccomplished].IsComplete())
        {
            _score += _goals[goalAccomplished].RecordEvent();
        }
        else
        {
            Console.WriteLine("That goal has already been accomplished (See the X?)");
        }
        
    }

}