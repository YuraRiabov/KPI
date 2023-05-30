using NetLab5.Models.Abstract;

namespace NetLab5.Commands.Abstract;

public abstract class ExpandCommand<T>: IShapeCommand where T: Shape
{
    protected readonly T Shape;
    protected readonly double Amount;

    protected ExpandCommand(T shape, double amount)
    {
        Amount = amount;
        Shape = shape;
    }

    public abstract void Execute();

    public abstract void Undo();
}