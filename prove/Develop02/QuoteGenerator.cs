using System;

// The QuoteGenerator class is responsible for generating random quotes for the user to reflect on. 
// It contains a method that selects a quote from a predefined list of quotes and returns it as a 
// string.
public class QuoteGenerator
{   
    // Member variable that holds an array of quotes. Each quote is a motivational statement.
    private string[] quotes = {
        "Believe you can and you're halfway there.",
        "The only way to do great work is to love what you do.",
        "Success is not final, failure is not fatal: it is the courage to continue that counts.",
        "Do something today that your future self will thank you for.",
        "Hardships often prepare ordinary people for an extraordinary destiny.",
        "Don't watch the clock; do what it does. Keep going.",
        "The secret of getting ahead is getting started.",
        "Your limitation—it's only your imagination.",
        "Dream big and dare to fail.",
        "Small steps every day lead to big results.",
        "Push yourself, because no one else is going to do it for you.",
        "It always seems impossible until it's done.",
        "Success usually comes to those who are too busy to be looking for it.",
        "The harder you work for something, the greater you'll feel when you achieve it.",
        "Great things never come from comfort zones."
    };

    // Method to get a random quote from the quotes array. It uses the Random class to 
    // generate a random index and returns the quote at that index.
    public string GetQuote()
    {
        Random random = new Random();
        int index = random.Next(quotes.Length);
        return quotes[index];
    }
}