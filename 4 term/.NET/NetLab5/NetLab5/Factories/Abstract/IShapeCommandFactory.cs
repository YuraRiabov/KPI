using NetLab5.Commands.Abstract;
using NetLab5.Models.Abstract;

namespace NetLab5.Factories.Abstract;

public interface IShapeCommandFactory<T> where T : Shape
{
    public ShrinkCommand<T> CreateShrinkCommand(T shape, double amount);
    public ExpandCommand<T> CreateExpandCommand(T shape, double amount);
}