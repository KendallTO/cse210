using System;

public class SimpleGoal : Goal
{
    private bool _isComlete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComlete = false;
    }


    public override string GetGoalDetails()
    {   
        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal?");
        int points = int.Parse(Console.ReadLine());
        _isComlete = false;
        return $"Name: {name}, Description: {description}, Points: {points}";
    }


}