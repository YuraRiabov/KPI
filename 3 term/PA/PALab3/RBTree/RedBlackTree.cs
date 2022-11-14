namespace RBTree;

public class RedBlackTree<T> where T : IComparable
{
    public RedBlackNode<T>? Root { get; set; }

    public bool Verify()
    {
        return Root.LeftChild.GetBlackHeight() == Root.RightChild.GetBlackHeight();
    }

    public void Insert(T value)
    {
        var node = new RedBlackNode<T>(value, NodeColor.Red);

        Add(node);

        FixOnInsert(node);
    }

    public void Remove(RedBlackNode<T> node)
    {
        if (node.HasRight && node.HasLeft)
        {
            node = node.Successor;
        }

        if (node.Color == NodeColor.Red)
        {
            RemoveLeaf(node);
            return;
        }

        var child = node.RightChild;

        if (child != null && child.Color == NodeColor.Red)
        {
            node.Value = child.Value;
            RemoveLeaf(child);
            return;
        }

        FixOnDelete(node);
        RemoveLeaf(node);
    }

    private void FixOnDelete(RedBlackNode<T> node)
    {
        if (node.Parent is null)
        {
            return;
        }

        var parent = node.Parent;
        var sibling = node.Sibling;

        if (sibling is { Color: NodeColor.Red })
        {
            sibling.Color = NodeColor.Black;
            parent.Color = NodeColor.Red;

            if (sibling.IsRightChild())
            {
                Rotate(parent, RotationDirection.Left);
                sibling = parent.RightChild;
            }
            else
            {
                Rotate(parent, RotationDirection.Right);
                sibling = parent.LeftChild;
            }
        }

        if (parent is { Color: NodeColor.Black } && sibling is { Color: NodeColor.Black, IsTerminate: true })
        {
            sibling.Color = NodeColor.Red;
            FixOnDelete(parent);
            return;
        }

        if (parent is { Color: NodeColor.Red } && sibling is { Color: NodeColor.Black, IsTerminate: true })
        {
            parent.Color = NodeColor.Black;
            sibling.Color = NodeColor.Red;
            return;
        }

        var leftChildOfSibling = sibling.LeftChild;
        var rightChildOfSibling = sibling.RightChild;
        if (node.IsLeftChild()
            && rightChildOfSibling == null
            && leftChildOfSibling is { Color: NodeColor.Red })
        {
            sibling.Color = NodeColor.Red;
            leftChildOfSibling.Color = NodeColor.Black;
            Rotate(sibling, RotationDirection.Right);
            sibling = sibling.Parent;
        }

        if (node.IsRightChild()
            && leftChildOfSibling == null
            && rightChildOfSibling is { Color: NodeColor.Red })
        {
            sibling.Color = NodeColor.Red;
            rightChildOfSibling.Color = NodeColor.Black;
            Rotate(sibling, RotationDirection.Left);
            sibling = sibling.Parent;
        }

        rightChildOfSibling = sibling.RightChild;
        leftChildOfSibling = sibling.LeftChild;
        if (node.IsLeftChild()
            && rightChildOfSibling is { Color: NodeColor.Red })
        {
            sibling.Color = parent.Color;
            parent.Color = NodeColor.Black;
            rightChildOfSibling.Color = NodeColor.Black;
            Rotate(parent, RotationDirection.Left);
        }
        else if (node.IsRightChild()
                 && leftChildOfSibling is { Color: NodeColor.Red })
        {
            sibling.Color = parent.Color;
            parent.Color = NodeColor.Black;
            leftChildOfSibling.Color = NodeColor.Black;
            Rotate(parent, RotationDirection.Right);
        }
    }


    private void RemoveLeaf(RedBlackNode<T> node)
    {
        if (node.IsLeftChild())
        {
            node.Parent.LeftChild = null;
        }
        else if (node.IsRightChild())
        {
            node.Parent.RightChild = null;
        }

        node.Parent = null;
    }

    public RedBlackNode<T>? Find(T content)
    {
        return Root?.Find(content);
    }

