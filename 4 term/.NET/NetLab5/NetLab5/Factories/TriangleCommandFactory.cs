using NetLab5.Commands.Abstract;
using NetLab5.Commands.TriangleCommands;
using NetLab5.Factories.Abstract;
using NetLab5.Models;

namespace NetLab5.Factories;

public class TriangleCommandFactory : IShapeCommandFactory<Triangle>
{
    public ShrinkCommand<Triangle> CreateShrinkCommand(Triangle shape, double amount)
    {
        return new TriangleShrinkCommand(shape, amount);
    }

    public ExpandCommand<Triangle> CreateExpandCommand(Triangle shape, double amount)
    {
        return new TriangleExpandCommand(shape, amount);
    }
}