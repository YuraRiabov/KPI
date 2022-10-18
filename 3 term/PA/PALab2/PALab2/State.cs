namespace PALab2;

public class State
{
    public int[,] Matrix { get; }

    public Cell EmptySpace { get; set; } = new(0, 0);

    public State? Parent { get; set; }
    
    public int Distance { get; set; }
    
    public int Path { get; set; }
    
    public int Evaluation { get; set; }
    public State(int[,] matrix)
    {
        Matrix = matrix;
        CalculateEmptySpace();
        Distance = GetDistance();
    }

    public State(State another)
    {
        EmptySpace = new Cell(another.EmptySpace.Horizontal, another.EmptySpace.Vertical);
        Matrix = (int[,])another.Matrix.Clone();
        Parent = another;
        Distance = GetDistance();
        Path = Parent.Path + 1;
        Evaluation = Math.Max(Parent.Evaluation, Distance + Path);
    }
    
    public List<State> GetChildren()
    {
        var children = new List<State>()
        {
            Capacity = 4
        };
        var comparer = new StateEqualityComparer();
        if (TryMoveDown(out State? currentChild) && !comparer.Equals(currentChild, Parent))
        {
            children.Add(currentChild);
        }

        if (TryMoveUp(out currentChild) && !comparer.Equals(currentChild, Parent))
        {
            children.Add(currentChild);
        }

        if (TryMoveLeft(out currentChild) && !comparer.Equals(currentChild, Parent))
        {
            children.Add(currentChild);
        }

        if (TryMoveRight(out currentChild) && !comparer.Equals(currentChild, Parent))
        {
            children.Add(currentChild);
        }

        return children;
    }

    public bool TryMoveUp(out State? newState)
    {
        if (EmptySpace.Vertical == 2)
        {
            newState = null;
            return false;
        }

        newState = new State(this);
        (newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical + 1, EmptySpace.Horizontal]) = (
            newState.Matrix[EmptySpace.Vertical + 1, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal]);
        newState.EmptySpace.Vertical++;
        return true;

    }
    
    public bool TryMoveDown(out State? newState)
    {
        if (EmptySpace.Vertical == 0)
        {
            newState = null;
            return false;
        }
        newState = new State(this);
        (newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical - 1, EmptySpace.Horizontal]) = (
            newState.Matrix[EmptySpace.Vertical - 1, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal]);
        newState.EmptySpace.Vertical--;
        return true;

    }
    
    public bool TryMoveRight(out State? newState)
    {
        
        if (EmptySpace.Horizontal == 0) 
        {
            newState = null;
            return false;
        }
        newState = new State(this);
        (newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal - 1]) = (
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal - 1],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal]);
        newState.EmptySpace.Horizontal--;
        return true;

    }
    
    public bool TryMoveLeft(out State? newState)
    {
        if (EmptySpace.Horizontal == 2)
        {
            newState = null;
            return false;
        }
        newState = new State(this);
        (newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal + 1]) = (
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal + 1],
            newState.Matrix[EmptySpace.Vertical, EmptySpace.Horizontal]);
        newState.EmptySpace.Horizontal++;
        return true;

    }

    public bool IsSolved()
    {
        for (int i = 0; i < 8; i++)
        {
            if (Matrix[i / 3, i % 3] != i + 1)
            {
                return false;
            }
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is State another)
        {
            return another.Matrix.Equals(Matrix);
        }

        return false;
    }

    public override int GetHashCode()
    {
        double sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += Math.Pow(Matrix[i / 3, i % 3], i);
        }

        return (int)sum;
    }

    public List<State> GetPath()
    {
        var current = this;
        var path = new List<State>();
        while (current != null)
        {
            path.Add(current);
            current = current.Parent;
        }

        return path;
    }

    public int GetDistance()
    {
        var sum = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Matrix[i, j] != 0)
                {
                    var correctPosition = StateHelper.GetCorrectCell(Matrix[i, j]);
                    sum += Math.Abs(correctPosition.Horizontal - j) + Math.Abs(correctPosition.Vertical - i);
                }
            }
        }

        return sum;
    }

    private void CalculateEmptySpace()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Matrix[i, j] == 0)
                {
                    EmptySpace.Horizontal = j;
                    EmptySpace.Vertical = i;
                }
            }
        }
    }

}