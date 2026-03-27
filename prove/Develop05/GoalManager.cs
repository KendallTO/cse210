using System;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score;


    public GoalManager()
    {
        
    }

    public void End()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void CreateGoal()
    {

    }

}