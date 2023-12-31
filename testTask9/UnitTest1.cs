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

    [Fact]
    public void Test5()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(4);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');
        simpleGraph.AddVertex('D');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 2);
        simpleGraph.AddEdge(2, 3);
        simpleGraph.AddEdge(1, 3);

        var result = simpleGraph.BreadthFirstSearch(0, 3);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
        Assert.Equal('D', result[2].Value);
    }

    [Fact]
    public void Test6()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(4);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');
        simpleGraph.AddVertex('D');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 2);
        simpleGraph.AddEdge(2, 3);
        simpleGraph.AddEdge(1, 3);
        simpleGraph.AddEdge(0, 3);

        var result = simpleGraph.BreadthFirstSearch(0, 3);
        Assert.Equal('A', result[0].Value);
        Assert.Equal('D', result[1].Value);
    }

    [Fact]
    public void WeakVertices()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(3);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');
        simpleGraph.AddVertex('C');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(0, 2);
        simpleGraph.AddEdge(1, 0);
        simpleGraph.AddEdge(1, 2);
        simpleGraph.AddEdge(2, 0);
        simpleGraph.AddEdge(2, 1);

        var result = simpleGraph.WeakVertices();
        Assert.Equal(0, result.Count());
    }


    [Fact]
    public void WeakVertices2()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(2);

        simpleGraph.AddVertex('A');
        simpleGraph.AddVertex('B');

        simpleGraph.AddEdge(0, 1);
        simpleGraph.AddEdge(1, 0);

        var result = simpleGraph.WeakVertices();
        Assert.Equal(2, result.Count());
        Assert.Equal('A', result[0].Value);
        Assert.Equal('B', result[1].Value);
    }

    [Fact]
    public void WeakVertices3()
    {
        SimpleGraph<char> simpleGraph = new SimpleGraph<char>(10);

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
        simpleGraph.AddEdge(3, 6);
        simpleGraph.AddEdge(3, 5);

        simpleGraph.AddEdge(4, 3);
        simpleGraph.AddEdge(4, 1);
        simpleGraph.AddEdge(4, 0);

        simpleGraph.AddEdge(5, 3);
        simpleGraph.AddEdge(5, 6);

        simpleGraph.AddEdge(6, 5);
        simpleGraph.AddEdge(6, 3);

        var result = simpleGraph.WeakVertices();
        Assert.Equal(1, result.Count());
        Assert.Equal('3', result[0].Value);
    }
}