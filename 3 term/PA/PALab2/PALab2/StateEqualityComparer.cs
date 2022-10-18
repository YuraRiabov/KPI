namespace PALab2;

public class StateEqualityComparer : IEqualityComparer<State>
{
    public bool Equals(State? x, State? y)
    {
        if (x != null && y != null)
        {
            return x.GetHashCode() == y.GetHashCode();
        }

        return false;
    }

    public int GetHashCode(State obj)
    {
        double sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += obj.Matrix[i / 3, i % 3] * Math.Pow(10, i);
        }

        return (int)sum;
    }
}