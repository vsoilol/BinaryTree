using BinarySearchTree;
using System;
using System.Collections.Generic;

namespace BinaryTree.Traversal
{
    /// <summary>
    /// Обратный
    /// левый потомок, правый потомок, корень.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PostOrderTraversal : ITraversalStrategy
    {
        public IEnumerable<int> Traversal(Node node)
        {
            var result = new List<int>();
            var stack = new Stack<Node>();
            Node lastNodeVisited = null;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        result.Add(peekNode.Value);
                        lastNodeVisited = stack.Pop();
                    }
                }
            }

            return result;
        }
    }
}
