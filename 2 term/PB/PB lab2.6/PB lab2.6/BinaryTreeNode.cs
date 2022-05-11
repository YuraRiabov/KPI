using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._6
{
    public class BinaryTreeNode
    {
        public string Value { get; set; }
        public BinaryTreeNode? LeftChild { get; set; }
        public BinaryTreeNode? RightChild { get; set; }

        public BinaryTreeNode(string value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }
        public bool IsLeaf()
        {
            return LeftChild != null || RightChild != null;
        }
    }
}
