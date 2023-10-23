using System.Collections;
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }
    // Расширьте класс SimpleGraph из позапрошлого занятия методом DepthFirstSearch(), 
    // который получает в качестве параметров два узла Vertex (начальный и конечный) 
    // -- узлы задаются индексами-позициями в списке vertex -- и возвращает список узлов, 
    // представляющий собой путь из начального узла в конечный. Список будет пустым, если пути не существует.
    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;
        public int count;

        public SimpleGraph(int size)
        {
            // максимальное количество вершин (исходя из конкретной задачи), 
            // чтобы сразу сформировать пустую матрицу смежности;
            max_vertex = size;
            // матрица смежности, где 0 означает отсутствие ребра между i-й вершиной (первое измерение) 
            // и j-й вершиной (второе измерение), а 1 означает наличие ребра;
            m_adjacency = new int[size, size];
            // список vertex, хранящий вершины.
            vertex = new Vertex<T>[size];
        }

        public void AddVertex(T value)
        {
            if (count == max_vertex) return;

            Vertex<T> newVertex = new Vertex<T>(value);
            vertex[count] = newVertex;

            m_adjacency[count, count] = 0;

            count++;
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            if (v >= max_vertex - 1 && v < 0) return;
            // ваш код удаления вершины со всеми её рёбрами
            m_adjacency[v, v] = 0;

            Vertex<T>[] newVertex = new Vertex<T>[max_vertex];
            for (int i = v; i < vertex.Length - 1; i++)
            {
                vertex[i] = vertex[i + 1];
                vertex[i + 1] = null;
            }
            count--;
        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1) return true;
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
            // добавление ребра между вершинами v1 и v2
        }

        public void RemoveEdge(int v1, int v2)
        {
            // удаление ребра между вершинами v1 и v2
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }

        // Первый алгоритм -- это поиск пути через обход графа в глубину 
        // (путь находится неоптимальный, но ищется он быстро, и хорошо реализуется рекурсивно). 
        // Этому алгоритму потребуется стек.

        // Алгоритм Depth-first search(dfs) работает так:

        // Реализуйте этот алгоритм с помощью стека.
        public Stack<Vertex<T>> RecursionSearch(Vertex<T> currentVertex, Stack<Vertex<T>> stack, int VFrom, int VTo, bool missThirtPoint)
        {
            // 2) Фиксируем вершину X как посещённую.
            currentVertex.Hit = true;

            // 3) Помещаем вершину X в стек.
            if (!missThirtPoint) stack.Push(currentVertex);

            // 4) Ищем среди смежных вершин вершины X целевую вершину Б. Если она найдена, 
            // записываем её в стек и возвращаем сам стек как результат работы (путь из А в Б).
            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[VFrom, i] == 1 && i != VFrom && i == VTo)
                {
                    stack.Push(vertex[VTo]);
                    return stack;
                }
            }

            // Если целевой вершины среди смежных нету, то выбираем среди смежных такую вершину, 
            // которая ещё не была посещена.

            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[VFrom, i] == 1 && i != VFrom && vertex[i].Hit == false)
                {
                    // Если такая вершина найдена, делаем её текущей X и переходим к п. 2.
                    VFrom = i;
                    return RecursionSearch(vertex[i], stack, VFrom, VTo, false);
                }
            }

            // 5) Если непосещённых смежных вершин более нету, удаляем из стека верхний элемент. 
            if (stack.Count > 0) stack.Pop();

            // Если стек пуст, то прекращаем работу и информируем, что путь не найден. 
            if (stack.Count == 0)
            {
                Console.WriteLine("The path isn't found");
                return new Stack<Vertex<T>>();
            }

            // В противном случае делаем текущей вершиной X верхний элемент стека, помечаем его как посещённый, 
            // и после чего переходим к п. 4.
            return RecursionSearch(stack.Peek(), stack, VFrom, VTo, true);
        }
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {

            // Узлы задаются позициями в списке vertex.
            // Возвращается список узлов -- путь из VFrom в VTo.
            // Список пустой, если пути нету.
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();

            // 0) Очищаем все дополнительные структуры данных: делаем стек пустым, 
            // а все вершины графа отмечаем как непосещённые(см.далее).
            for (int i = 0; i < count; i++) vertex[i].Hit = false;
            // 1) Выбираем текущую вершину X. Для начала работы это будет исходная вершина А.
            RecursionSearch(vertex[VFrom], stack, VFrom, VTo, false);

            var list = new List<Vertex<T>>(stack);
            list.Reverse();
            return list;
        }
    }
}