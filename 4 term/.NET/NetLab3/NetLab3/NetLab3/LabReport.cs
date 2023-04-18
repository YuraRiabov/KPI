using System.Text;

namespace NetLab3;

public class LabReport
{
    public string Title { get; set; }
    public string Goal { get; set; }
    public string Task { get; set; }
    public string Theory { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string Results { get; set; }
    public string ResultsAnalysis { get; set; }
    public string Conclusion { get; set; }
    public List<string> Schemas { get; set; } = new();
    public List<string> Diagrams { get; set; } = new();

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Goal: {Goal}");
        sb.AppendLine($"Task: {Task}");

        if (!string.IsNullOrEmpty(Theory))
        {
            sb.AppendLine($"Theory: {Theory}");
        }
        
        if (!string.IsNullOrEmpty(Description))
        {
            sb.AppendLine($"Description of Work: {Description}");
        }

        if (!string.IsNullOrEmpty(Code))
        {
            sb.AppendLine($"Code: {Code}");
        }
        
        sb.AppendLine($"Results: {Results}");

        if (!string.IsNullOrEmpty(ResultsAnalysis))
        {
            sb.AppendLine($"Analysis of Results: {ResultsAnalysis}");
        }

        sb.AppendLine($"Conclusion: {Conclusion}");

        if (Schemas.Any())
        {
            sb.AppendLine("Schemas:");
            foreach (string schema in Schemas)
            {
                sb.AppendLine(schema);
            }
        }

        if (Diagrams.Any())
        {
            sb.AppendLine("Diagrams:");
            foreach (string diagram in Diagrams)
            {
                sb.AppendLine(diagram);
            }
        }

        return sb.ToString();
    }
}