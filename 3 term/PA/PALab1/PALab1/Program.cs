using System.Diagnostics;
using PALab1;

var fileSize = 2000_000;
var sw = new Stopwatch();
FileWorker.GenerateArray("testFile.txt", fileSize);
sw.Start();
Sorter.Sort("testFile.txt", fileSize);
sw.Stop();
Console.WriteLine(sw.Elapsed);
Console.ReadLine();