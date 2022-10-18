using System.Diagnostics;
using PALab2;

var sw = new Stopwatch();
for (int i = 0; i < StateHelper.States.Length; i++)
{
    Console.WriteLine("State " + (i + 1));
    var state = new State(StateHelper.States[i]);
    Console.WriteLine("BFS:");
    sw.Reset();
    sw.Start();
    var solvedBFS = BFS.FindPath(state);
    sw.Stop();
    Console.WriteLine("Path length: " + solvedBFS.Path);
    Console.WriteLine(sw.Elapsed);
    Console.WriteLine("RBFS:");
    sw.Reset();
    sw.Start();
    var solvedRBFS = RBFS.Solve(state);
    sw.Stop();
    Console.WriteLine("Iterations: " + RBFS.Iterations);
    Console.WriteLine("Generated states: " + RBFS.States);
    Console.WriteLine("Stored states: " + RBFS.StoredStates);
    Console.WriteLine("Path length: " + solvedRBFS.Path);
    Console.WriteLine(sw.Elapsed);
    Console.WriteLine();
}