using System;

public class Activity
{
    // -- MEMBER VARIABLES --
    private List<string> animationStrings = new()
    {
        "|", "/", "-", "\\"
    };
    
    protected string _activityName = "";

    protected string _description = "";

    protected int _duration;
    
    
    // -- CONSTRUCTORS --
    public Activity()
    {
  
    }


    // -- METHODS --
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}!\n");
        Console.WriteLine(_description);
        SetDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Showspinner(4);
    }

    public void End()
    {   
        Console.WriteLine("\nWell done!!");
        Showspinner(4);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_activityName}");
        Showspinner(4);
        ;
    }

    // -- SETTERS --
// This setter is very redundant because I could just do this in Start() but for the sake of abstraction I added it as a setter.
// STRETCH GOAL: I created a loop so users can only enter durations in 10 second intervals but I could also add error handling 
// to make sure they enter an integer.
    private void SetDuration()
    {
        do
        {
            Console.Write("\nHow long, in 10 second intervals, would you like your session to be? ");
            _duration = int.Parse(Console.ReadLine());

        } while (_duration % 10 != 0);
    }


    // -- DISPLAY ANIMATIONS --
    public void Showspinner(int seconds)
    {   
        for (int i = seconds; i > 0; i--)
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}