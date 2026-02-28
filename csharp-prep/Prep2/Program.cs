using System;

class Program
{
    static void Main(string[] args)
    {
    // Get users percentage grade and store as an int
        Console.Write("What is your percentage grade? ");
        string userGradeAsString = Console.ReadLine();
        int userGrade = int.Parse(userGradeAsString);

    // Initialize Variables
        string letter = "";
        string sign = "";
        int remainder = userGrade % 10;

    // Get letter grade
        if (userGrade >= 90)
        {
            letter = "A";
        }
        else if (userGrade >= 80)
        {
            letter = "B";
        }
        else if (userGrade >= 70)
        {
            letter = "C";
        }
        else if (userGrade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

    // Determine the sign
        if (remainder >= 7)
        {
            sign = "+";
        }
        else if (remainder < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

    // Account for special cases
        if (userGrade >= 94)
        {
            sign = "";
        }
        else if (userGrade < 60)
        {
            sign = "";
        }
        else
        {
        }

    // Print letter grade and sign
        Console.WriteLine($"Your letter grade: {letter}{sign}");

    // Determine if the grade is passing and responde accordingly
        if (userGrade >= 70)
        {
            Console.WriteLine("Congradulations! You are passing the class.");
        }
        else
        {
            Console.WriteLine("You are not passing the class. Please see the teacher for help.");
        }


    }
}