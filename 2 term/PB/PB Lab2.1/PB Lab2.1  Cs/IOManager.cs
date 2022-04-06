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
    }
}
