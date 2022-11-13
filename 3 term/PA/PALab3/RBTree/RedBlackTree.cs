namespace RBTree;

public class RedBlackTree<T> where T : IComparable
{
    public RedBlackNode<T>? Root { get; set; }

    public void Insert(T value)
    {
        var node = new RedBlackNode<T>(value, NodeColor.Red);

        Add(node);

        FixOnInsert(node);
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
        // if parent is black then nothing to do - all properties are still valid
        if (parent is { Color: NodeColor.Black })
        {
            return;
        }

        // else we have parent as red so node has grandparent and uncle (uncle can be NIL)
        var uncle = node.Uncle;
        var grandParent = node.Grandparent;
        if (uncle is { Color: NodeColor.Red })
        {
            // if parent and uncle boths reds then recoloring them to black
            // and recoloring grandparent to red
            parent.Color = NodeColor.Black;
            uncle.Color = NodeColor.Black;
            FixOnInsert(grandParent);
        }
        else
        {
            // parent is red and uncle is black (real or NIL)
            // rotating of node "between" parent and uncle in ordering
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

            // parent is red and uncle is black (real or NIL) and node is greater or lesser boths
            // then rotating tree in the grandparent
            grandParent.Color = NodeColor.Red;
            parent.Color = NodeColor.Black;
            if (node.IsLeftChild() && node.Parent.IsLeftChild())
            {
                Rotate(node.Grandparent, RotationDirection.Right);
            }
            else
            {
                this.Rotate(node.Grandparent, RotationDirection.Left);
            }
        }
    }

    public RedBlackNode<T>? Find(T content)
    {
        return Root?.Find(content);
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
}