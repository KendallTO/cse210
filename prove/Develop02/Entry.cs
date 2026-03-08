using System;

public class Entry
{
    // Member variables for a single entry
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }


    // Constructor to create an entry with date, prompt, and response
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }


    // Method to display the entry
    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n{Response}";
    }
}