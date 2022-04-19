using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._1__Cs
{
    public class Program
    {
        static void Main()
        {
            IOManager iOManager = new IOManager();
            FileManager fileManager = new FileManager();

            const string initialFileName = "initialFile.txt";
            const string secondFileName = "secondFile.txt";

            bool append = iOManager.AskAppending();
            iOManager.InformUser();
            List<string> text = iOManager.GetText();

            fileManager.WriteToFile(initialFileName, text, append);
            int lastLinesNumber = iOManager.AskLastLinesNumber();
            List<string> textToTransfer = fileManager.GetFileContent(initialFileName, lastLinesNumber);
            fileManager.WriteToFile(secondFileName, textToTransfer, append);

            Console.WriteLine("Second file before removal:");
            iOManager.OutputText(fileManager.GetFileContent(secondFileName));

            int removed = fileManager.RemoveRepeatingLines(secondFileName);
            Console.WriteLine("Second file after removal:");
            iOManager.OutputText(fileManager.GetFileContent(secondFileName));
            iOManager.OutputLinesRemoved(removed);
        }
    }
}