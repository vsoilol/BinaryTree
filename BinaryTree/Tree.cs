using BinaryTree.Traversal;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class Tree : ICollection<int>
    {

        /// <summary>
        /// Количество элементов в дереве считая с корнем
        /// </summary>
        public int Count { get; private set; }


        /// <summary>
        /// Корень
        /// </summary>
        public Node Root { get; private set; }


        /// <summary>
        /// Проход дерева
        /// </summary>
        private ITraversalStrategy _traversalStrategy;

        /// <summary>
        /// Свойства для прохода дерева
        /// По умолчанию симметричный
        /// </summary>
        public ITraversalStrategy TraversalStrategy
        {
            get => _traversalStrategy ??= new InOrderTraversal();
            set => _traversalStrategy = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Только для чтения
        /// Это свойтсво содержиться в интерфейсе ICollection
        /// </summary>
        public bool IsReadOnly => false;


        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                var node = Root;
                var stack = new Stack<Node>();
                stack.Push(node);

                while (stack.Count > 0)
                {
                    node = stack.Pop();

                    if (value < node.Value)
                    {
                        if (node.Left == null)
                        {
                            node.Left = new Node(value);
                        }
                        else
                        {
                            stack.Push(node.Left);
                        }
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = new Node(value);
                        }
                        else
                        {
                            stack.Push(node.Right);
                        }
                    }
                }
            }

            Count++;
        }

        public bool Contains(int value)
        {
            return FindWithParent(value, out var _) != null;
        }

        private Node FindWithParent(int value, out Node parent)
        {
            var current = Root;
            parent = null;

            while (current != null)
            {
                if (current.Value < value)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (current.Value > value)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        /// <summary>
        /// Копировать все элементы дерева в массив начиная с заданного элемента
        /// </summary>
        public void CopyTo(int[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            var items = TraversalStrategy.Traversal(Root);

            foreach (var item in items)
            {
                array[arrayIndex++] = item;
            }
        }


        public bool Remove(int item)
        {
            var current = FindWithParent(item, out var parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if(parent.Value < current.Value)
                    {
                        parent.Right = current.Left;
                    }
                    else if(parent.Value > current.Value)
                    {
                        parent.Left = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Root = current.Right;
                }
                else
                {
                    if(parent.Value < current.Value)
                    {
                        parent.Right = current.Right;
                    }
                    else if(parent.Value > current.Value)
                    {
                        parent.Left = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    Root = leftMost;
                }
                else
                {
                    if(parent.Value < current.Value)
                    {
                        parent.Right = leftMost;
                    }
                    else if (parent.Value > current.Value)
                    {
                        parent.Left = leftMost;
                    }
                }
            }

            return true;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return TraversalStrategy.Traversal(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}