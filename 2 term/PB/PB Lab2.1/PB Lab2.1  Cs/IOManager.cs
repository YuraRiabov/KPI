using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._1__Cs
{
    public class IOManager
    {
        public List<string> GetText()
        {
            List<string> text = new List<string>();
            string currentLine = "";
            bool continueEntering = true;
            while (continueEntering)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.E && keyInput.Modifiers == ConsoleModifiers.Control)
                {
                    text.Add(currentLine);
                    currentLine = "";
                    Console.CursorLeft--;
                    Console.Write(' ');
                    continueEntering = false;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    text.Add(currentLine);
                    currentLine = "";
                    Console.CursorTop++;
                }
                else if (keyInput.Key == ConsoleKey.Backspace)
                {
                    currentLine = currentLine.Substring(0, currentLine.Length - 1);
                    Console.Write(' ');
                    Console.CursorLeft--;
                }
                else
                {
                    currentLine += keyInput.KeyChar;
                }
            }
            return text;
        }

        public void InformUser()
        {
            Console.WriteLine(@"Enter your text, to stop entering press Ctrl+E");
        }
        public int AskLastLinesNumber()
        {
            Console.WriteLine("\nEnter number of last lines to transfer: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input, try again");
            }
            return number;
        }
        public bool AskAppending()
        {
            Console.WriteLine("If you want to append file, if one exists, press 1, else press Enter");
            if (Console.ReadLine() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OutputText(List<string> text)
        {
            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
        }
        public void OutputLinesRemoved(int removed)
        {
            Console.WriteLine($"Lines removed: {removed}");
        }
    }
}
