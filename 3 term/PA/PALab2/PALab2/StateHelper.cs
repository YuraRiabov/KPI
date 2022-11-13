namespace PALab2;

public static class StateHelper
{
    public static Cell GetCorrectCell(int number)
    {
        return CorrectPositions[number - 1];
    }
    public static readonly Cell[] CorrectPositions =
    {
        new(0, 0), new(1, 0), new(2, 0),
        new(0, 1), new(1, 1), new(2, 1),
        new(0, 2), new(1, 2), new(2, 2),
    };
    public static readonly int[][,] States = 
    {
        new[,] {
            { 1, 2, 3 },
            { 4, 0, 6 },
            { 7, 5, 8 }
        },
        new[,] {
            {4, 1, 0},
            {7, 5, 3},
            {8, 2, 6}
        }, //10
        new[,] {
            {3, 2, 6},
            {1, 0, 8},
            {5, 4, 7}
        },//14
        new[,] {
            {5, 4, 2},
            {6, 1, 3},
            {0, 7, 8}
        },//16
        new[,] {
            {7, 5, 2},
            {1, 6, 8},
            {4, 0, 3}
        }, //19
        new[,] {
            {2, 1, 4},
            {3, 0, 6},
            {7, 5, 8}
        },//18
        new[,] {
            {2, 6, 4},
            {3, 1, 0},
            {5, 7, 8}
        },//23
        new[,] {
            {0, 6, 7},
            {4, 3, 2},
            {1, 5, 8}
        },//22
        new[,] {
            {8, 7, 4},
            {2, 5, 1},
            {6, 3, 0}
        },
        new[,] {
            {8, 0, 4},
            {3, 7, 1},
            {2, 5, 6}
        },
        new[,] {
            {8, 3, 4},
            {5, 7, 1},
            {2, 6, 0}
        },
        new[,] {
            {0, 2, 7},
            {3, 6, 8},
            {4, 1, 5}
        },
        new[,] {
            {3, 4, 2},
            {5, 0, 8},
            {7, 6, 1}
        },
        new[,] {
            {4, 1 ,5},
            {6, 0, 3},
            {2, 7, 8}
        },
        new[,] {
            {4, 5, 7},
            {0, 8, 2},
            {3, 1, 6}
        },
        new[,] {
            {6, 7, 1},
            {2, 5, 8},
            {3, 4, 0}
        },
        new[,] {
            {1, 5, 6},
            {3, 4, 0},
            {8, 2, 7}
        },
        new[,] {
            {2, 6, 5},
            {1, 0, 3},
            {8, 4, 7}
        },
        new[,] {
            {6, 5, 8},
            {3, 7, 4},
            {2, 1, 0}
        },
        new[,] {
            {1, 3, 2},
            {8, 0, 7},
            {5, 6, 4}
        },
    };
    
    public static readonly int[,] Solved = {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 0 }
    };

    public static readonly int[,] AlmostSolved = {
        { 1, 2, 3 },
        { 4, 0, 6 },
        { 7, 5, 8 }
    };

    public static void ShowPath(this State state)
    {
        var path = state.GetPath();
        path.Reverse();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var position in path)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(position.Matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}