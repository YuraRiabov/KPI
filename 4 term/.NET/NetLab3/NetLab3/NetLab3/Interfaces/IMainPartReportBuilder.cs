namespace NetLab3.Interfaces;

public interface IMainPartReportBuilder : IReportBuilder
{
    public IMainPartReportBuilder WithTheory(string theory);

    public IResultsReportBuilder WithDescription(string description);

    public IResultsReportBuilder WithCode(string code);
}