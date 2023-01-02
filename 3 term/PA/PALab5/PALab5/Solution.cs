namespace PALab5;

public struct Solution
{
    public int[] Path { get; set; }
    public Problem Problem { get; set; }
    public int Cost { get; set; }

    public Solution(Problem problem, int[] path)
    {
        Path = path;
        Problem = problem;
        Cost = Problem.GetCost(path);
    }
}