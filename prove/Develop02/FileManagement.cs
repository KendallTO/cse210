using System;
using System.IO;

// The FileManagement class provides methods to save journal entries to a file and load journal 
// entries from a file. It interacts with the Journal class to access the entries and perform 
// file operations.
public class FileManagement
{
    // Method to save the journal entries to a file. It prompts the user for a filename, 
    // writes each entry from the journal to the file, and confirms that the file was 
    // saved successfully.
    public void SaveToFile(Journal journal)
    {
        Console.WriteLine("What do you want the file name to be?");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in journal._entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        
        Console.WriteLine("File saved successfully!");
    }
    

    // Method to load journal entries from a file. It prompts the user for a filename, 
    // reads each line from the file, adds it to the journal's entries, and confirms 
    // that the file was loaded successfully.
    public void LoadFromFile(Journal journal)
    {   
        Console.WriteLine("Enter filename: ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);

        // Iterate through each line in the file, split it into parts, create a new Entry object
        // with the parts, and add the entry to the journal's list of entries. (Formatting)
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry(parts[0], parts[1], parts[2]);

            journal._entries.Add(entry);
        }

        Console.WriteLine("File loaded successfully!");
    }
}