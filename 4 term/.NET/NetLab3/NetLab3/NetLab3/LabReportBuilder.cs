using NetLab3.Interfaces;

namespace NetLab3
{
    public class LabReportBuilder : 
        ITitleReportBuilder,
        IGoalReportBuilder,
        ITaskReportBuilder,
        IMainPartReportBuilder,
        IResultsReportBuilder,
        IConclusionReportBuilder,
        IBuildableReportBuilder
            
    {
        private readonly LabReport _labReport = new();

        private LabReportBuilder()
        {
        }

        public static ITitleReportBuilder Create()
        {
            return new LabReportBuilder();
        }

        public IGoalReportBuilder WithTitle(string title)
        {
            _labReport.Title = title;
            return this;
        }

        public ITaskReportBuilder WithGoal(string goal)
        {
            _labReport.Goal = goal;
            return this;
        }

        public IMainPartReportBuilder ForTask(string task)
        {
            _labReport.Task = task;
            return this;
        }

        public IMainPartReportBuilder WithTheory(string theory)
        {
            _labReport.Theory = theory;
            return this;
        }

        public IResultsReportBuilder WithDescription(string description)
        {
            _labReport.Description = description;
            return this;
        }
        
        public IResultsReportBuilder WithCode(string code)
        {
            _labReport.Code = code;
            return this;
        }

        public IConclusionReportBuilder WithResult(string results)
        {
            _labReport.Results = results;
            return this;
        }

        public IConclusionReportBuilder WithResultsAnalysis(string resultsAnalysis)
        {
            _labReport.ResultsAnalysis = resultsAnalysis;
            return this;
        }

        public IBuildableReportBuilder WithConclusion(string conclusion)
        {
            _labReport.Conclusion = conclusion;
            return this;
        }

        public IBuildableReportBuilder AddSchema(string schemaLink)
        {
            _labReport.Schemas.Add(schemaLink);
            return this;
        }

        public IBuildableReportBuilder AddDiagram(string diagramLink)
        {
            _labReport.Diagrams.Add(diagramLink);
            return this;
        }

        public LabReport Build()
        {
            return _labReport;
        }
    }
}