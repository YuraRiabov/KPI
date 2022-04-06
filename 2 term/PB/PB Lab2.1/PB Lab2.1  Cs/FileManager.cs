using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._1__Cs
{
    public class FileManager
    {
        public void WriteToFile(string fileName, List<string> text, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append))
            {
                foreach (string line in text)
                {
                    sw.WriteLine(line);
                }
            }
        }
        public List<string> GetFileContent(string fileName, int lastLinesQuantity = int.MaxValue)
        {
            List<string> text = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }
            if (text.Count > lastLinesQuantity)
            {
                text.RemoveRange(0, text.Count - lastLinesQuantity);
            }
            return text;
        }

        public int RemoveRepeatingLines(string fileName)
        {
            List<string> text = GetFileContent(fileName);
            int deleted = 0;
            foreach (string line in text)
            {
                int count = 0;
                foreach (string line2 in text)
                {
                    if (line == line2)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    deleted += count;
                    text.RemoveAll(x => x == line);
                }
            }
            WriteToFile(fileName, text);
            return deleted;
        }
    }
}
