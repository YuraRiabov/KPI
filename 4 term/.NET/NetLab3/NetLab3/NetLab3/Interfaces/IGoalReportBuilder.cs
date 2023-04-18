namespace NetLab3.Interfaces;

public interface IGoalReportBuilder : IReportBuilder
{
    public ITaskReportBuilder WithGoal(string goal);
}