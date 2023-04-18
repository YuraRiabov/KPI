namespace NetLab3.Interfaces;

public interface ITitleReportBuilder : IReportBuilder
{
    public IGoalReportBuilder WithTitle(string title);
}