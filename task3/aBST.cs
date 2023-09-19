using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = (2 << depth) - 1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int Count()
        {
            return Tree.Length;
        }

        public string getTreeString()
        {
            return string.Join(",", Tree);
        }

        public int? FindKeyIndex(int key)
        {
            // ищем в массиве индекс ключа
            int i = 0;
            while (i < Tree.Length)
            {
                if (Tree[i] == null) return -i;
                if (Tree[i] == key) return i;

                int LeftChildIndex = 2 * i + 1;
                int RightChildIndex = 2 * i + 2;
                i = Tree[i] > key ? LeftChildIndex : RightChildIndex;
            }

            return null; // не найден
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            int? index = FindKeyIndex(key);
            if (index <= 0)
            {
                Tree[(int)-index] = key;
                return (int)-index;
            }
            else if (index > 0)
            {
                return (int)index;
            }
            return -1;
            // индекс добавленного/существующего ключа или -1 если не удалось
        }

    }
}