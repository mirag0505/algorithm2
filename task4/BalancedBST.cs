using System;
using System.Collections.Generic;

// сбалансированное BST-дерево, оптимальное для быстрого поиска элементов -- 
// это когда для любой вершины дерева глубина её двух поддеревьев различается не более чем на единицу
namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            // Сортировку по возрастанию выполняйте с помощью стандартной функции сортировки.
            Array.Sort(a);

            int middleIndex = (int)a.Length / 2;

            var length = (2 << (5 + 1)) - 1;
            int[] resultArray = new int[length];
            //2^(H+1)-1
            // (два в степени(глубина плюс один)) минус один
            // ?? это информация для чего? просто чтоб знать? или это нужно в задаче? и так понятно

            // 1.Выбираем центральный элемент исходного отсортированного массива, 
            // и делаем его корневым(на первом шаге помещаем его в нулевой элемент итогового массива).
            var currentIndex = 0;
            var b = a[middleIndex];

            resultArray[currentIndex] = b;

            // 2.Для левой части по отношению к выбранному элементу повторяем этот алгоритм 
            //--индекс корневого элемента левой части будет равен индексу левого наследника корня из пункта 1.

            var leftChildreIndex = 2 * currentIndex + 1;
            resultArray[leftChildreIndex] = a[middleIndex - 1];

            // 3.Для правой части по отношению к выбранному элементу повторяем этот алгоритм 
            //--индекс корневого элемента правой части будет равен индексу правого наследника корня из пункта 1.
            var rightChildreIndex = 2 * currentIndex + 2;
            resultArray[rightChildreIndex] = a[middleIndex + 1];

            return resultArray;
        }
    }
}