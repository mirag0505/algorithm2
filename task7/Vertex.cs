using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
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
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)
        {
            if (count == max_vertex) return;

            Vertex newVertex = new Vertex(value);
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

            Vertex[] newVertex = new Vertex[max_vertex];
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
    }
}