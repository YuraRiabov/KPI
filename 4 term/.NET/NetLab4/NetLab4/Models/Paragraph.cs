namespace NetLab4.Models;

public record Paragraph(List<Sentence> Sentences): ListingItem
{
    public override string ToString()
    {
        return string.Join(" ", Sentences.Select(s => s.ToString()));
    }
}