using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🎯 AREA CALCULATOR - POLYMORPHISM DEMONSTRATION\n");
        
        // Create shapes list (POLYMORPHISM: Base type list)
        List<Shape> shapes = new List<Shape>();

        // Add different shape types to the same list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));
        shapes.Add(new Square("Yellow", 2.5));
        shapes.Add(new Rectangle("Orange", 3.5, 4.2));
        shapes.Add(new Circle("Purple", 4.2));

        // Display header
        Console.WriteLine("┌──────────────┬──────────┬──────────┐");
        Console.WriteLine("│ Shape        │ Color    │ Area     │");
        Console.WriteLine("├──────────────┼──────────┼──────────┤");

        // Iterate through the list (POLYMORPHISM: same interface, different behaviors)
        foreach (Shape shape in shapes)
        {
            string shapeType = shape.GetType().Name;
            string color = shape.GetColor();
            double area = shape.GetArea(); // Here's the polymorphism!

            Console.WriteLine($"│ {shapeType,-12} │ {color,-8} │ {area,8:F2} │");
        }

        Console.WriteLine("└──────────────┴──────────┴──────────┘");

        // Additional statistics
        Console.WriteLine($"\n📊 Statistics:");
        Console.WriteLine($"• Total shapes: {shapes.Count}");
        
        double totalArea = 0;
        foreach (Shape shape in shapes)
        {
            totalArea += shape.GetArea();
        }
        Console.WriteLine($"• Combined total area: {totalArea:F2}");
        
        // Additional polymorphism demonstration
        Console.WriteLine($"\n🎭 Demonstrating polymorphism in methods:");
        DemonstratePolymorphism();
    }

    static void DemonstratePolymorphism()
    {
        // Create individual shapes
        Shape square = new Square("Red", 4);
        Shape circle = new Circle("Blue", 5);
        
        // The same method behaves differently based on the actual object type
        Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea():F2}");
        Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");
        
        // Using polymorphism in method parameters
        DisplayShapeInfo(square);
        DisplayShapeInfo(circle);
    }
    
    static void DisplayShapeInfo(Shape shape) // Accepts any Shape
    {
        Console.WriteLine($"📐 {shape.GetType().Name}: {shape.GetColor()} -> Area: {shape.GetArea():F2}");
    }
}