    public (RedBlackNode<T>?, int) FindWithCount(T content)
    {
        var count = 0;
        var currentNode = Root;
        while (currentNode != null)
        {
            var comparison = currentNode.Value.CompareTo(content);
            count++;
            if (comparison == 0)
            {
                return (currentNode, count);
            }

            if (comparison > 0)
            {
                if (currentNode.HasLeft)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return (null, count);
                }
            }

            if (comparison < 0)
            {
                if (currentNode.HasRight)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return (null, count);
                }
            }
        }

        return (null, 0);
    }

    public List<RedBlackNode<T>> Traverse()
    {
        var result = new List<RedBlackNode<T>>();
        var queue = new Queue<RedBlackNode<T>>();
        queue.Enqueue(Root);
        while (queue.TryPeek(out _))
        {
            var node = queue.Dequeue();
            result.Add(node);
            if (node.LeftChild is not null)
            {
                queue.Enqueue(node.LeftChild);
            }

            if (node.RightChild is not null)
            {
                queue.Enqueue(node.RightChild);
            }
        }

        return result;
    }

    public void RestoreConnections()
    {
        var queue = new Queue<RedBlackNode<T>>();
        queue.Enqueue(Root);
        while (queue.TryPeek(out _))
        {
            var node = queue.Dequeue();
            if (node.LeftChild is not null)
            {
                node.LeftChild.Parent = node;
                queue.Enqueue(node.LeftChild);
            }

            if (node.RightChild is not null)
            {
                node.RightChild.Parent = node;
                queue.Enqueue(node.RightChild);
            }
        }
    }

    private RedBlackNode<T> Rotate(RedBlackNode<T> node, RotationDirection direction)
    {
        if (node is not { HasRight: true } && direction is RotationDirection.Left ||
            node is not { HasLeft: true } && direction is RotationDirection.Right)
        {
            return node;
        }

        var newPivot = direction is RotationDirection.Left ? node.RightChild! : node.LeftChild!;

        var centerElements = direction is RotationDirection.Left ? newPivot.LeftChild : newPivot.RightChild;

        if (direction is RotationDirection.Left)
        {
            node.RightChild = centerElements;
            newPivot.LeftChild = node;
        }
        else
        {
            node.LeftChild = centerElements;
            newPivot.RightChild = node;
        }

        if (centerElements != null)
        {
            centerElements.Parent = node;
        }

        newPivot.Parent = node.Parent;

        if (node == Root)
        {
            Root = newPivot;
        }
        else
        {
            if (node.IsLeftChild())
            {
                newPivot.Parent!.LeftChild = newPivot;
            }

            if (node.IsRightChild())
            {
                newPivot.Parent!.RightChild = newPivot;
            }
        }

        node.Parent = newPivot;

        return newPivot;
    }

    private void Add(RedBlackNode<T> node)
    {
        if (Root is null)
        {
            Root = node;
            return;
        }

        Root.Add(node);
    }

    private void FixOnInsert(RedBlackNode<T> node)
    {
        if (node == Root)
        {
            node.Color = NodeColor.Black;
            return;
        }

        node.Color = NodeColor.Red;

        RedBlackNode<T> parent = node.Parent!;
        if (parent is { Color: NodeColor.Black })
        {
            return;
        }

        var uncle = node.Uncle;
        var grandParent = node.Grandparent;
        if (uncle is { Color: NodeColor.Red })
        {
            parent.Color = NodeColor.Black;
            uncle.Color = NodeColor.Black;
            FixOnInsert(grandParent);
        }
        else
        {
            if (node.IsRightChild() && parent.IsLeftChild())
            {
                parent = Rotate(parent, RotationDirection.Left);
                node = parent.LeftChild;
            }
            else if (node.IsLeftChild() && parent.IsRightChild())
            {
                parent = Rotate(parent, RotationDirection.Right);
                node = parent.RightChild;
            }

            grandParent.Color = NodeColor.Red;
            parent.Color = NodeColor.Black;
            if (node.IsLeftChild() && node.Parent.IsLeftChild())
            {
                Rotate(node.Grandparent, RotationDirection.Right);
            }
            else
            {
                Rotate(node.Grandparent, RotationDirection.Left);
            }
        }
    }
}