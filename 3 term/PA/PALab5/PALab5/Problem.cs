using System.Security.Cryptography;
using System.Text.Json;

namespace PALab5;

public class Problem
{
    private const string FileName = "problem.json";
    public const int CityNumber = 300;
    public int[][] Matrix { get; private set; }

    public Problem()
    {
        InitializeMatrix();
    }

    public int GetCost(int[] path)
    {
        var solution = 0;
        for (int i = 0; i < CityNumber - 1; i++)
        {
            solution += GetDistance(path[i], path[i + 1]);
        }

        solution += GetDistance(path[CityNumber - 1], path[0]);

        return solution;
    }

    public int GetDistance(int source, int destination) => Matrix[source][destination];
    
    public int FindOptimalSolution()
    {
        var solutions = new List<int>();
        for (int j = 0; j < CityNumber; j++)
        {
            var nodes = Enumerable.Range(0, CityNumber).ToList();
            var currentNode = j;
            var path = new List<int>();
            path.Add(currentNode);
            for (int i = 0; i < CityNumber - 1; i++)
            {
                int node = currentNode;
                currentNode = nodes.Where(x => !path.Contains(x)).MinBy(x => GetDistance(node, x));
                path.Add(currentNode);
            }
            solutions.Add(GetCost(path.ToArray()));
        }

        return solutions.Min();
    }

    private void InitializeMatrix()
    {
        if (File.Exists(FileName))
        {
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                Matrix = JsonSerializer.Deserialize<int[][]>(fs)!;
                return;
            }
        }

        GenerateMatrix();
        using (var fs = new FileStream(FileName, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, Matrix);
        }
    }

    private void GenerateMatrix()
    {
        Matrix = new int[CityNumber][];
        for (int i = 0; i < CityNumber; i++)
        {
            Matrix[i] = new int[CityNumber];
            for (int j = 0; j < CityNumber; j++)
            {
                if (j > i)
                {
                    Matrix[i][j] = RandomNumberGenerator.GetInt32(5, 150);
                }
                else if (j == i)
                {
                    Matrix[i][j] = int.MaxValue;
                }
                else
                {
                    Matrix[i][j] = Matrix[j][i];
                }
            }
        }
    }
}