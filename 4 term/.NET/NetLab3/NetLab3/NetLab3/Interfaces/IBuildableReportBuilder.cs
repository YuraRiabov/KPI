namespace NetLab3.Interfaces;

public interface IBuildableReportBuilder : IReportBuilder
{
    public IBuildableReportBuilder AddSchema(string schemaLink);

    public IBuildableReportBuilder AddDiagram(string diagramLink);

    public LabReport Build();
}