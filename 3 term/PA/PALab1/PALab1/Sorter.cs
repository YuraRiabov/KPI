namespace PALab1;

public static class Sorter
{
    private const string FirstHelperFile = "firstHelper.dat";
    private const string SecondHelperFile = "secondHelper.dat";

    public static void Sort(string fileName, int arraySize)
    {
        var maxSequence = 0;
        while (maxSequence < arraySize)
        {
            SplitFile(fileName, ref maxSequence);

            if (maxSequence < arraySize)
            {
                RewriteFile(fileName);
            }
        }
    }

    public static void SortParts(string fileName, string outputFileName, int size, int shareSize)
    {
        if (File.Exists(outputFileName))
        {
            File.Delete(outputFileName);
        }
        
        var array = new int[shareSize];
        using var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
        using var writer = new BinaryWriter(File.Open(outputFileName, FileMode.OpenOrCreate));
        for (int i = 0; i < size / shareSize; i++)
        {
            for (int j = 0; j < shareSize; j++)
            {
                array[j] = reader.ReadInt32();
            }
            Array.Sort(array);
            for (int j = 0; j < shareSize; j++)
            {
                writer.Write(array[j]);
            }
        }
    }

    private static void RewriteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        using var mainWriter = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));
        using var firstReader = new BinaryReader(File.Open(FirstHelperFile, FileMode.OpenOrCreate));
        using var secondReader = new BinaryReader(File.Open(SecondHelperFile, FileMode.OpenOrCreate));
        int currentFirst = GetInt(firstReader);
        int currentSecond = GetInt(secondReader);
        var nextFirst = GetInt(firstReader);
        var nextSecond = GetInt(secondReader);
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
                mainWriter.Write(currentSecond);
            }
        }
    }

    private static int GetInt(BinaryReader reader)
    {
        try
        {
            return reader.ReadInt32();
        }
        catch (EndOfStreamException)
        {
            return int.MaxValue;
        }
    }

    private static int MergeSeries(int currentSecond, BinaryWriter mainWriter, BinaryReader secondReader,
        BinaryReader firstReader, ref int nextSecond, ref int currentFirst, ref int nextFirst)
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

    private static void MoveNext(BinaryWriter writer, ref int current, BinaryReader reader, ref int next)
    {
        writer.Write(current);
        current = next;
        next = next == int.MaxValue
            ? int.MinValue
            : GetInt(reader);
    }

    private static void SplitFile(string fileName, ref int maxSequence)
    {
        if (File.Exists(FirstHelperFile))
        {
            File.Delete(FirstHelperFile);
        }
        if (File.Exists(SecondHelperFile))
        {
            File.Delete(SecondHelperFile);
        }
        using var mainFileReader = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate));
        using var firstWriter = new BinaryWriter(File.Open(FirstHelperFile, FileMode.OpenOrCreate));
        using var secondWriter = new BinaryWriter(File.Open(SecondHelperFile, FileMode.OpenOrCreate));
        var currentWriter = firstWriter;
        var nextValue = GetInt(mainFileReader);
        while (nextValue != int.MinValue)
        {
            int currentSequence = 0;
            int currentValue = nextValue;
            nextValue = GetInt(mainFileReader);
            while (currentValue <= nextValue)
            {
                MoveNext(currentWriter, ref currentValue, mainFileReader, ref nextValue);
                currentSequence++;
            }

            if (currentValue != int.MaxValue)
            {
                currentWriter.Write(currentValue);
                currentSequence++;
            }

            maxSequence = currentSequence > maxSequence ? currentSequence : maxSequence;

            currentWriter = currentWriter == firstWriter ? secondWriter : firstWriter;
        }
    }
}