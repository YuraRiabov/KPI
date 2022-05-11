using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._6
{
    public class BinarySearchTree
    {
        public BinaryTreeNode Root { get; set; }

        public BinarySearchTree(List<string> words)
        {
            Root = new BinaryTreeNode(words[0]);
            for (int i = 1; i < words.Count; i++)
            {
                AddNode(words[i]);
            }
        }
        public List<string> InfixTraversal()
        {
            List<string> result = new List<string>();
            InfixTraversal(Root, result);
            return result;
        }

        private void InfixTraversal(BinaryTreeNode node, List<string> traversal)
        {
            if (node.LeftChild != null)
            {
                InfixTraversal(node.LeftChild, traversal);
            }
            traversal.Add(node.Value);
            if (node.RightChild != null)
            {
                InfixTraversal(node.RightChild, traversal);
            }
        }

        public int CountFromLetter(char letter)
        {
            List<string> traversal = InfixTraversal();
            return traversal.Where(x => char.ToLower(x[0]) == char.ToLower(letter)).Count();
        }

        public void AddNode(string value)
        {
            BinaryTreeNode currentNode = Root;
            BinaryTreeNode node = new BinaryTreeNode(value);
            bool isAdded = false;
            while (!isAdded)
            {
                if (String.Compare(value, currentNode.Value, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = node;
                        isAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                    }
                }
                else
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = node;
                        isAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }
            }
        }
    }
}
