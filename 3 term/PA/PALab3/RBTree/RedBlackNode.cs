using System.Text.Json.Serialization;

namespace RBTree;

public class RedBlackNode<T> : IComparable where T: IComparable
{
    public T Value { get; set; }
    
    public NodeColor Color { get; set; }
    
    [JsonIgnore]
    public RedBlackNode<T>? Parent { get; set; }
    
    public RedBlackNode<T>? LeftChild { get; set; }
    
    public RedBlackNode<T>? RightChild { get; set; }

    [JsonIgnore]
    public RedBlackNode<T>? Sibling => IsRightChild() ? Parent?.LeftChild : Parent?.RightChild;

    [JsonIgnore]
    public RedBlackNode<T>? Uncle => Parent?.Sibling;

    [JsonIgnore]
    public RedBlackNode<T>? Grandparent => Parent?.Parent;

    [JsonIgnore]
    public RedBlackNode<T> Successor
    {
        get
        {
            if (!HasRight)
            {
                return this;
            }

            var current = RightChild;
            while (current!.HasLeft)
            {
                current = current.LeftChild;
            }

            return current;
        }
    }

    [JsonIgnore]
    public bool HasRight => RightChild is not null;

    [JsonIgnore]
    public bool HasLeft => LeftChild is not null;

    [JsonIgnore] 
    public bool IsTerminate => !HasRight && !HasLeft;

    public RedBlackNode(T value, NodeColor color)
    {
        Value = value;
        Color = color;
    }

    public bool IsLeftChild()
    {
        if (Parent is null)
        {
            return false;
        }

        return Parent.LeftChild == this;
    }

    public bool IsRightChild()
    {
        if (Parent is null)
        {
            return false;
        }

        return Parent.RightChild == this;
    }

    public int CompareTo(object? obj)
    {
        if (obj is RedBlackNode<T> another)
        {
            return Value.CompareTo(another.Value);
        }

        return 1;
    }
    
    internal RedBlackNode<T>? Find(T content)
    {
        return Value.CompareTo(content) switch
        {
            0 => this,
            > 0 => HasLeft ? LeftChild!.Find(content) : null,
            _ => HasRight ? RightChild!.Find(content) : null
        };
    }
    
    internal void Add(RedBlackNode<T> nodeToInsert)
    {
        if (CompareTo(nodeToInsert) > 0)
        {
            if (HasLeft)
            {
                LeftChild!.Add(nodeToInsert);
                return;
            }

            LeftChild = nodeToInsert;
            LeftChild.Parent = this;
            return;
        }

        if (HasRight)
        {
            RightChild!.Add(nodeToInsert);
            return;
        }

        RightChild = nodeToInsert;
        RightChild.Parent = this;
    }

    internal int GetBlackHeight()
    {
        var ownValue = Color == NodeColor.Black ? 1 : 0;
        if (IsTerminate)
        {
            return ownValue;
        }

        var leftValue = LeftChild?.GetBlackHeight() ?? -1;
        var rightValue = RightChild?.GetBlackHeight() ?? -1;
        return (leftValue > rightValue ? leftValue : rightValue) + ownValue;
    }
}