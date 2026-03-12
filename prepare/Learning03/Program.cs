using System;

class Program
{
    static void Main(string[] args)
    {   
        // Test the Fraction class by creating instances of it, setting values, and displaying the fraction as a string and its decimal value.
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        fraction1 = new Fraction(5);
        Console.WriteLine(fraction1.GetFractionString());
        fraction1 = new Fraction(3, 4);
        Console.WriteLine(fraction1.GetFractionString());

        fraction1.SetTop(6);

        fraction1.SetBottom(4);

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        fraction1.SetTop(1);
        fraction1.SetBottom(3);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Generate 20 random fractions and display their string representation and decimal value
        Random random= new Random();
        Fraction newFraction = new Fraction();
        for (int i = 0; i < 20; i++)
        {
            int denominator = random.Next(1, 11);
            int numerator = random.Next(1, 11);
            newFraction.SetTop(numerator);
            newFraction.SetBottom(denominator);
            Console.Write($"Fraction {i + 1}: ");
            Console.Write($"string: {newFraction.GetFractionString()}");
            Console.WriteLine($" Number: {newFraction.GetDecimalValue()}");
        }
    }
}