using NetLab5.Commands.Abstract;
using NetLab5.Models;

namespace NetLab5.Commands.SquareCommands;

public class SquareExpandCommand : ExpandCommand<Square>
{
    public SquareExpandCommand(Square shape, double amount) : base(shape, amount)
    {
    }

    public override void Execute()
    {
        Shape.Side *= Amount;
    }

    public override void Undo()
    {
        Shape.Side /= Amount;
    }
}