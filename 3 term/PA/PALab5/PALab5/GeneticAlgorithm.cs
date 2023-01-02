namespace PALab5;

public class GeneticAlgorithm
{
    private const int PopulationSize = 1000;
    private const int BreedingPoolSize = 100;
    private readonly int _batchSize;
    private readonly double _mutationProbability;
    private readonly Problem _problem;
    private readonly Random _random = new();
    
    public Solution[] CurrentGeneration { get; set; }

    public GeneticAlgorithm(int batchNumber, double probability, Problem problem)
    {
        _problem = problem;
        _mutationProbability = probability;
        _batchSize = Problem.CityNumber / batchNumber;
        CurrentGeneration = GetInitialPopulation();
    }

    public Solution GetBestSolution()
    {
        return CurrentGeneration.MinBy(s => s.Cost);
    }

    public void Iterate()
    {
        var breedingPool = CurrentGeneration.OrderBy(s => s.Cost).Take(BreedingPoolSize).ToArray();
        var best = breedingPool.Take(BreedingPoolSize / 5).ToArray();

        var probabilities = GetProbabilities(breedingPool);

        var newPopulation = new Solution[Problem.CityNumber];

        for (int i = 0; i < Problem.CityNumber; i++)
        {
            if (i < BreedingPoolSize / 5)
            {
                newPopulation[i] = best[i];
            }
            else
            {
                newPopulation[i] = Cross(breedingPool[ChooseSolution(probabilities)],
                    breedingPool[ChooseSolution(probabilities)]);
                if (_random.NextDouble() < _mutationProbability)
                {
                    Mutate(newPopulation[i]);
                }
            }
        }

        CurrentGeneration = newPopulation;
    }

    private void Mutate(Solution solution)
    {
        var first = _random.Next(0, solution.Path.Length);
        var second = _random.Next(0, solution.Path.Length);
        (solution.Path[first], solution.Path[second]) = (solution.Path[second], solution.Path[first]);
    }

    private Solution Cross(Solution first, Solution second)
    {
        var firstGenes = new int[Problem.CityNumber / 2];
        for (int i = 0; i < Problem.CityNumber / 2; i++)
        {
            firstGenes[i] = first.Path[_batchSize * 2 * (i / _batchSize) + i % _batchSize];
        }

        var path = new int[Problem.CityNumber];
        var currentSecond = 0;
        for (int i = 0; i < Problem.CityNumber; i++)
        {
            if ((i / _batchSize) % 2 == 0)
            {
                path[i] = first.Path[i];
            }
            else
            {
                while (firstGenes.Contains(second.Path[currentSecond]))
                {
                    currentSecond++;
                }

                path[i] = second.Path[currentSecond++];
            }
        }

        return new Solution(_problem, path);
    }
    
    private int ChooseSolution(double[] probabilities)
    {
        var random = _random.NextDouble();
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
    
    private double[] GetProbabilities(Solution[] solutions)
    {
        var values = new double[solutions.Length];
        var sum = 0.0;
        for (int i = 0; i < solutions.Length; i++)
        {
            values[i] = 1.0 / solutions[i].Cost;
            sum += values[i];
        }

        for (int i = 0; i < values.Length; i++)
        {
            values[i] /= sum;
        }

        return values;
    }

    private Solution[] GetInitialPopulation()
    {
        var population = new Solution[PopulationSize];
        for (int i = 0; i < PopulationSize; i++)
        {
            population[i] = new Solution(_problem,
                Enumerable.Range(0, Problem.CityNumber).OrderBy(_ => _random.Next()).ToArray());
        }

        return population;
    }
}