namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(4);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');

        simpleGraph.AddEdge(0, 1);

        var result = simpleGraph.DepthFirstSearch(0, 1);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
    }

    [Fact]
    public void Test2()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(3);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');
        // simpleGraph.AddVertex('D');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 2);

        var result = simpleGraph.DepthFirstSearch(0, 2);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
        Assert.Equal('C', result[2].Value);
    }

    [Fact]
    public void Test3()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(4);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');

        simpleGraph.AddEdge(0, 1);

        var result = simpleGraph.BreadthFirstSearch(0, 1);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
    }

    [Fact]
    public void Test4()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(3);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');
        // simpleGraph.AddVertex('D');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 2);

        var result = simpleGraph.BreadthFirstSearch(0, 2);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
        Assert.Equal('C', result[2].Value);
    }
}