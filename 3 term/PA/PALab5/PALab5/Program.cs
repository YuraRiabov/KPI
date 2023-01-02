using PALab5;

var problem  = new Problem();
var csv = "";
var batchNumber = 4;
var probability = 0.3;
var algorithm = new GeneticAlgorithm(batchNumber, probability, problem);
for (int i = 0; i < 500; i++)
{
    for (int j = 0; j < 20; j++)
    {
        algorithm.Iterate();
    }

    var line = (i * 20 + 20) + ", " + algorithm.GetBestSolution().Cost + "\n";
    csv += line;
    Console.Write(line);
}

using var sw = new StreamWriter($"result_{batchNumber}_{probability}.csv");
sw.WriteLine(csv);