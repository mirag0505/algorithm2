using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...

            int tree_size = (2 << depth) - 1;
            HeapArray = new int[tree_size];
            for (int i = 0; i < tree_size; i++)
            {
                if (a.Length > i) HeapArray[i] = a[i];
                else
                {
                    HeapArray[i] = -1;
                }
            }
        }
        public int GetLength()
        {
            int count = 0;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] > -1) count++;
            }

            return count;
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            // -начинаем сдвигать элемент вниз по дереву(моделируем этот процесс движения по дереву с помощью индексов узла в массиве):

            // -останавливаемся, когда у родителя будет больший ключ, а у двух наследников-- меньшие.

            // если куча пуста
            if (GetLength() == 0) return -1;

            // -выбираем самый последний существующий элемент массива(по сути, крайний правый на нижнем уровне);
            // -перемещаем его в корень;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                int rightmost;

                if (HeapArray[i] > -1)
                {
                    rightmost = HeapArray[i];
                    HeapArray[0] = rightmost;
                    break;
                }
            }

            //  если ниже текущего узла "максимальный" узел больше текущего, меняем местами текущий элемент с этим максимальным, и продолжаем данное действие;
            int max = HeapArray[0];
            for (int i = 1; i < HeapArray.Length; i++)
            {
                if (max < HeapArray[i])
                {
                    var temp = HeapArray[i - 1];
                    HeapArray[i - 1] = HeapArray[i];
                    HeapArray[i] = temp;

                    max = HeapArray[i];
                }
                else break;
                // -останавливаемся, когда у родителя будет больший ключ, а у двух наследников-- меньшие.
            }

            return HeapArray[0];
        }

        // Аналогично выполняется и процесс вставки. 
        // и затем поднимаем его вверх по дереву, останавливаясь в позиции, когда выше у родителя будет больший ключ,
        // а ниже у обоих наследников -- меньшие
        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (GetLength() == HeapArray.Length) return false; // если куча вся заполнена

            int indexLastElement = -1;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                // Новый элемент помещаем в самый низ массива, в первый свободный слот,
                if (HeapArray[i] == -1)
                {
                    indexLastElement = i;
                    HeapArray[i] = key;
                    break;
                }
            }

            int min = HeapArray[indexLastElement];
            for (int i = indexLastElement - 1; i > 0; i--)
            {
                if (min > HeapArray[i])
                {
                    var temp = HeapArray[i - 1];
                    HeapArray[i - 1] = HeapArray[i];
                    HeapArray[i] = temp;

                    min = HeapArray[i];
                }
                else break;
            }


            return true;
        }

    }
}