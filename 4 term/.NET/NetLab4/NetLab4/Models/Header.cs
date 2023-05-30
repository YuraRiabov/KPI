namespace NetLab4.Models;

public record Header(List<Sentence> Sentences) : TopLevelTextItem
{
    public override string ToString()
    {
        return "\t\t" + string.Join(" ", Sentences.Select(s => s.ToString()));
    }
}