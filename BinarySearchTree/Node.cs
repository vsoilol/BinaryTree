#nullable enable
using System;

namespace BinarySearchTree
{
    // Узел
    public class Node<T> : IComparable<T> 
        where T : IComparable<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public T Value { get; }

        public int CompareNode(Node<T> node)
        {
            return Value.CompareTo(node.Value);
        }

        public int CompareTo(T? node)
        {
            return Value.CompareTo(node);
        }
    }
}