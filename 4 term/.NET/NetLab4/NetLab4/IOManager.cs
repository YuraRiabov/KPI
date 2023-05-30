using NetLab4.Models;
using NetLab4.Models.Enums;

namespace NetLab4;

public class IOManager
{
    private readonly Action<string> _output;
    private readonly Func<string> _input;
    private readonly TextParser _textParser;

    public IOManager(Action<string> output, Func<string> input)
    {
        _output = output;
        _input = input;
        _textParser = new TextParser();
    }

    public void Process()
    {
        var items = new List<TopLevelTextItem>();
        string? currentInput = null;
        while (currentInput != "q")
        {
            _output("Enter h to add header, l to add listing, p to add paragraph or q to quit:");
            currentInput = _input();
            switch (currentInput)
            {
                case "h":
                    items.Add(GetHeader());
                    break;
                case "p":
                    items.Add(GetParagraph());
                    break;
                case "l":
                    items.Add(GetListing());
                    break;
                case "q":
                    break;
                default:
                    OutputError();
                    break;
            }
        }

        var text = new Text(items);
        _output("Your text is:");
        _output(text.ToString());
    }

    private Paragraph GetParagraph()
    {
        _output("Input paragraph, press Enter to finish:");
        var paragraphString = _input();
        return new Paragraph(_textParser.ParseSentences(paragraphString));
    }

    private Listing GetListing()
    {
        var items = new List<ListingItem>();
        string? currentInput = null;
        var type = GetListingType();
        var lastParagraph = false;
        while (currentInput != "q")
        {
            if (!lastParagraph)
            {
                _output("Enter p to add paragraph or q to quit:");
                currentInput = _input();
                switch (currentInput)
                {
                    case "p":
                        items.Add(GetParagraph());
                        lastParagraph = true;
                        break;
                    case "q":
                        break;
                    default:
                        OutputError();
                        break;
                }
                continue;
            }
            _output("Enter l to add sublisting, p to add paragraph or q to quit:");
            currentInput = _input();
            switch (currentInput)
            {
                case "p":
                    items.Add(GetParagraph());
                    lastParagraph = true;
                    break;
                case "l":
                    items.Add(GetListing());
                    lastParagraph = false;
                    break;
                case "q":
                    break;
                default:
                    OutputError();
                    break;
            }
        }

        return new Listing(items, type);
    }

    private ListingType GetListingType()
    {
        _output("Enter n, l or d to choose between numbered, lettered or dashed listing(default will be just tabbed)");
        var typeString = _input();
        return typeString switch
        {
            "n" => ListingType.Numbered,
            "l" => ListingType.Lettered,
            "d" => ListingType.Dashed,
            _ => ListingType.Tabbed
        };
    }

    private Header GetHeader()
    {
        _output("Input header, press Enter to finish:");
        var headerString = _input();
        return new Header(_textParser.ParseSentences(headerString));
    }

    private void OutputError()
    {
        _output("Invalid input, try again");
    }
}