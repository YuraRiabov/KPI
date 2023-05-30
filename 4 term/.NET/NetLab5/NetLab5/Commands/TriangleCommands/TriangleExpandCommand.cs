using NetLab5.Commands.Abstract;
using NetLab5.Models;

namespace NetLab5.Commands.TriangleCommands;

public class TriangleExpandCommand : ExpandCommand<Triangle>
{
    public TriangleExpandCommand(Triangle shape, double amount) : base(shape, amount)
    {
    }

    public override void Undo()
    {
        Shape.FirstSide /= Amount;
        Shape.SecondSide /= Amount;
        Shape.ThirdSide /= Amount;
    }

    public override void Execute()
    {
        Shape.FirstSide *= Amount;
        Shape.SecondSide *= Amount;
        Shape.ThirdSide *= Amount;
    }
}