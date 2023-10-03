using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root; // корень дерева

        public BalancedBST()
        {
            Root = null;
        }

        public static int GetMiddleIndex(int leftIndex, int rightIndex)
        {
            return (leftIndex + rightIndex) / 2;
        }

        public void RecursiveIterator(int startRange, int endRange, int currentIndex, int[] inputArray, BSTNode parentNode, int level, bool? isLeft)
        {
            if (startRange > endRange || currentIndex >= inputArray.Length) return;

            int middleIndex = GetMiddleIndex(startRange, endRange);

            BSTNode newNode = new BSTNode(inputArray[middleIndex], parentNode);
            newNode.Level = level;

            if (isLeft is not null and true) parentNode.LeftChild = newNode;
            if (isLeft is not null and false) parentNode.RightChild = newNode;

            if (Root == null) Root = newNode;

            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;

            RecursiveIterator(startRange, middleIndex - 1, leftChildIndex, inputArray, newNode, level + 1, true);
            RecursiveIterator(middleIndex + 1, endRange, rightChildIndex, inputArray, newNode, level + 1, false);
        }

        public void GenerateTree(int[] a)
        {
            // создаём дерево с нуля из неотсортированного массива a
            Array.Sort(a);

            if (a.Length == 0) return;

            RecursiveIterator(0, a.Length - 1, 0, a, null, 0, null);
        }
        public int FindDepth(BSTNode node)
        {
            if (node == null) return 0;
            int leftDepth = FindDepth(node.LeftChild);
            int rightDepth = FindDepth(node.RightChild);
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null) return true;
            var leftHight = FindDepth(root_node.LeftChild);
            var rightHight = FindDepth(root_node.RightChild);

            if (Math.Abs(leftHight - rightHight) < 1) return true;
            return false;
        }

    }
}