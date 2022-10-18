namespace PALab2;

public static class BFS
{
    public static State? FindPath(State initial)
    {
        var queue = new Queue<State>();
        queue.Enqueue(initial);
        var states = 0;
        var iterations = 0;
        while (queue.TryPeek(out _))
        {
            var current = queue.Dequeue();

            var children = current.GetChildren();
            states += children.Count;
            foreach (var child in children)
            {
                iterations++;
                if (child.IsSolved())
                {
                    Console.WriteLine("Iterations: " + iterations);
                    Console.WriteLine("Generated states: " + states);
                    Console.WriteLine("Stored states: " + queue.Count);
                    return child;
                }
                queue.Enqueue(child);
            }
        }

        return null;
    }
}