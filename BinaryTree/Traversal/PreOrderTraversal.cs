using BinarySearchTree;
using System;
using System.Collections.Generic;

namespace BinaryTree.Traversal
{
    /// <summary>
    /// Прямой
    /// корень, левый потомок, правый потомок. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PreOrderTraversal : ITraversalStrategy
    {
        public IEnumerable<int> Traversal(Node node)
        {
            var result = new List<int>();

            if (node == null)
            {
                return result;
            }

            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                result.Add(node.Value);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return result;
        }
    }
}