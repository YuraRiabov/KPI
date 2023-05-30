using NetLab5.Commands.Abstract;
using NetLab5.Models;

namespace NetLab5.Commands.CircleCommands;

public class CircleShrinkCommand : ShrinkCommand<Circle>
{
    public CircleShrinkCommand(Circle shape, double amount) : base(shape, amount)
    {
    }

    public override void Execute()
    {
        Shape.Radius /= Amount;
    }

    public override void Undo()
    {
        Shape.Radius *= Amount;
    }
}