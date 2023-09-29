using System;
using System.Collections.Generic;

// сбалансированное BST-дерево, оптимальное для быстрого поиска элементов -- 
// это когда для любой вершины дерева глубина её двух поддеревьев различается не более чем на единицу
namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int GetMiddleIndex(int leftIndex, int rightIndex)
        {
            return (leftIndex + rightIndex) / 2;
        }

        public static void RecursiveIterator(int startRange, int endRange, int currentIndex, int[] inputArray, int[] resultArray)
        {
            if (startRange > endRange || currentIndex >= inputArray.Length) return;

            int middleIndex = GetMiddleIndex(startRange, endRange);

            resultArray[currentIndex] = inputArray[middleIndex];

            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;

            RecursiveIterator(startRange, middleIndex - 1, leftChildIndex, inputArray, resultArray);
            RecursiveIterator(middleIndex + 1, endRange, rightChildIndex, inputArray, resultArray);
        }

        public static int[] GenerateBBSTArray(int[] inputArray)
        {
            Array.Sort(inputArray);

            if (inputArray.Length == 0) return new int[0];

            int[] resultArray = new int[inputArray.Length];

            RecursiveIterator(0, inputArray.Length - 1, 0, inputArray, resultArray);

            return resultArray;
        }
    }
}