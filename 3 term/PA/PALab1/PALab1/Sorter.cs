namespace PALab1;

public static class Sorter
{
    public const string FirstHelperFile = "firstHelper.txt";
    public const string SecondHelperFile = "secondHelper.txt";

    public static void Sort(string fileName, int arraySize)
    {
        var maxSequence = 0;
        while (maxSequence < arraySize)
        {
            maxSequence = SplitFile(fileName, maxSequence);

            if (maxSequence < arraySize)
            {
                RewriteFile(fileName);
            }
        }
    }

    private static void RewriteFile(string fileName)
    {
        using (var mainWriter = new StreamWriter(fileName))
        {
            using (var firstReader = new StreamReader(FirstHelperFile))
            {
                using (var secondReader = new StreamReader(SecondHelperFile))
                {
                    int currentFirst = int.Parse(firstReader.ReadLine() ?? $"{int.MaxValue}");
                    int currentSecond = int.Parse(secondReader.ReadLine() ?? $"{int.MaxValue}");
                    var nextFirst = int.Parse(firstReader.ReadLine() ?? $"{int.MaxValue}");
                    var nextSecond = int.Parse(secondReader.ReadLine() ?? $"{int.MaxValue}");
                    while (nextFirst != int.MinValue && nextSecond != int.MinValue)
                    {
                        currentSecond = MergeSeries(currentSecond, mainWriter, secondReader, firstReader, ref nextSecond, ref currentFirst, ref nextFirst);
                    }

                    if (nextFirst != int.MinValue)
                    {
                        while (nextFirst != int.MinValue)
                        {
                            MoveNext(mainWriter, ref currentFirst, firstReader, ref nextFirst);
                        }
                    }

                    if (nextSecond != int.MinValue)
                    {
                        while (nextSecond != int.MinValue)
                        {
                            MoveNext(mainWriter, ref currentSecond, secondReader, ref nextSecond);
                        }

                        if (currentSecond != int.MaxValue)
                        {
                            mainWriter.WriteLine(currentSecond);
                        }
                    }
                }
            }
        }
    }

    private static int MergeSeries(int currentSecond, StreamWriter mainWriter, StreamReader secondReader,
        StreamReader firstReader, ref int nextSecond, ref int currentFirst, ref int nextFirst)
    {
        bool firstFinished = false;
        bool secondFinished = false;
        while (!firstFinished || !secondFinished)
        {
            if (firstFinished)
            {
                while (!secondFinished)
                {
                    if (currentSecond > nextSecond || nextSecond == int.MaxValue)
                    {
                        secondFinished = true;
                    }

                    MoveNext(mainWriter, ref currentSecond, secondReader, ref nextSecond);
                }
            }
            else if (secondFinished)
            {
                while (!firstFinished)
                {
                    if (currentFirst > nextFirst || nextFirst == int.MaxValue)
                    {
                        firstFinished = true;
                    }

                    MoveNext(mainWriter, ref currentFirst, firstReader, ref nextFirst);
                }
            }
            else
            {
                if (currentFirst < currentSecond)
                {
                    if (currentFirst > nextFirst || nextFirst == int.MaxValue)
                    {
                        firstFinished = true;
                    }

                    MoveNext(mainWriter, ref currentFirst, firstReader, ref nextFirst);
                }
                else
                {
                    if (currentSecond > nextSecond || nextSecond == int.MaxValue)
                    {
                        secondFinished = true;
                    }

                    MoveNext(mainWriter, ref currentSecond, secondReader, ref nextSecond);
                }
            }
        }

        return currentSecond;
    }

    private static void MoveNext(StreamWriter writer, ref int current, StreamReader reader, ref int next)
    {
        writer.WriteLine(current);
        current = next;
        next = next == int.MaxValue
            ? int.MinValue
            : int.Parse(reader.ReadLine() ?? $"{int.MaxValue}");
    }

    private static int SplitFile(string fileName, int maxSequence)
    {
        using (var mainFileReader = new StreamReader(fileName))
        {
            using (var firstWriter = new StreamWriter(FirstHelperFile))
            {
                using (var secondWriter = new StreamWriter(SecondHelperFile))
                {
                    var currentWriter = firstWriter;
                    int currentValue;
                    var nextValue = int.Parse(mainFileReader.ReadLine()!);
                    while (!mainFileReader.EndOfStream)
                    {
                        int currentSequence = 0;
                        currentValue = nextValue;
                        nextValue = int.Parse(mainFileReader.ReadLine() ?? $"{int.MaxValue}");
                        while (currentValue <= nextValue)
                        {
                            MoveNext(currentWriter, ref currentValue, mainFileReader, ref nextValue);
                            currentSequence++;
                        }

                        if (currentValue != int.MaxValue)
                        {
                            currentWriter.WriteLine(currentValue);
                            currentSequence++;
                        }

                        maxSequence = currentSequence > maxSequence ? currentSequence : maxSequence;

                        currentWriter = currentWriter == firstWriter ? secondWriter : firstWriter;
                    }

                    if (nextValue != int.MaxValue && nextValue != int.MinValue)
                    {
                        currentWriter.WriteLine(nextValue);
                    }
                }
            }
        }

        return maxSequence;
    }
}