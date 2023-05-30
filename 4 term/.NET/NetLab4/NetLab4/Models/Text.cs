namespace NetLab4.Models;

public record Text(List<TopLevelTextItem> Items)
{
    public override string ToString()
    {
        return string.Join("\n", Items.Select(i => i.ToString()));
    }
}