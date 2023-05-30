namespace NetLab4.Models;

public record Word(string Value) : Token(Value)
{
    public override string ToString()
    {
        return Value;
    }
}