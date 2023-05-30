using NetLab5.Models.Abstract;

namespace NetLab5.Models;

public class Square : Shape
{
    public double Side { get; set; }
    
    public Square(double side)
    {
        Side = side;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a square with side {Side}...");
    }
}