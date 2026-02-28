using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    
    // Create new number list
        List<int> numbers = new List<int>();
    // Initialize variables
        int userInput;
        int total = 0;

    // Allow the user to insert number into the list until input is 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");  
        do
        {   
            Console.Write("Enter number: ");
            string inputNumber = Console.ReadLine();
            userInput = int.Parse(inputNumber);

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        } while(userInput != 0);

    // Add and print the total in list
        foreach (int number in numbers)
        {
            total += number;
        }
        Console.WriteLine($"Sum is: {total}");

    // Find and print the average in list
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

    // Find and print the largest number in list
        int largest = numbers.Max();
        Console.WriteLine($"The largest number is: {largest}");

    // Get the smallest positive number
        int smallestPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

    // Print out a sorted list
        Console.WriteLine("The sorted list is: ");
        numbers.Sort();
        foreach (int number in numbers)
        { 
            Console.WriteLine(number);
        }
        

    }
}