using System;

class Program
{
    static void Main(string[] args)
    {
    // Call welcome message
        DisplayWelcomeMessage();
    // Initializes and Calls the 4 functions for DisplayResult
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);
    
    // Initialize and change the dataref
        int birthYear;
        PromptUserBirthYear(out birthYear);

    // Sends the parameters recieved from the previous functions to Display.
        DisplayResult(userName, squaredNumber, birthYear);
    }

    static void DisplayWelcomeMessage()
    {  
    // Print welcome message 
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
    // Asks for the users name, stores as string, and returns name
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
    // Asks user for their favorite number, stores as int, and returns int
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    
    static void PromptUserBirthYear(out int birthYear)
    {
    // Asks user for birthyear, parses, and sets birthyear as input.
        Console.Write($"Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());

    }

    static int SquareNumber(int number)
    {
    // Calculates the square of the users number and returns square
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square, int birthYear)
    {
    // Compiles and displays the results
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} years old this year.");
    }
}