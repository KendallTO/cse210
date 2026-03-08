using System;
using System.IO;
using System.Runtime.InteropServices;

// The Program class contains the Main method, which serves as the entry point of the application. 
// It provides a menu-driven interface for the user to interact with the journal, allowing them to 
// write new entries, display existing entries, load entries from a file, save entries to a file, 
// or quit the application.
class Program
{
    static void Main(string[] args)
    {   
        // Initialize variables and objects
        string userChoice = "";
        Journal journal = new Journal();
        FileManagement fileManagement = new FileManagement();


        // Welcome message to the user when they start the program
        Console.WriteLine("Welcome to the Journal Program!");


        // Start the menu loop until the user chooses to quit
        while (userChoice != "7")
        {   
            // Display the menu options to the user
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write Prompted Entry");
            Console.WriteLine("2. Write Unprompted Entry");
            Console.WriteLine("3. Display");
            Console.WriteLine("4. Motivational Quote");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Save");
            Console.WriteLine("7. Quit");

            // Prompt the user for their choice and read their input
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();
            Console.WriteLine(); // Add a blank line for better readability

            // Handle the user's choice and call the appropriate methods based on their selection
            if (userChoice == "1")  // Prompted Entry
            {
                journal.AddPromptedEntry();
            }
//---------------------------------
// EXTRA: Handle the case for unprompted entry by calling the AddBlankEntry method of the Journal class when the user
//      selects option 2. This allows the user to write an entry without a prompt.
// ---------------------------------
            else if (userChoice == "2") // Unprompted Entry
            {
                journal.AddBlankEntry();
            }

            else if (userChoice == "3") // Display
            {
                journal.DisplayEntries();
            }
// ---------------------------------
// EXTRA: Handle the case for displaying a motivational quote by creating an instance of the QuoteGenerator class 
//      and calling its GetQuote method when the user selects option 4. This allows the user to receive a random 
//      motivational quote.
// ---------------------------------
            else if (userChoice == "4") // Motivational Quote
            {
                QuoteGenerator quoteGenerator = new QuoteGenerator();
                string quote = quoteGenerator.GetQuote();
                Console.WriteLine("-- Motivational Quote --");
                Console.WriteLine(quote);
            }
            else if (userChoice == "5") // Load
            {
                try
                {
                    fileManagement.LoadFromFile(journal);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found. Please check the filename and try again.");
                }
            }
            else if (userChoice == "6") // Save
            {
                fileManagement.SaveToFile(journal);
            }
// ---------------------------------
// EXTRA: A save and quit case that prompts the user to save their journal before quitting the program. 
//      If the user chooses to save, it calls the SaveToFile method of the FileManagement class. If the user 
//      chooses not to save, it simply exits the program without saving.
// ---------------------------------
            else if (userChoice == "7") //  Quit
            {   
                Console.Write("Would you like to save your journal before quitting? (y/n): ");
                string saveChoice = Console.ReadLine();

                while (saveChoice.ToLower() != "y" && saveChoice.ToLower() != "n")
                {
                    Console.WriteLine("Invalid input, please enter 'y' or 'n': ");
                    saveChoice = Console.ReadLine();
                }
                if (saveChoice.ToLower() == "y")
                {
                    fileManagement.SaveToFile(journal);
                }
                else if (saveChoice.ToLower() == "n")
                {
                    Console.WriteLine("Your journal will not be saved.");
                }

                userChoice = "7"; // Set userChoice to "7" to exit the loop and end the program
                Console.WriteLine("Have a nice day!");
                Console.WriteLine("--------------------------------");
            }
            else // Handle invalid input by prompting the user to try again
            {
                Console.WriteLine("Invalid input, please try again.");
            }
     
        }
    }
}