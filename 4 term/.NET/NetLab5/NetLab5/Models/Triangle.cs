using NetLab5.Models.Abstract;

namespace NetLab5.Models;

public class Triangle : Shape
{
    public double FirstSide { get; set; }
    public double SecondSide { get; set; }
    public double ThirdSide { get; set; }
    
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a triangle with sides {FirstSide}, {SecondSide}, {ThirdSide}...");
    }
}