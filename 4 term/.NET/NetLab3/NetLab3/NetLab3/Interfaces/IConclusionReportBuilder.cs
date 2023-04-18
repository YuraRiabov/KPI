namespace NetLab3.Interfaces;

public interface IConclusionReportBuilder : IReportBuilder
{
    public IConclusionReportBuilder WithResultsAnalysis(string resultsAnalysis);

    public IBuildableReportBuilder WithConclusion(string conclusion);
}