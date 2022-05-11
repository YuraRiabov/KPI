using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._6
{
    public class Program
    {
        static void Main()
        {
            const string fileName = "source.txt";
            List<string> words = FileManager.GetWordsFromFile(fileName);
            BinarySearchTree tree = new BinarySearchTree(words);
            List<string> traversal = tree.InfixTraversal();
            Console.WriteLine("Infix traversal of built tree:");
            foreach (string word in traversal)
            {
                Console.Write($"{word} ");
            }
            Console.Write("\nEnter a letter to count words which start with it: ");
            char letter = Console.ReadLine()[0];
            int result = tree.CountFromLetter(letter);
            Console.WriteLine($"The result is {result}");
        }
    }
}
