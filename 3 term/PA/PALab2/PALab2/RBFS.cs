using System.Runtime.InteropServices;

namespace PALab2;

public class RBFS
{
    public static int Iterations { get; set; }
    public static int States { get; set; }
    public static int StoredStates { get; set; }
    public static SearchResult Solve(State initialState)
    {
        Iterations = 0;
        States = 0;
        StoredStates = 0;
        return SolveRecursive(initialState, int.MaxValue);
    }

    private static SearchResult SolveRecursive(State state, int limit)
    {
        if (state.IsSolved())
        {
            return new SearchResult(state, state.Path);
        }

        var children = state.GetChildren();

        States += children.Count;

        if (children.Count == 0)
        {
            return new SearchResult(null, int.MaxValue);
        }

        while (true)
        {
            Iterations++;
            (int bestIndex, int altIndex) = GetBestStates(children);
            if (children[bestIndex].Evaluation > limit)
            {
                return new SearchResult(null, children[bestIndex].Evaluation);
            }
            
            

            var sr = SolveRecursive(children[bestIndex], Math.Min(limit, children[altIndex].Evaluation));

            if (sr.State is not null)
            {
                StoredStates += children.Count;
                return sr;
            }

            children[bestIndex].Evaluation = sr.Path;
        }
    }

    private static (int best, int alt) GetBestStates(List<State> states)
    {
        var best = int.MaxValue;
        var alt = int.MaxValue;
        var bestIndex = 0;
        var altIndex = 0;
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i].Evaluation < best)
            {
                alt = best;
                altIndex = bestIndex;
                best = states[i].Evaluation;
                bestIndex = i;
            }
            else if (states[i].Evaluation < alt)
            {
                alt = states[i].Evaluation;
                altIndex = i;
            }
        }

        return (bestIndex, altIndex);
    }
}