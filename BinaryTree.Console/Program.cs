using BinarySearchTree;
using BinaryTree.Console.BinaryTree;
using BinaryTree.Console.Extensions;
using BinaryTree.Traversal;
using ConsoleTools;
using System;

namespace BinaryTree.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Показать бинарное дерево в виде дерева", BinaryTreeConsole.ShowBinaryTreeAsTree)
                .Add("Создать дерево", BinaryTreeConsole.CreateTreeWithRandomValue)
                .Add("Симметричный обход", () => BinaryTreeConsole.ShowBinaryTree(new InOrderTraversal()))
                .Add("Обратный обход", () => BinaryTreeConsole.ShowBinaryTree(new PostOrderTraversal()))
                .Add("Прямой обход", () => BinaryTreeConsole.ShowBinaryTree(new PreOrderTraversal()))
                .Add("Удалить узел", BinaryTreeConsole.RemoveNodeFromTree)
                .Add("Добавить узел", BinaryTreeConsole.AddNodeToTree)
                .Add("Очистить дерево", BinaryTreeConsole.ClearTree)
                .Add("Выход", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Операции с бинарным деревом поиска";
                    config.EnableWriteTitle = true;
                });

            menu.Show();
        }
    }
}