using System;

public class BreathingActivity : Activity
{
    
    // -- CONSTRUCTORS --
    public BreathingActivity() : base()
    {
        _activityName = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing";
    }

    public void Run()
    {
        Start();
        

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {   
            Console.Write("\nBreathe in...");
            ShowCountdown(4);
            Console.Write("\nNow breath out...");
            ShowCountdown(6);
        }

        End();
        
    }
}