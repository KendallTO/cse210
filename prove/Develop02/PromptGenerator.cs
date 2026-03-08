using System;

// The PromptGenerator class is responsible for generating random prompts for the user to reflect on. 
// It contains a method that selects a prompt from a predefined list of prompts and returns it as a 
// string.
public class PromptGenerator
{   
    // Member variable that holds an array of prompts. Each prompt is a question designed to 
    // encourage reflection and journaling.
    private string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };


    // Method to get a random prompt from the prompts array. It uses the Random class to 
    // generate a random index and returns the prompt at that index.
    public string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}