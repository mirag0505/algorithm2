namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(2);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 0);

        var result = simpleGraph.WeakVertices();
    }
}