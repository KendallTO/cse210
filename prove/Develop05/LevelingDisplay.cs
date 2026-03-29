//---------------------------------
// STRETCH: Implement a leveling system that tracks the user's progress and rewards them with levels based on 
// their score. This adds an element of gamification to the program, making it more engaging and motivating for
// users to continue memorizing scriptures. The LevelingDisplay class is responsible for displaying the user's 
// current level and experience points (EXP) towards the next level based on their score. The DisplayLeveling 
// method calculates the user's level by dividing their score by 100, and determines the number of filled and 
// empty slots in a progress bar that visually represents the user's progress towards the next level. The method 
// then constructs a string representation of the progress bar and displays the user's current level, EXP, and 
// the progress bar in the console.
// ---------------------------------
using System;
/// <summary>
/// The LevelingDisplay class is responsible for displaying the user's current level and experience points (EXP
/// towards the next level) based on their score. The DisplayLeveling method calculates the user's level by
/// dividing their score by 100, and determines the number of filled and empty slots in a progress bar that 
/// visually represents the user's progress towards the next level. The method then constructs a string 
/// representation of the progress bar and displays the user's current level, EXP, and the progress bar in the 
/// console.
/// </summary>
public class LevelingDisplay
{   
    /// <summary>
    /// Displays the user's current level and experience points (EXP) towards the next level based on their score.
    /// The method calculates the user's level by dividing their score by 100, and determines the number of 
    /// filled and empty slots in a progress bar that visually represents the user's progress towards the next 
    /// level. It then constructs a string representation of the progress bar and displays the user's current level, 
    /// EXP, and the progress bar in the console.
    /// </summary>
    /// <param name="score">The user's current score, which is used to calculate their level and EXP towards the next level.</param>
    /// <returns>None. This method outputs the user's level and progress bar to the console.</returns>
    public void DisplayLeveling(int score)
    {
        int level = score / 100;
        int remainder = score % 100;

        int filledSlots = remainder / 10;
        int emptySlots = 10 - filledSlots;

        string bar = "[";

        for (int i = 0; i < filledSlots; i++)
        {
            bar += "/";
        }

        for (int i = 0; i < emptySlots; i++)
        {
            bar += "_";
        }

        bar += "]";

        Console.WriteLine($"\nLevel: {level}");
        Console.WriteLine($"(EXP: {remainder}) {bar}\n");
    }
}

