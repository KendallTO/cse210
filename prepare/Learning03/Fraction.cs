using System;

// The Fraction class represents a mathematical fraction with a numerator (top) and a denominator (bottom).
// It provides constructors to create fractions in different ways, as well as methods to get and set the
// numerator and denominator, display the fraction as a string, and calculate its decimal value.
public class Fraction
{
    // Private fields to store the numerator (top) and denominator (bottom) of the fraction
    private int _top;
    private int _bottom;


    // Constructors to initialize the fraction in different ways
    public Fraction()
    {
        _top = 1;
        _bottom = 1;

    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;

    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }


    // Getters and setters for the top and bottom of the fraction
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }


    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            _bottom = 1;
        }
    }


    // Methods to display either the fraction as a string or its decimal value

    public string GetFractionString()
    {
        return _top + "/" + _bottom;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }

}