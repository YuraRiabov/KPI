namespace NetLab4.Models;

public record Punctuation : Token
{
    public Punctuation(string value) : base(value)
    {
        if (value.Length > 1 || !char.IsPunctuation(value[0]))
        {
            throw new ArgumentException();
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}