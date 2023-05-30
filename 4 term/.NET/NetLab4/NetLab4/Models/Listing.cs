using System.Text;
using NetLab4.Models.Enums;

namespace NetLab4.Models;

public record Listing(List<ListingItem> Items, ListingType Type = ListingType.Tabbed) : ListingItem
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        var currentLineStart = "";
        var startContentSeparator = Type == ListingType.Dashed ? " " : ") ";
        foreach (var item in Items)
        {
            if (item is not Listing)
            {
                currentLineStart = GetNextLineStart(currentLineStart);
                sb.AppendLine("\t" + currentLineStart + startContentSeparator + item);
            }
            else
            {
                foreach (var line in item.ToString().Split("\n").Where(s => !string.IsNullOrEmpty(s)))
                {
                    sb.AppendLine("\t" + line);
                }
            }
        }

        return sb.ToString();
    }

    private string GetNextLineStart(string current = "")
    {
        return Type switch
        {
            ListingType.Numbered => current != "" ? (int.Parse(current) + 1).ToString() : "1",
            ListingType.Lettered => current != "" ? ((char)((int)current[0] + 1)).ToString() : "a",
            ListingType.Dashed => "-",
            _ => ""
        };
    }
}