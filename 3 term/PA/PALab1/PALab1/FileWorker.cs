namespace PALab1;

public static class FileWorker
{
    public static void GenerateArray(string fileName, int elementNumber)
    {
        var random = new Random();
        using var sw = new StreamWriter(fileName);
        for (int i = 0; i < elementNumber; i++)
        {
            var num = random.Next(0, elementNumber);
            sw.WriteLine(num);
        }
    }

    public static int[] GetArrayPart(int start, int size, string fileName)
    {
        var array = new int[size];
        using var sr = new StreamReader(fileName);
        for (int i = 0; i < start; i++)
        {
            sr.ReadLine();
        }

        for (int i = 0; i < size; i++)
        {
            array[i] = int.Parse(sr.ReadLine()!);
        }

        return array;
    }
}