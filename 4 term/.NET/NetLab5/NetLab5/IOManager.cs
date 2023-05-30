using NetLab5.Commands.Abstract;
using NetLab5.Factories;
using NetLab5.Factories.Abstract;
using NetLab5.Models;
using NetLab5.Models.Abstract;

namespace NetLab5;

public class IOManager
{
    private readonly Func<string> _input;
    private readonly Action<string> _output;

    public IOManager(Func<string> input, Action<string> output)
    {
        _input = input;
        _output = output;
    }

    public void Process()
    {
        var escape = false;
        while (!escape)
        {
            _output("Enter s, c or t to work with square, circle or triangle, or q to quit:");
            var input = _input();
            switch (input)
            {
                case "s":
                    ProcessSquare();
                    break;
                case "c":
                    ProcessCircle();
                    break;
                case "t":
                    ProcessTriangle();
                    break;
                case "q":
                    escape = true;
                    break;
                default:
                    OutputError();
                    break;
            }
        }
    }

    private void ProcessTriangle()
    {
        Triangle? triangle = null;
        while (triangle is null)
        {
            _output("Input triangle sides, separated by white spaces");
            var inputString = _input();
            try
            {
                var input = inputString.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(double.Parse).ToArray();
                if (input.Length != 3 || input.Any(s => s <= 0))
                {
                    throw new Exception();
                }

                triangle = new Triangle(input[0], input[1], input[2]);
            }
            catch
            {
                OutputError();
            }
        }

        var factory = new TriangleCommandFactory();

        ProcessFigure(triangle, factory);
    }

    private void ProcessCircle()
    {
        Circle? circle = null;
        while (circle is null)
        {
            _output("Input circle radius");
            var inputString = _input();
            try
            {
                var input = inputString.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(double.Parse).ToArray();
                if (input.Length != 1 || input.Any(s => s <= 0))
                {
                    throw new Exception();
                }

                circle = new Circle(input[0]);
            }
            catch
            {
                OutputError();
            }
        }

        var factory = new CircleCommandFactory();

        ProcessFigure(circle, factory);
    }

    private void ProcessSquare()
    {
        Square? square = null;
        while (square is null)
        {
            _output("Input square side");
            var inputString = _input();
            try
            {
                var input = inputString.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(double.Parse).ToArray();
                if (input.Length != 1 || input.Any(s => s <= 0))
                {
                    throw new Exception();
                }

                square = new Square(input[0]);
            }
            catch
            {
                OutputError();
            }
        }

        var factory = new SquareCommandFactory();

        ProcessFigure(square, factory);
    }

    private void ProcessFigure<T>(T shape, IShapeCommandFactory<T> commandFactory) where T : Shape
    {
        var commands = new Stack<IShapeCommand>();
        var escape = false;
        while (!escape)
        {
            var message = commands.Count > 0
                ? "Enter s or e to shrink or expand shape, u to undo, d to draw, or q to quit"
                : "Enter s or e to shrink or expand shape, d to draw, or q to quit";
            _output(message);
            var input = _input();
            double? amount;
            switch (input)
            {
                case "s":
                    amount = GetAmount();
                    if (amount is not null)
                    {
                        var command = commandFactory.CreateShrinkCommand(shape, (double)amount);
                        command.Execute();
                        commands.Push(command);
                    }

                    break;
                case "e":
                    amount = GetAmount(false);
                    if (amount is not null)
                    {
                        var command = commandFactory.CreateExpandCommand(shape, (double)amount);
                        command.Execute();
                        commands.Push(command);
                    }

                    break;
                case "u":
                    if (commands.Count == 0)
                    {
                        OutputError();
                    }
                    else
                    {
                        var command = commands.Pop();
                        command.Undo();
                    }

                    break;
                case "d":
                    shape.Draw();
                    break;
                case "q":
                    escape = true;
                    break;
                default:
                    OutputError();
                    break;
            }
        }
    }

    private double? GetAmount(bool shrinking = true)
    {
        var process = shrinking ? "shrink" : "expand";
        _output($"Enter, how many times you want to {process} the shape");
        if (!double.TryParse(_input(), out double amount) || amount <= 0)
        {
            OutputError();
            return null;
        }

        return amount;
    }

    public void OutputError()
    {
        _output("Invalid input, try again");
    }
}