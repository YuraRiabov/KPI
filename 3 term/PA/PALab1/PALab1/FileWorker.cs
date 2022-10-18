namespace PALab1;

public static class FileWorker
{
    public static void GenerateArray(string fileName, int elementNumber)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        var random = new Random();
        using var fs = File.Open(fileName, FileMode.OpenOrCreate);
        using var bw = new BinaryWriter(fs);
        for (int i = 0; i < elementNumber; i++)
        {
            var num = random.Next(0, elementNumber);
            bw.Write(num);
        }
    }

    public static int[] GetArrayPart(int start, int size, string fileName)
    {
        var array = new int[size];
        using var sr = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate));
        for (int i = 0; i < start; i++)
        {
            sr.ReadInt32();
        }

        for (int i = 0; i < size; i++)
        {
            array[i] = sr.ReadInt32();
        }

        return array;
    }

    public static void ShowContent(string fileName, int size)
    {
        var array = GetArrayPart(0, size, fileName);
        Console.Write("[ ");
        foreach (var i in array)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine("]");
    }
}