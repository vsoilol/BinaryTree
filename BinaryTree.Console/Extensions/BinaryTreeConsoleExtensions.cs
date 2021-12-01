using BinarySearchTree;
using System;
using System.Collections.Generic;

namespace BinaryTree.Console.Extensions
{
    internal static class BinaryTreeConsoleExtensions
    {
        public static void PrintToConsole<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                System.Console.Write($"{item} ");
            }
        }

        public static void PrintAsTree(this Tree source)
        {
            source.Print();
        }

        private static void Print(this Tree root, int spacing = 1, int topMargin = 1, int leftMargin = 1)
        {
            if (root == null)
            {
                return;
            }

            int rootTop = System.Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root.Root;

            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo
                {
                    Node = next,
                    Text = next.Value.ToString()
                };

                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }

                if (level > 0)
                {
                    item.Parent = last[level - 1];

                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }

                next = next.Left ?? next.Right;

                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);

                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                    }

                    if (item.Right != null)
                    {
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }

                    if (--level < 0)
                    {
                        break;
                    }

                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                        {
                            item.Parent.EndPos = item.StartPos - 1;
                        }
                        else
                        {
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                        }
                    }
                }
            }
            System.Console.SetCursorPosition(0, rootTop + 2 * last.Count);
        }

        private static void Print(string symbol, int top, int left, int right = -1)
        {
            System.Console.SetCursorPosition(left, top);

            if (right < 0)
            {
                right = left + symbol.Length;
            }

            while (System.Console.CursorLeft < right)
            {
                System.Console.Write(symbol);
            }
        }
    }

    internal class NodeInfo
    {
        public Node Node { get; set; }

        public string Text { get; set; }

        public int StartPos { get; set; }

        public int Size { get => Text.Length; }

        public int EndPos
        { 
            get => StartPos + Size; 
            set => StartPos = value - Size; 
        }

        public NodeInfo Parent { get; set; }

        public NodeInfo Left { get; set; }

        public NodeInfo Right { get; set; }
    }
}