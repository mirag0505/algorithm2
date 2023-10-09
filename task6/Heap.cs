using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи
        public int count;
        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth

            int tree_size = (2 << depth) - 1;
            HeapArray = new int[tree_size];
            for (int i = 0; i < a.Length; i++) Add(a[i]);
        }

        public void SiftingDown(int currentIndex)
        {
            int maxIndex = currentIndex;

            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;

            if (leftChildIndex < count && HeapArray[leftChildIndex] > HeapArray[maxIndex]) maxIndex = leftChildIndex;
            if (rightChildIndex < count && HeapArray[rightChildIndex] > HeapArray[maxIndex]) maxIndex = rightChildIndex;

            if (maxIndex == currentIndex) return;

            int temp = HeapArray[currentIndex];
            HeapArray[currentIndex] = HeapArray[maxIndex];
            HeapArray[maxIndex] = temp;

            SiftingDown(maxIndex);
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу

            if (count == 0) return -1;

            int root = HeapArray[0];

            // -выбираем самый последний существующий элемент массива(по сути, крайний правый на нижнем уровне);
            int rightmost = HeapArray[count - 1];
            HeapArray[count - 1] = 0;
            // -перемещаем его в корень;
            HeapArray[0] = rightmost;

            // если ниже текущего узла "максимальный" узел больше текущего, меняем местами текущий элемент с этим максимальным, и продолжаем данное действие;
            SiftingDown(0);

            count--;
            return root;
        }

        public void SiftingUp(int currentIndex, int parentIndex)
        {
            if (HeapArray[currentIndex] > HeapArray[parentIndex])
            {
                int temp = HeapArray[currentIndex];
                HeapArray[currentIndex] = HeapArray[parentIndex];
                HeapArray[parentIndex] = temp;
            }

            currentIndex = parentIndex;
            parentIndex = (currentIndex - 1) / 2;

            if (currentIndex > 0 && parentIndex >= 0) SiftingUp(currentIndex, parentIndex);
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (count == HeapArray.Length) return false; // если куча вся заполнена

            // Новый элемент помещаем в самый низ массива, в первый свободный слот
            int indexEmptyElement = count;
            HeapArray[indexEmptyElement] = key;

            // и затем поднимаем его вверх по дереву, останавливаясь в позиции, когда выше у родителя будет больший ключ, а ниже у обоих наследников -- меньшие.
            int parentIndex = (indexEmptyElement - 1) / 2;

            SiftingUp(indexEmptyElement, parentIndex);

            count++;

            return true;
        }

    }
}