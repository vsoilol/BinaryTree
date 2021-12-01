using BinarySearchTree;
using BinaryTree.Console.Constants;
using BinaryTree.Console.Extensions;
using BinaryTree.Traversal;
using System;

namespace BinaryTree.Console.BinaryTree
{
    internal static class BinaryTreeConsole
    {
        private static readonly Tree binaryTree = new() { 8, 3, 1, 6, 4, 7, 10, 14, 13 };

        public static void ShowBinaryTree(ITraversalStrategy traversalStrategy)
        {
            binaryTree.TraversalStrategy = traversalStrategy;
            binaryTree.PrintToConsole();
        }

        public static void CreateTreeWithRandomValue()
        {
            var count = GetIntFromConsole(ConsoleMessage.EnterValue);

            binaryTree.Clear();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                int newElement;

                do
                {
                    newElement = random.Next(0, 20);
                }
                while (binaryTree.Contains(newElement));

                binaryTree.Add(newElement);
            }
            System.Console.WriteLine(ConsoleMessage.CreatedSuccessfully);
        }

        public static void ShowBinaryTreeAsTree()
        {
            binaryTree.PrintAsTree();
        }

        public static void ClearTree()
        {
            binaryTree.Clear();
            System.Console.WriteLine(ConsoleMessage.ClearSuccessfully);
        }

        public static void AddNodeToTree()
        {
            var value = GetIntFromConsole(ConsoleMessage.EnterValue);
            binaryTree.Add(value);
            System.Console.WriteLine(ConsoleMessage.AddedSuccessfully);
        }

        public static void RemoveNodeFromTree()
        {
            var value = GetIntFromConsole(ConsoleMessage.EnterValue);
            var isRemoved = binaryTree.Remove(value);

            if (isRemoved)
            {
                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine($"Узел {value} удален, количество узлов после удаления : {binaryTree.Count}");
            }
        }

        private static int GetIntFromConsole(string message)
        {
            System.Console.Write(message);
            return int.Parse(System.Console.ReadLine() ?? string.Empty);
        }
    }
}