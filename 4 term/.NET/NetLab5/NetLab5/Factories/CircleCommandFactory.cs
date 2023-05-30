using NetLab5.Commands.Abstract;
using NetLab5.Commands.CircleCommands;
using NetLab5.Factories.Abstract;
using NetLab5.Models;

namespace NetLab5.Factories;

public class CircleCommandFactory : IShapeCommandFactory<Circle>
{
    public ShrinkCommand<Circle> CreateShrinkCommand(Circle shape, double amount)
    {
        return new CircleShrinkCommand(shape, amount);
    }

    public ExpandCommand<Circle> CreateExpandCommand(Circle shape, double amount)
    {
        return new CircleExpandCommand(shape, amount);
    }
}