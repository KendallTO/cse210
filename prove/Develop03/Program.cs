using System;
/// <summary>
/// The Program class serves as the entry point for the scripture memorization application. It provides a user interface for 
/// selecting a scripture to memorize, either randomly or by user input, and manages the main loop of the program where the 
/// user can hide words in the scripture and view the updated display until they choose to quit or all words are hidden.
/// </summary>
class Program
{   
    static void Main(string[] args)
    {   
        // -- INITIALIZATION --
        string userChoice1 = "";
        string userChoice2 = "";
        Scripture scripture = null;
//---------------------------------
// STRETCH: Create a menu for the user to choose between memorizing a random scripture or entering one to study. This allows 
// the user to either select a random scripture from a predefined list or input their own scripture reference and text for memorization.
// This part of the program uses the class RandomScripture to get a random scripture and the Reference class to create a reference
// based on user input. The user is prompted to enter the book, chapter, and verse(s) for the scripture they want to study, and then 
//they can input the scripture text. The program then proceeds with the memorization process as before.
// ---------------------------------
        // -- USER INTERACTION --
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Would you like to memorize a random scripture or enter one to study? ");
        Console.WriteLine("1. Random");
        Console.WriteLine("2. Study");
        Console.Write("Please enter your choice (1 or 2): ");
        userChoice1 = Console.ReadLine();

        // -- INPUT VALIDATION --
        // The user is prompted to enter their choice for random or study, and the program validates the input to ensure
        // it is either "1" or "2". If the user enters an invalid choice, they are prompted again until a valid choice is
        // made. Based on the user's choice, the program either retrieves a random scripture or allows the user to input
        //  a scripture reference and text for study.
        while (userChoice1 != "1" && userChoice1 != "2")
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            userChoice1 = Console.ReadLine();
        }
        if (userChoice1 == "1")
        {
            RandomScripture randomScripture = new RandomScripture();
            scripture = randomScripture.GetRandomScripture();
        }
        else if (userChoice1 == "2")
        {
            Console.WriteLine("Please enter the book of scripture: ");
            string book = Console.ReadLine();

            Console.WriteLine("Please enter the chapter number: ");
            int chapter = int.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to enter a single verse or a range of verses? ");
            Console.WriteLine("1. Single Verse");
            Console.WriteLine("2. Range of Verses");
            userChoice1 = Console.ReadLine();

            Reference reference;

            if (userChoice1 == "1")
            {
                Console.WriteLine("Please enter the verse number: ");
                int verse = int.Parse(Console.ReadLine());
                reference = new Reference(book, chapter, verse);
            }
            else
            {
                Console.WriteLine("Please enter the starting verse number: ");
                int startVerse = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the ending verse number: ");
                int endVerse = int.Parse(Console.ReadLine());

                reference = new Reference(book, chapter, startVerse, endVerse);
            }

            Console.WriteLine("Please enter the scripture text: ");
            string text = Console.ReadLine();

            scripture = new Scripture(reference, text);
        }
        Console.Clear();
        Console.WriteLine("Starting scripture memorization...");


        // -- MAIN LOOP --
        // Loop until the user chooses to quit or all words in the scripture are hidden
        while (userChoice2 != "quit")
        {   
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            userChoice2 = Console.ReadLine();

            if (userChoice2 == "")
            {
                scripture.HideRandomWords();
            }
        }
        

    }

}