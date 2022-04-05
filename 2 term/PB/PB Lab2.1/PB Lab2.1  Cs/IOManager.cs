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
            string currentString = "";
            ConsoleKeyInfo currentKey = Console.ReadKey();
            while (currentKey.Equals(ConsoleKey.E) == false || currentKey.Modifiers.Equals(ConsoleModifiers.Shift) == false)
            {
                if (currentKey.Equals(ConsoleKey.Enter))
                {
                    text.Add(currentString);
                    currentString = "";
                    Console.CursorTop++;
                }
                else if (currentKey.Equals(ConsoleKey.Backspace))
                {
                    currentString = currentString.Remove(currentString.Length - 1);
                    Console.CursorLeft--;
                }
                else
                {
                    currentString += currentKey.KeyChar;
                }
                currentKey = Console.ReadKey();
            }
            return text;
        }
    }
}
