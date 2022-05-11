using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._6
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T>? LeftChild { get; set; }
        public BinaryTreeNode<T>? RightChild { get; set; }

        public BinaryTreeNode(T value)
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
