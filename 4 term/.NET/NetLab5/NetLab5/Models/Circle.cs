using NetLab5.Models.Abstract;

namespace NetLab5.Models;

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle with radius {Radius}...");
    }
}