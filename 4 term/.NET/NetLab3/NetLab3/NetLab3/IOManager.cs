using NetLab3.Interfaces;

namespace NetLab3;

public class IOManager
{
    private IReportBuilder _builder = LabReportBuilder.Create();
    
    public void Process()
    {
        LabReport? report = null;
        var moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessTitleStage();
        }

        moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessGoalStage();
        }
        
        moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessTaskStage();
        }
        
        moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessMainPartStage();
        }
        
        moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessResultsStage();
        }
        
        moveNext = false;
        while (!moveNext)
        {
            moveNext = ProcessConclusionStage();
        }
        
        while (report is null)
        {
           report =  ProcessBuildableStage();
        }
        
        Console.WriteLine("Report built successfully:");
        Console.WriteLine(report);
    }

    private LabReport? ProcessBuildableStage()
    {
        if (_builder is not IBuildableReportBuilder builder)
        {
            return null;
        }
        Console.WriteLine("Enter -d followed with link to add diagram, -s followed with link to add schema or -b to build report:");
        var inputString = Console.ReadLine();
        if (inputString == "-b")
        {
            return builder.Build();
        }

        var input = inputString.Split(" ");
        if (input.Length < 2)
        {
            OutputError();
            return null;
        }
        if (input[0] == "-d")
        {
            _builder = builder.AddDiagram(string.Join(" ", input[1..]));
            return null;
        }
        if (input[0] == "-s")
        {
            _builder = builder.AddSchema(string.Join(" ", input[1..]));
            return null;
        }
        
        OutputError();
        return null;
    }

    private bool ProcessConclusionStage()
    {
        if (_builder is not IConclusionReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter -a followed with text to add results analysis, or -c followed with text to add conclusion:");
        var inputString = Console.ReadLine();

        var input = inputString?.Split(" ");
        if (input is null || input.Length < 2)
        {
            OutputError();
            return false;
        }
        if (input[0] == "-a")
        {
            _builder = builder.WithResultsAnalysis(string.Join(" ", input[1..]));
            return false;
        }
        if (input[0] == "-c")
        {
            _builder = builder.WithConclusion(string.Join(" ", input[1..]));
            return true;
        }
        
        OutputError();
        return false;
    }

    private bool ProcessResultsStage()
    {
        if (_builder is not IResultsReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter lab results:");
        _builder = builder.WithResult(Console.ReadLine() ?? "");
        return true;
    }

    private bool ProcessMainPartStage()
    {
        if (_builder is not IMainPartReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter -t followed with text to add theory, -d followed with text to add description, or -c followed with text to add code:");
        var inputString = Console.ReadLine();

        var input = inputString?.Split(" ");
        if (input is null || input.Length < 2)
        {
            OutputError();
            return false;
        }
        if (input[0] == "-t")
        {
            _builder = builder.WithTheory(string.Join(" ", input[1..]));
            return false;
        }
        if (input[0] == "-c")
        {
            _builder = builder.WithCode(string.Join(" ", input[1..]));
            return true;
        }
        if (input[0] == "-d")
        {
            _builder = builder.WithDescription(string.Join(" ", input[1..]));
            return true;
        }
        
        OutputError();
        return false;
    }

    private bool ProcessTaskStage()
    {
        if (_builder is not ITaskReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter lab task:");
        _builder = builder.ForTask(Console.ReadLine() ?? "");
        return true;
    }

    private bool ProcessGoalStage()
    {
        if (_builder is not IGoalReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter lab goal:");
        _builder = builder.WithGoal(Console.ReadLine() ?? "");
        return true;
    }

    private bool ProcessTitleStage()
    {
        if (_builder is not ITitleReportBuilder builder)
        {
            return false;
        }
        Console.WriteLine("Enter lab title:");
        _builder = builder.WithTitle(Console.ReadLine() ?? "");
        return true;
    }

    private void OutputError()
    {
        Console.WriteLine("Invalid input");
    }
}