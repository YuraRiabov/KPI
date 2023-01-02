using PALab4;

var problem = new Problem();
var alg = new AntAlgorithm(problem);
var csv = "";
for (int i = 0; i < 50; i++)
{
    for (int j = 0; j < 20; j++)
    {
        alg.Iterate();
    }

    var line = 20 * (i + 1) + "," + problem.GetCost(alg.GetSolution()) + "\n";
    Console.Write(line);
    csv += line;
}
using var sw = new StreamWriter("result.csv");
sw.WriteLine(csv);



