namespace NetLab3.Interfaces;

public interface IResultsReportBuilder : IReportBuilder
{
    public IConclusionReportBuilder WithResult(string results);
}