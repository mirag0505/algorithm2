namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(3);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');
        // simpleGraph.AddVertex('D');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 2);

        var result = simpleGraph.DepthFirstSearch(0, 2);
    }
}