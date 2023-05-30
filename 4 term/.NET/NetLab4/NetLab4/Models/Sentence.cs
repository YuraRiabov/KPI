namespace NetLab4.Models;

public record Sentence(List<Token> Tokens)
{
    public override string ToString()
    {
        return string.Join(" ", Tokens.Select(t => t.ToString())) + '.';
    }
}