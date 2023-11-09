namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(7);

        simpleGraph.AddVertex('1');
        simpleGraph.AddVertex('2');
        simpleGraph.AddVertex('3');
        simpleGraph.AddVertex('4');
        simpleGraph.AddVertex('5');
        simpleGraph.AddVertex('6');
        simpleGraph.AddVertex('7');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(0, 4);

        simpleGraph.AddEdge(1, 0);
        simpleGraph.AddEdge(1, 2);
        simpleGraph.AddEdge(1, 4);

        simpleGraph.AddEdge(2, 1);
        simpleGraph.AddEdge(2, 3);

        simpleGraph.AddEdge(3, 2);
        simpleGraph.AddEdge(3, 4);

        simpleGraph.AddEdge(4, 3);
        simpleGraph.AddEdge(4, 1);
        simpleGraph.AddEdge(4, 0);

        simpleGraph.AddEdge(5, 3);
        simpleGraph.AddEdge(5, 6);

        simpleGraph.AddEdge(6, 5);
        simpleGraph.AddEdge(6, 3);

        var result = simpleGraph.WeakVertices();
    }
}