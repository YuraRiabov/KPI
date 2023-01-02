using System.Security.Cryptography;
using System.Text.Json;

namespace PALab4;

public class Problem
{
    private const string FileName = "problem.json";
    public int[][] Matrix { get; private set; }
    public int OptimalSolution { get; private set; }

    public Problem()
    {
        InitializeMatrix();
        OptimalSolution = FindOptimalSolution();
    }

    public int GetCost(List<int> path)
    {
        var solution = 0;
        for (int i = 0; i < 100; i++)
        {
            solution += GetDistance(path[i], path[i + 1]);
        }

        return solution;
    }

    public int GetDistance(int source, int destination) => Matrix[source][destination];

    private void InitializeMatrix()
    {
        if (File.Exists(FileName))
        {
            using (var fs  = new FileStream(FileName, FileMode.Open))
            {
                Matrix = JsonSerializer.Deserialize<int[][]>(fs)!;
                return;
            }
        }

        GenerateMatrix();
        using (var fs  = new FileStream(FileName, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, Matrix);
        }
    }

    private void GenerateMatrix()
    {
        Matrix = new int[100][];
        for (int i = 0; i < 100; i++)
        {
            Matrix[i] = new int[100];
            for (int j = 0; j < 100; j++)
            {
                Matrix[i][j] = i == j ? int.MaxValue : RandomNumberGenerator.GetInt32(5, 50);
            }
        }
    }

    private int FindOptimalSolution()
    {
        var solutions = new List<int>();
        for (int j = 0; j < 100; j++)
        {
            var nodes = Enumerable.Range(0, 100).ToList();
            var currentNode = j;
            var path = new List<int>();
            path.Add(currentNode);
            for (int i = 0; i < 99; i++)
            {
                int node = currentNode;
                currentNode = nodes.Where(x => !path.Contains(x)).MinBy(x => GetDistance(node, x));
                path.Add(currentNode);
            }
            path.Add(j);
            solutions.Add(GetCost(path));
        }

        return solutions.Min();
    }
}