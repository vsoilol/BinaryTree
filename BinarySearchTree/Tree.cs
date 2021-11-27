using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class Tree<T>
        where T : IComparable<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; private set; }

        /*private ITraversalStrategy<T> _traversalStrategy;

        public Tree(ITraversalStrategy<T> traversalStrategy)
        {
            _traversalStrategy = traversalStrategy ?? throw new ArgumentNullException(nameof(traversalStrategy));
        }

        public ITraversalStrategy<T> TraversalStrategy
        {
            get => _traversalStrategy ?? (_traversalStrategy = new InOrderTraversal<T>());
            set => _traversalStrategy = value ?? throw new ArgumentNullException(nameof(value));
        }*/

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                AddTo(Head, value);
            }

            Count++;
        }

        private static void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            return FindWithParent(value, out var _) != null;
        }

        /*[Obsolete]
        public void SetTraversalStrategy(ITraversalStrategy<T> traversalStrategy)
        {
            _traversalStrategy = traversalStrategy ?? throw new ArgumentNullException(nameof(traversalStrategy));
        }*/

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            var current = Head;
            parent = null;

            while (current != null)
            {
                var result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        /*
        public IEnumerator<T> GetEnumerator()
        {
            return TraversalStrategy.Traversal(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/
        
        public IEnumerable<T> TraversePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }
        
        public IEnumerable<T> TraversePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }
    }
}