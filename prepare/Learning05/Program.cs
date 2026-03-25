using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("Red", 5);
        // Console.WriteLine(square1.GetColor());
        // Console.WriteLine(square1.GetArea());

        Circle circle1 = new Circle("Blue", 8);
        // Console.WriteLine(circle1.GetColor());
        // Console.WriteLine(circle1.GetArea());

        Rectangle rectangle1 = new Rectangle("Green", 4, 6);
        // Console.WriteLine(rectangle1.GetColor());
        // Console.WriteLine(rectangle1.GetArea());

        List <Shape> shapes = new List<Shape>{};
        shapes.Add(square1);
        shapes.Add(circle1);
        shapes.Add(rectangle1);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}