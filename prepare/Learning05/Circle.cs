using System;
using static System.Math;

public class Circle : Shape
{
    private int _radius;
    public Circle (string color, int radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea() 
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}