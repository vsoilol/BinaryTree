using BinarySearchTree;
using System;
using System.Collections.Generic;

namespace BinaryTree.Traversal
{
    /// <summary>
    /// Симметричный
    /// левый потомок, корень, правый потомок. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InOrderTraversal : ITraversalStrategy
    {
        public IEnumerable<int> Traversal(Node node)
        {
            var result = new List<int>();
            var stack = new Stack<Node>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    result.Add(node.Value);
                    node = node.Right;
                }
            }

            return result;
        }
    }
}