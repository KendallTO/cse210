using System;
/// <summary>
/// The Assignment class is the base class for all types of assignments. It contains properties and methods that are common 
/// to all assignments, such as the student's name and the topic of the assignment. The MathAssignment and WritingAssignment 
/// classes inherit from the Assignment class and add additional properties and methods specific to their respective types of 
/// assignments.
/// </summary>
class Program
{
    static void Main(string[] args)
    {   
        // Create an instance of the Assignment class and display its summary
        Assignment new1 = new Assignment("Churchill", "Island Defence");
        Console.WriteLine(new1.GetSummary());

        Console.WriteLine();

        // Create an instance of the MathAssignment class and display its summary and homework list
        MathAssignment newMath = new MathAssignment("Einstein", "Physics", "7.1", "7,9-11");
        Console.WriteLine(newMath.GetSummary());
        Console.WriteLine(newMath.GetHomeworkList());

        Console.WriteLine();

        // Create an instance of the WritingAssignment class and display its summary and writing information
        WritingAssignment newEssay = new WritingAssignment("Julius Caesar", "Roman History", "Knife Safety");
        Console.WriteLine(newEssay.GetSummary());
        Console.WriteLine(newEssay.GetWritingInformation());

    }
}