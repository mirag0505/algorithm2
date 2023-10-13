namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        SimpleGraph simpleGraph = new SimpleGraph(3);
        Assert.Equal(3, simpleGraph.max_vertex);
        Assert.Equal(0, simpleGraph.count);
    }

    [Fact]
    public void Test2()
    {
        SimpleGraph simpleGraph = new SimpleGraph(3);

        simpleGraph.AddVertex(1);
        Assert.Equal(0, simpleGraph.m_adjacency[0, 0]);
        Assert.Equal(1, simpleGraph.vertex[0].Value);
        Assert.Equal(1, simpleGraph.count);

        simpleGraph.AddVertex(2);
        Assert.Equal(0, simpleGraph.m_adjacency[1, 1]);
        Assert.Equal(2, simpleGraph.vertex[1].Value);
        Assert.Equal(2, simpleGraph.count);

        simpleGraph.AddVertex(3);
        Assert.Equal(0, simpleGraph.m_adjacency[2, 2]);
        Assert.Equal(3, simpleGraph.vertex[2].Value);
        Assert.Equal(3, simpleGraph.count);
    }

    [Fact]
    public void Test3()
    {
        SimpleGraph simpleGraph = new SimpleGraph(3);

        simpleGraph.AddVertex(1);
        simpleGraph.AddVertex(2);
        simpleGraph.AddVertex(3);
        Assert.Equal(3, simpleGraph.count);
        simpleGraph.RemoveVertex(2);
        Assert.Equal(2, simpleGraph.count);
        simpleGraph.RemoveVertex(1);
        Assert.Equal(1, simpleGraph.count);
        simpleGraph.RemoveVertex(0);
        Assert.Equal(0, simpleGraph.count);
    }

    [Fact]
    public void Test4()
    {
        SimpleGraph simpleGraph = new SimpleGraph(3);

        simpleGraph.AddVertex(1);
        simpleGraph.AddVertex(2);
        simpleGraph.AddVertex(3);
        simpleGraph.RemoveVertex(0);
        simpleGraph.AddEdge(1, 2);
        simpleGraph.RemoveEdge(1, 2);
    }
}