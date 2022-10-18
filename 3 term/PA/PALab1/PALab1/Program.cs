using System.Diagnostics;
using PALab1;

var fileSize = 1_000_000_000;
var shareSize = fileSize / 8;
var fileName = "testFile.dat";
var outputFileName = "sorted.dat";
var sw = new Stopwatch();
FileWorker.GenerateArray(fileName, fileSize);
sw.Start();
Sorter.SortParts(fileName, outputFileName, fileSize, shareSize);
Sorter.Sort(outputFileName, fileSize);
sw.Stop();
Console.WriteLine(sw.Elapsed);