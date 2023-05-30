using NetLab4.Models;

namespace NetLab4;

public class TextParser
{

    public List<Sentence> ParseSentences(string paragraph)
    {
        return paragraph.Split(".").Select(ParseSentence).ToList<Sentence>();
    }

    public Sentence ParseSentence(string sentence)
    {
        var currentWord = "";
        var tokens = new List<Token>();
        for (int i = 0; i < sentence.Length; i++)
        {
            if (!char.IsWhiteSpace(sentence[i]))
            {
                currentWord += sentence[i];
                continue;
            }
            if (i == 0 || char.IsWhiteSpace(sentence[i - 1]))
            {
                continue;
            }

            if (char.IsPunctuation(sentence[i - 1]))
            {
                currentWord = currentWord[..^1];
                if (!string.IsNullOrEmpty(currentWord))
                {
                    tokens.Add(new Word(currentWord));
                    currentWord = "";
                }
                tokens.Add(new Punctuation(sentence[i - 1].ToString()));
            }
            else if (!string.IsNullOrEmpty(currentWord))
            {
                tokens.Add(new Word(currentWord));
                currentWord = "";
            }
        }
        
        if (!string.IsNullOrEmpty(currentWord))
        {
            tokens.Add(new Word(currentWord));
        }

        return new Sentence(tokens);
    }
}