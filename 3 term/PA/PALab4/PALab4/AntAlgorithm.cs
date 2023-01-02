using System.Security.Cryptography;

namespace PALab4;

public class AntAlgorithm
{
    private Problem _problem;
    public double[][] PheromoneMatrix { get; set; }

    public AntAlgorithm(Problem problem)
    {
        _problem = problem;
        InitializeMatrix();
    }

    public void Iterate()
    {
        var paths = new List<List<int>>
        {
            Capacity = 30
        };
        for (int i = 0; i < 30; i++)
        {
            var initial = RandomNumberGenerator.GetInt32(0, 100);
            var path = FindPath(initial);
            paths.Add(path);
        }

        UpdatePheromones(paths);
    }

    public List<int> GetSolution()
    {
        var path = new List<int>
        {
            Capacity = 101
        };
        path.Add(0);
        for (int i = 1; i < 100; i++)
        {
            int currentIndex = path[i - 1];
            var pheromoneArray = PheromoneMatrix[currentIndex];
            double max = int.MinValue;
            int maxIndex = -1;
            for (int j = 1; j < 100; j++)
            {
                if (path.Contains(j))
                {
                    continue;
                }

                if (pheromoneArray[j] > max)
                {
                    max = pheromoneArray[j];
                    maxIndex = j;
                }
            }
            
            path.Add(maxIndex);
        }

        path.Add(0);
        return path;
    }

    private double[] GetProbabilities(int currentNode, List<int> allowedNodes)
    {
        var values = new double[allowedNodes.Count];
        var sum = 0.0;
        for (int i = 0; i < allowedNodes.Count; i++)
        {
            values[i] = Math.Pow(PheromoneMatrix[currentNode][allowedNodes[i]], 2) *
                        Math.Pow(1.0 / _problem.Matrix[currentNode][allowedNodes[i]], 4);
            sum += values[i];
        }

        for (int i = 0; i < values.Length; i++)
        {
            values[i] /= sum;
        }

        return values;
    }

    private void UpdatePheromones(List<List<int>> paths)
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                PheromoneMatrix[i][j] *= 0.6;
            }
        }

        foreach (var path in paths)
        {
            var cost = (double)_problem.GetCost(path);
            for (int i = 0; i < 100; i++)
            {
                PheromoneMatrix[path[i]][path[i + 1]] += _problem.OptimalSolution / cost;
            }
        }
    }

    private List<int> FindPath(int initial)
    {
        var result = new List<int>
        {
            Capacity = 101
        };
        var toVisit = Enumerable.Range(0, 100).Where(n => n != initial).ToList();
        result.Add(initial);
        for (int i = 1; i < 100; i++)
        {
            var probabilities = GetProbabilities(result[i - 1], toVisit);
            var nodeIndex = ChooseNode(probabilities);
            result.Add(toVisit[nodeIndex]);
            toVisit.RemoveAt(nodeIndex);
        }

        result.Add(initial);
        return result;
    }

    private int ChooseNode(double[] probabilities)
    {
        var random = new Random().NextDouble();
        var sum = 0.0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            sum += probabilities[i];
            if (sum > random)
            {
                return i;
            }
        }

        return probabilities.Length - 1;
    }

    private void InitializeMatrix()
    {
        PheromoneMatrix = new double[100][];
        for (int i = 0; i < 100; i++)
        {
            PheromoneMatrix[i] = new double[100];
            for (int j = 0; j < 100; j++)
            {
                PheromoneMatrix[i][j] = i == j ? 0 : 0.1;
            }
        }
    }
}