namespace NetLab5.Commands.Abstract;

public interface IShapeCommand
{
    public void Execute();
    public void Undo();
}