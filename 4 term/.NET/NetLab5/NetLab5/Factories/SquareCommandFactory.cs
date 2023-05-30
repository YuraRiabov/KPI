using NetLab5.Commands.Abstract;
using NetLab5.Commands.SquareCommands;
using NetLab5.Factories.Abstract;
using NetLab5.Models;

namespace NetLab5.Factories;

public class SquareCommandFactory : IShapeCommandFactory<Square>
{
    public ShrinkCommand<Square> CreateShrinkCommand(Square shape, double amount)
    {
        return new SquareShrinkCommand(shape, amount);
    }

    public ExpandCommand<Square> CreateExpandCommand(Square shape, double amount)
    {
        return new SquareExpandCommand(shape, amount);
    }
}