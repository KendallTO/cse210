using System;
using System.IO;
using System.Collections.Generic;

// The Journal class represents a journal that can store multiple entries. It has methods 
// to add new entries and display all entries. Each entry includes the date, a prompt, 
// and the user's response.
public class Journal
{       
    public List<Entry> _entries = new List<Entry>();


    // Method to display all journal entries. It iterates through the list of entries and
    // prints each one to the console.
    public void DisplayEntries()
    {
        Console.WriteLine("-- Displaying journal entries --");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"{entry}\n");
        }
    }


    // Method to add a new prompted entry. It generates a prompt, gets the user's response,
    // and creates a new entry with the current date, the prompt, and the response.
    // The new entry is then added to the list of entries in the journal. 
    public void AddPromptedEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetPrompt();

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        Entry entry = new Entry(dateText, prompt, response);
        _entries.Add(entry);
    }


    // Method to add a new unprompted entry. It prompts the user to write their entry, 
    // gets the user's response, and creates a new entry with the current date and the 
    // response (with an empty prompt). The new entry is then added to the list of entries 
    // in the journal.
    public void AddBlankEntry()
    {
        Console.WriteLine("Write your entry below:");
        Console.Write("> ");
        string response = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        Entry entry = new Entry(dateText, "", response);
        _entries.Add(entry);
    }
}



