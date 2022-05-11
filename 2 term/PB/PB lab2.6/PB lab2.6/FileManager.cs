using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._6
{
    public class FileManager
    {
        public static List<string> GetWordsFromFile(string fileName)
        {
            string text;
            List<string> words = new List<string>();
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    text = sr.ReadToEnd();
                }
                words = text.Split(' ', ',', '.', '!', '?', '\n', '\r').Where(x => x.Length > 0).ToList();
            }
            return words;
        }
    }
}
